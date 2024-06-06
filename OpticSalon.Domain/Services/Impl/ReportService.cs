using OpticSalon.Domain.ErrorMessages;
using OpticSalon.Domain.Models.Report;
using OpticSalon.Domain.Repositories;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services.Impl
{
    public class ReportService : IReportService
    {
        private ILensPackagesRepository _lensPackagesRepository;
        private IEmployeeRepository _employeeRepository;

        public ReportService(IEmployeeRepository employeeRepository, ILensPackagesRepository lensPackagesRepository)
        {
            _employeeRepository = employeeRepository;
            _lensPackagesRepository = lensPackagesRepository;
        }

        public async Task<ResultWithData<List<EmployeeReportItem>>> GetEmployeeReport(DateTime start, DateTime end)
        {
            try
            {
                var result = await _employeeRepository.GetReport(start, end);

                return new ResultWithData<List<EmployeeReportItem>>()
                {
                    Success = true,
                    Data = result
                };
            }
            catch
            {
                return new ResultWithData<List<EmployeeReportItem>>()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
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
