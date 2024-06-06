using OpticSalon.Domain.Models.Report;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services
{
    public interface IReportService
    {
        public Task<ResultWithData<List<LensPackagesReportItem>>> GetLensPackagesReport(DateTime start, DateTime end);
    }
}
