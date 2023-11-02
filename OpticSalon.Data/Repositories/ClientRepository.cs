using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;

namespace OpticSalon.Data.Repositories
{
    public class ClientRepository : BaseRepository, IClientRepository
    {
        protected ClientRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Client> AddClient(Client client)
        {
            var clientDb = Mapper.Map(client);
            await Context.Clients.AddAsync(clientDb);
            await Context.SaveChangesAsync();
            Context.ChangeTracker.Clear();
            return Mapper.Map(clientDb);
        }
    }
}
