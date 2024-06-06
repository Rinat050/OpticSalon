using Microsoft.EntityFrameworkCore;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Models.Report;
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

        public async Task<List<Client>> GetAllClients()
        {
            var clientsDb = await Context.Clients.Select(x => Mapper.Map(x)).ToListAsync();
            return clientsDb;
        }

        public async Task<Client?> GetClientById(int id)
        {
            var clientDb = await Context.Clients.FirstOrDefaultAsync(x => x.Id == id);
            return clientDb == null ? null : Mapper.Map(clientDb);
        }

        public async Task<ClientPreferences?> GetClientPreferences(int clientId)
        {
            var result = await Context.ClientPreferences
                        .Include(x => x.FrameColor)
                        .Include(x => x.FrameMaterial)
                        .Include(x => x.FrameType)
                        .Include(x => x.FrameSizes)
                        .Include(x => x.Client)
                        .FirstOrDefaultAsync(x => x.ClientId == clientId);

            return result == null ? null : Mapper.Map(result);
        }

        public async Task<List<ClientReportItem>> GetReport(DateTime start, DateTime end)
        {
            var startDate = DateTime.SpecifyKind(start, DateTimeKind.Utc);
            var endDate = DateTime.SpecifyKind(end, DateTimeKind.Utc);

            var result = await Context.Orders
                .Where(x => x.CreatedDate.Date >= startDate.Date && x.CreatedDate.Date <= endDate.Date)
                .Include(x => x.Client)
                .GroupBy(x => x.ClientId)
                .Select(x => new ClientReportItem()
                {
                    ClientId = x.Key,
                    Client = $"{x.First().Client.Surname} {x.First().Client.Name}",
                    OrderCount = x.Count()
                })
                .ToListAsync();

            foreach(var item in result)
            {
                var existOrder = await Context.Orders
                    .FirstOrDefaultAsync(x => x.ClientId == item.ClientId && x.CreatedDate.Date < startDate.Date);

                if (existOrder == null)
                {
                    item.IsNew = true;
                }
            }

            return result;
        }

        public async Task UpdateClient(Client client)
        {
            var clientDb = Mapper.Map(client);
            Context.Clients.Update(clientDb);
            await Context.SaveChangesAsync();

            Context.ChangeTracker.Clear();
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
