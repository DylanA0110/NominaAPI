using Microsoft.EntityFrameworkCore;
using PayrollAPI.Data;
using PayrollAPI.Repository.IRepository;
using SharedModels.Entidades;

namespace PayrollAPI.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly PayrollContext _context;

        public EmployeeRepository(PayrollContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Employee> UpdateAsync(Employee entity)
        {
            var existingEmployee = await _context.Employees.FindAsync(entity.Id);
            if (existingEmployee != null)
            {
                _context.Entry(existingEmployee).CurrentValues.SetValues(entity);
                await SaveChangesAsync();
            }
            return existingEmployee;
        }

        public async Task<List<Employee>> SearchEmployeesAsync(string searchTerm)
        {
            return await _context.Employees
            .Where(e => e.FirstName.Contains(searchTerm)
                 || e.LastName.Contains(searchTerm)
                 || e.IdentificationNumber.Contains(searchTerm))
            .ToListAsync();
        }
    }
}
