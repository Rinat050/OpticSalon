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

        public async Task AddClientPreferences(ClientPreferences preferences)
        {
            var preferencesDb = Mapper.Map(preferences);
            await Context.ClientPreferences.AddAsync(preferencesDb);
            await Context.SaveChangesAsync();
            Context.Entry(preferencesDb).State = EntityState.Detached;
        }

        public async Task DeleteClient(Client client)
        {
            var clientDb = Mapper.Map(client);
            Context.Clients.Remove(clientDb);
            await Context.SaveChangesAsync();
        }

        public async Task<Client?> GetClientById(int id)
        {
            var clientDb = await Context.Clients.FirstOrDefaultAsync(x => x.Id == id);
            return clientDb == null ? null : Mapper.Map(clientDb);
        }

        public async Task<ClientPreferences?> GetClientPreferences(int clientId)
        {
            var result = await Context.ClientPreferences
                        .FirstOrDefaultAsync(x => x.ClientId == clientId);

            return result == null ? null : Mapper.Map(result);
        }

        public async Task UpdateClientPreferences(ClientPreferences preferences)
        {
            var preferencesDb = Mapper.Map(preferences);
            Context.ClientPreferences.Update(preferencesDb);
            await Context.SaveChangesAsync();

            Context.ChangeTracker.Clear();
        }
    }
}
