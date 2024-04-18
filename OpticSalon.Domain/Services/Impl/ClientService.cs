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

        public async Task<BaseResult> AddClientPreferences(ClientPreferences preferences)
        {
            try
            {
                var existClient = await _clientRepository.GetClientById(preferences.ClientId);

                if (existClient == null)
                {
                    return new BaseResult()
                    {
                        Success = false,
                        Description = ClientServiceMessages.ClientNotFounded
                    };
                }

                await _clientRepository.AddClientPreferences(preferences);

                return new BaseResult()
                {
                    Success = true,
                    Description = ClientServiceMessages.SuccessPreferencesSaving
                };
            }
            catch
            {
                return new BaseResult()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }

        public async Task<ResultWithData<ClientPreferences>> GetClientPreferences(int clientId)
        {
            try
            {
                var existClient = await _clientRepository.GetClientById(clientId);

                if (existClient == null)
                {
                    return new ResultWithData<ClientPreferences>()
                    {
                        Success = false,
                        Description = ClientServiceMessages.ClientNotFounded
                    };
                }

                var result = await _clientRepository.GetClientPreferences(clientId);

                return new ResultWithData<ClientPreferences>()
                {
                    Success = true,
                    Data = result
                };
            }
            catch
            {
                return new ResultWithData<ClientPreferences>()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }

        public async Task<ResultWithData<Client>> CreateClient(string login, string password, string name,
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
                    return new ResultWithData<Client> 
                    { 
                        Success = false, 
                        Description = registerRes.Description 
                    };
                }

                return new ResultWithData<Client>() 
                { 
                    Success = true, 
                    Description = ClientServiceMessages.SuccessCreated,
                    Data = createdClient
                };
            }
            catch
            {
                return new ResultWithData<Client>() { Success = false, Description = DefaultErrors.ServerError };
            }
        }

        public async Task<BaseResult> UpdateClientPreferences(ClientPreferences preferences)
        {
            try
            {
                var existClient = await _clientRepository.GetClientById(preferences.ClientId);

                if (existClient == null)
                {
                    return new BaseResult()
                    {
                        Success = false,
                        Description = ClientServiceMessages.ClientNotFounded
                    };
                }

                await _clientRepository.UpdateClientPreferences(preferences);

                return new BaseResult()
                {
                    Success = true,
                    Description = ClientServiceMessages.SuccessPreferencesSaving
                };
            }
            catch
            {
                return new BaseResult()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }

        public async Task<ResultWithData<Client>> GetClientById(int id)
        {
            try
            {
                var existClient = await _clientRepository.GetClientById(id);

                if (existClient == null)
                {
                    return new ResultWithData<Client>()
                    {
                        Success = false,
                        Description = ClientServiceMessages.ClientNotFounded
                    };
                }

                return new ResultWithData<Client>()
                {
                    Success = true,
                    Data = existClient
                };
            }
            catch
            {
                return new ResultWithData<Client>()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }

        public async Task<BaseResult> UpdateClient(Client client)
        {
            try
            {
                await _clientRepository.UpdateClient(client);

                return new BaseResult()
                {
                    Success = true,
                    Description = ClientServiceMessages.SuccessUpdated
                };
            }
            catch
            {
                return new BaseResult()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }

        public async Task<ResultWithData<List<Client>>> GetAllClients()
        {
            try
            {
                var allClients = await _clientRepository.GetAllClients();

                return new ResultWithData<List<Client>>()
                {
                    Success = true,
                    Data = allClients
                };
            }
            catch
            {
                return new ResultWithData<List<Client>>()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }
    }
}
