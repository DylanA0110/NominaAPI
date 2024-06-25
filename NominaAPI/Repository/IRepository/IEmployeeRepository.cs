using SharedModels.Entidades;

namespace PayrollAPI.Repository.IRepository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> UpdateAsync(Employee entity);
        Task<List<Employee>> SearchEmployeesAsync(string searchTerm);
    }
}
