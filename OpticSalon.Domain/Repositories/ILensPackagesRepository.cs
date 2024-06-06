using OpticSalon.Domain.Models;
using OpticSalon.Domain.Models.Report;

namespace OpticSalon.Domain.Repositories
{
    public interface ILensPackagesRepository
    {
        public Task<List<LensPackage>> GetAll();
        public Task<LensPackage> AddLensPackage(LensPackage lensPackage);
        public Task UpdateLensPackage(LensPackage lensPackage);
        public Task<LensPackage?> GetLensPackageByName(string name);
        public Task<List<LensPackagesReportItem>> GetReport(DateTime start, DateTime end);
    }
}
