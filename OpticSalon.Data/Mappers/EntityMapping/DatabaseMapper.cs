using OpticSalon.Data.Models;
using OpticSalon.Domain.Models;
using Riok.Mapperly.Abstractions;

namespace OpticSalon.Data.Mappers.EntityMapping
{
    [Mapper]
    public sealed partial class DatabaseMapper
    {
        public partial Client Map(ClientDb clientDb);
        public partial ClientDb Map(Client client);
    }
}
