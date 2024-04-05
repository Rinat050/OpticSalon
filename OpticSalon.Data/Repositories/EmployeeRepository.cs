using Microsoft.EntityFrameworkCore;
using OpticSalon.Domain.Models;
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
    }
}
