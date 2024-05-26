using Microsoft.Extensions.Configuration;
using MimeKit;
using OpticSalon.Domain.Consts;
using OpticSalon.Domain.ResultModels;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace OpticSalon.Domain.Services.Impl
{
    public class EmailService : IEmailService
    {
        private static readonly SemaphoreSlim Semaphore = new(1, 1);
        private readonly string? _mailPassword;

        public EmailService(IConfiguration configuration)
        {
            _mailPassword = configuration.GetValue<string>("MailSettings:Password");
        }

        public async Task<BaseResult> SendEmailAsync(string email, string subject, string message)
        {
            await Semaphore.WaitAsync();
            var sendMessage = new MimeMessage();
            sendMessage.From.Add(new MailboxAddress(MailConsts.Name, MailConsts.Address));
            sendMessage.To.Add(MailboxAddress.Parse(email));
            sendMessage.Subject = subject;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "<table border=\"0\" cellpadding=\"0\" cellspacing =\"0\" style =\"width: 100 %; " +
                "max - width: 700px; margin: 0 auto; padding: 60px 40px; border - radius: 10px; background: white; \">" +
                "<tbody><tr><td style = \"padding-top: 30px;\"><div style=\"text-align: center;\"><img src = \"https://firebasestorage.googleapis.com/v0/b/opticsalon-92417.appspot.com/o/logo-dark-text.png?alt=media&token=8921c16e-a9dc-4c0c-b8e2-c5964f224dd4\"" +
                "alt = \"ОптикТехно\" style=\"width: 300px;\"></div></td></tr><tr><td><h1 style = \"font-size: 36px;padding-top: 20px;" +
                $"font-family:Helvetica, Arial, sans-serif;text-align: center;\">{subject}</h1></td></tr><tr><td>" +
                "<p style = \"font-family:Helvetica, Arial, sans-serif;font-size: 20px;padding-top:15px;" +
                $"line-height: 1.25;text-align: center;\">{message}</p></td</tr></tbody></table>";

            sendMessage.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();

            try
            {
                await client.ConnectAsync("smpt.mail.ru", 465, true);
                await client.AuthenticateAsync(MailConsts.Address, _mailPassword);
                await client.SendAsync(sendMessage);
                return new BaseResult { Success = true };
            }
            catch
            {
                return new BaseResult { Success = false, Description = "Не удалось отправить письмо!" };
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
                Semaphore.Release();
            }
        }
    }
}
