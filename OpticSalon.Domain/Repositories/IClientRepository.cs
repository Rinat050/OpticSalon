using OpticSalon.Domain.Models;

namespace OpticSalon.Domain.Repositories
{
    public interface IClientRepository
    {
        public Task<Client> AddClient(Client client);
        public Task DeleteClient(Client client);
    }
}