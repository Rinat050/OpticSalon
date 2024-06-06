using OpticSalon.Domain.ErrorMessages;
using OpticSalon.Domain.Models.Report;
using OpticSalon.Domain.Repositories;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services.Impl
{
    public class ReportService : IReportService
    {
        private ILensPackagesRepository _lensPackagesRepository;

        public ReportService(ILensPackagesRepository lensPackagesRepository)
        {
            _lensPackagesRepository = lensPackagesRepository;
        }

        public async Task<ResultWithData<List<LensPackagesReportItem>>> GetLensPackagesReport(DateTime start, DateTime end)
        {
            try
            {
                var result = await _lensPackagesRepository.GetReport(start, end);

                return new ResultWithData<List<LensPackagesReportItem>>()
                {
                    Success = true,
                    Data = result
                };
            }
            catch
            {
                return new ResultWithData<List<LensPackagesReportItem>>()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }
    }
}
