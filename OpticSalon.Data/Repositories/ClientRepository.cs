using Microsoft.EntityFrameworkCore;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;

namespace OpticSalon.Data.Repositories
{
    public class ClientRepository : BaseRepository, IClientRepository
    {
        public ClientRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Client> AddClient(Client client)
        {
            var clientDb = Mapper.Map(client);
            await Context.Clients.AddAsync(clientDb);
            await Context.SaveChangesAsync();
            Context.Entry(clientDb).State = EntityState.Detached;

            return Mapper.Map(clientDb);
        }

        public async Task DeleteClient(Client client)
        {
            var clientDb = Mapper.Map(client);
            Context.Clients.Remove(clientDb);
            await Context.SaveChangesAsync();
        }
    }
}
