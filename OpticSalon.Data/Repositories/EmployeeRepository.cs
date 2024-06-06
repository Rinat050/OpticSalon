using Microsoft.EntityFrameworkCore;
using OpticSalon.Domain.Enums;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Models.Report;
using OpticSalon.Domain.Repositories;

namespace OpticSalon.Data.Repositories
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            var employeeDb = Mapper.Map(employee);
            await Context.Employees.AddAsync(employeeDb);
            await Context.SaveChangesAsync();
            Context.Entry(employeeDb).State = EntityState.Detached;

            return Mapper.Map(employeeDb);
        }

        public async Task DeleteEmployeeAsync(Employee employee)
        {
            var employeeDb = Mapper.Map(employee);
            Context.Employees.Remove(employeeDb);
            await Context.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            var result = await Context.Employees.Select(x => Mapper.Map(x)).ToListAsync();
            return result;
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            var result = await Context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            return result == null ? null : Mapper.Map(result);
        }

        public async Task<List<EmployeeReportItem>> GetReport(DateTime start, DateTime end)
        {
            var startDate = DateTime.SpecifyKind(start, DateTimeKind.Utc);
            var endDate = DateTime.SpecifyKind(end, DateTimeKind.Utc);

            var result = await Context.Orders
                .Where(x => x.CreatedDate.Date >= startDate.Date && x.CreatedDate.Date <= endDate.Date
                && (x.Status == (int)OrderStatus.Issued || x.Status == (int)OrderStatus.Completed))
                .Include(x => x.Master)
                .GroupBy(x => x.MasterId)
                .Select(x => new EmployeeReportItem()
                {
                    EmployeeName = $"{x.First().Master.Surname} {x.First().Master.Name}",
                    OrderCount = x.Count()
                })
                .ToListAsync();

            return result;
        }

        public async Task UpdateEmployee(Employee employee)
        {
            var employeeDb = Mapper.Map(employee);
            Context.Employees.Update(employeeDb);
            await Context.SaveChangesAsync();

            Context.ChangeTracker.Clear();
        }
    }
}
