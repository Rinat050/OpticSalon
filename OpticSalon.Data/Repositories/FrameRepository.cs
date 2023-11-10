using Microsoft.EntityFrameworkCore;
using OpticSalon.Data.Models;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;

namespace OpticSalon.Data.Repositories
{
    public class FrameRepository : BaseRepository, IFrameRepository
    {
        protected FrameRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<List<FrameShort>> GetFrames(int? typeId, int? materialId, int? colorId, 
                                            int? genderId, ClientPreferences? clientPreferences)
        {
            Predicate<FrameDb> _type = x => true;
            Predicate<FrameDb> _material = x => true;
            Predicate<FrameDb> _color = x => true;
            Predicate<FrameDb> _gender = x => true;
            Predicate<FrameDb> _preferences = x => true;

            if (typeId != null)
            {
                _type = x => x.TypeId == typeId;
            }

            if (materialId != null)
            {
                _material = x => x.MaterialId == materialId;
            }

            if (colorId != null)
            {
                _color = x => x.Colors.FirstOrDefault(c => c.ColorId == colorId) != null;
            }

            if (genderId != null)
            {
                _gender = x => x.GenderId == genderId;
            }

            if (clientPreferences != null)
            {
                _color = x => x.MaterialId == clientPreferences.FrameMaterial.Id &&
                                x.TypeId == clientPreferences.FrameType.Id &&
                                x.Colors.FirstOrDefault(c => c.ColorId == clientPreferences.FrameColor.Id) != null &&
                                x.Sizes.LensWidth == clientPreferences.FrameSizes.LensWidth &&
                                x.Sizes.DistanceBetweenLens == clientPreferences.FrameSizes.DistanceBetweenLens &&
                                x.Sizes.TempleLenght == clientPreferences.FrameSizes.TempleLenght;
            }

            var res = await Context.Frames
                                        .Include(x => x.Colors)
                                        .Include(x => x.Sizes)
                                        .Where(x => _type(x) && _color(x) && 
                                        _gender(x) && _material(x) && _preferences(x))
                                        .ToListAsync();

            var frames = res.Select(x => Mapper.Map(x)).ToList();

            return frames;
        }
    }
}
