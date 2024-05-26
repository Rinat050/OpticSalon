using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services
{
    public interface IEmailService
    {
        public Task<BaseResult> SendEmailAsync(string email, string subject, string message);
    }
}
