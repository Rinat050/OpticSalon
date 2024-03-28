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

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var employeeDb = Mapper.Map(employee);
            await Context.Employees.AddAsync(employeeDb);
            await Context.SaveChangesAsync();
            Context.Entry(employeeDb).State = EntityState.Detached;

            return Mapper.Map(employeeDb);
        }

        public async Task DeleteEmployee(Employee employee)
        {
            var employeeDb = Mapper.Map(employee);
            Context.Employees.Remove(employeeDb);
            await Context.SaveChangesAsync();
        }
    }
}
