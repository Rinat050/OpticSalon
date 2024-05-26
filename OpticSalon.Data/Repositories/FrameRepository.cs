using Microsoft.EntityFrameworkCore;
using OpticSalon.Data.Models;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;

namespace OpticSalon.Data.Repositories
{
    public class FrameRepository : BaseRepository, IFrameRepository
    {
        public FrameRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Frame> AddFrame(Frame frame)
        {
            var frameDb = Mapper.MapFrame(frame);

            frameDb.IsActive = true;

            foreach (var item in frameDb.Colors)
            {
                item.Color = null!;
            }

            await Context.Frames.AddAsync(frameDb);
            await Context.SaveChangesAsync();
            Context.Entry(frameDb).State = EntityState.Detached;
            Context.ChangeTracker.Clear();

            var addedFrame = await GetFrameByModelAndBrand(frame.Model, frame.Brand.Id);

            addedFrame!.MainImageName = $"{addedFrame.Id}-{addedFrame.MainImageName}";

            await UpdateFrame(addedFrame);

            return addedFrame;
        }

        public async Task<Frame?> GetFrameById(int id)
        {
            var frame = await Context.Frames.Include(x => x.Gender)
                                      .Include(x => x.Brand)
                                      .Include(x => x.Material)
                                      .Include(x => x.Colors)
                                      .ThenInclude(x => x.Color)
                                      .Include(x => x.Sizes)
                                      .Include(x => x.Type)
                                      .FirstOrDefaultAsync(x => x.Id == id);
            return frame is null ? null : Mapper.MapFrame(frame);
        }

        public async Task<Frame?> GetFrameByModelAndBrand(string model, int brandId)
        {
            var frame = await Context.Frames.Include(x => x.Gender)
                                     .Include(x => x.Brand)
                                     .Include(x => x.Material)
                                     .Include(x => x.Colors)
                                     .ThenInclude(x => x.Color)
                                     .Include(x => x.Sizes)
                                     .Include(x => x.Type)
                                     .FirstOrDefaultAsync(x => x.BrandId == brandId && model.ToLower() == x.Model.ToLower());
            return frame is null ? null : Mapper.MapFrame(frame);
        }

        public async Task<List<FrameShort>> GetFrames(int? typeId, int? materialId, int? colorId, 
                                            int? genderId, int? brandId, ClientPreferences? clientPreferences,
                                            decimal minCost, decimal maxCost, bool isForAdmin)
        {
            Predicate<FrameDb> _type = x => true;
            Predicate<FrameDb> _material = x => true;
            Predicate<FrameDb> _color = x => true;
            Predicate<FrameDb> _gender = x => true;
            Predicate<FrameDb> _brand = x => true;
            Predicate<FrameDb> _cost = x => x.Cost >= minCost && x.Cost <= maxCost;
            Predicate<FrameDb> _preferences = x => true;
            Predicate<FrameDb> _allFrames = x => x.IsActive;

            if (isForAdmin)
                _allFrames = x => true;

            if (typeId != null)
                _type = x => x.TypeId == typeId;

            if (materialId != null)
                _material = x => x.MaterialId == materialId;

            if (colorId != null)
                _color = x => x.Colors.FirstOrDefault(c => c.ColorId == colorId) != null;

            if (genderId != null)
                _gender = x => x.GenderId == genderId;

            if (brandId != null)
                _brand = x => x.BrandId == brandId;

            if (clientPreferences != null)
                _preferences = x => x.MaterialId == clientPreferences.FrameMaterial.Id &&
                                x.TypeId == clientPreferences.FrameType.Id &&
                                x.Colors.FirstOrDefault(c => c.ColorId == clientPreferences.FrameColor.Id) != null &&
                                x.Sizes.LensWidth == clientPreferences.FrameSizes.LensWidth &&
                                x.Sizes.DistanceBetweenLens == clientPreferences.FrameSizes.DistanceBetweenLens &&
                                x.Sizes.TempleLenght == clientPreferences.FrameSizes.TempleLenght;

            var res = await Context.Frames
                                        .Include(x => x.Colors)
                                        .Include(x => x.Sizes)
                                        .Include(x => x.Brand)
                                        .ToListAsync();

            var frames = res.Where(x => _type(x) && _color(x) && _brand(x) && _allFrames(x) &&
                                _gender(x) && _material(x) && _preferences(x) && _cost(x))
                            .Select(x => Mapper.MapFrameShort(x))
                            .ToList();

            return frames;
        }

        public decimal GetMaxFrameCost()
        {
            var res =  Context.Frames.Max(x => x.Cost);
            return res;
        }

        public decimal GetMinFrameCost()
        {
            var res = Context.Frames.Min(x => x.Cost);
            return res;
        }

        public async Task UpdateFrame(Frame frame)
        {
            var frameDb = Mapper.MapFrame(frame);

            foreach (var item in frameDb.Colors)
            {
                item.Color = null!;
                item.FrameId = frame.Id;
            }

            var existColorsDb = await Context.FrameColors
                .Where(x => x.FrameId == frameDb.Id).ToListAsync();

            foreach (var colorDb in existColorsDb)
            {
                var existColor = frameDb.Colors.FirstOrDefault(x => x.Id == colorDb.Id);

                if (existColor == null)
                {
                    Context.FrameColors.Remove(colorDb);
                }
            }

            Context.Frames.Update(frameDb);
            await Context.SaveChangesAsync();

            Context.ChangeTracker.Clear();
        }
    }
}
