using OpticSalon.Domain.Models;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services
{
    public interface IClientService
    {
        public Task<ResultWithData<Client>> CreateClient(string login, string password, string name, 
                                    string surname, string phoneNumber, string address);
        public Task<BaseResult> AddClientPreferences(ClientPreferences preferences);
        public Task<ResultWithData<ClientPreferences>> GetClientPreferences(int clientId);
        public Task<BaseResult> UpdateClientPreferences(ClientPreferences preferences);
        public Task<ResultWithData<Client>> GetClientById(int id);
    }
}
