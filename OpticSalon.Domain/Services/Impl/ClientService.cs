using OpticSalon.Auth.Models;
using OpticSalon.Auth.Services;
using OpticSalon.Domain.ErrorMessages;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;
using OpticSalon.Domain.ResultModels;
using OpticSalon.Domain.SuccessMessages;

namespace OpticSalon.Domain.Services.Impl
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IAuthService _authService;

        public ClientService(IClientRepository clientRepository, IAuthService authService)
        {
            _clientRepository = clientRepository;
            _authService = authService;
        }

        public async Task<BaseResult> CreateClient(string login, string password, string name, 
                                                string surname, string phoneNumber, string address)
        {
            try
            {
                var newClient = new Client()
                {
                    Name = name,
                    Surname = surname,
                    PhoneNumber = phoneNumber,
                    Address = address
                };

                var createdClient = await _clientRepository.AddClient(newClient);

                var registerRes = await _authService.RegisterUser(login, password, Role.Client, createdClient.Id);

                if (!registerRes.Success)
                {
                    await _clientRepository.DeleteClient(createdClient);
                    return new BaseResult { Success = false, Description = registerRes.Description };
                }

                return new BaseResult() { Success = true, Description = ClientServiceMessages.SuccessCreated};
            }
            catch
            {
                return new BaseResult() { Success = false, Description=DefaultErrors.ServerError };
            }
        }
    }
}
