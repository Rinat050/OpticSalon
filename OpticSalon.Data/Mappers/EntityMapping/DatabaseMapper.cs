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
        public partial FrameType Map(FrameTypeDb frameTypeDb);
        public partial FrameTypeDb Map(FrameType frameType);
        public partial FrameMaterial Map(FrameMaterialDb frameMaterialDb);
        public partial FrameMaterialDb Map(FrameMaterial frameMaterial);
        public partial Color Map(ColorDb colorDb);
        public partial ColorDb Map(Color color);
    }
}
