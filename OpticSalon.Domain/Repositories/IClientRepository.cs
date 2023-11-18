using OpticSalon.Domain.Models;

namespace OpticSalon.Domain.Repositories
{
    public interface IClientRepository
    {
        public Task<Client> AddClient(Client client);
        public Task<Client?> GetClientById(int id);
        public Task<ClientPreferences?> GetClientPreferences(int clientId);
        public Task AddClientPreferences(ClientPreferences preferences);
        public Task UpdateClient(Client client);
        public Task UpdateClientPreferences(ClientPreferences preferences);
        public Task DeleteClient(Client client);
    }
}