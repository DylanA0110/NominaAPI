using SharedModels.Entidades;

namespace PayrollAPI.Repository.IRepository
{
    public interface IIncomeRepository : IRepository<Income>
    {
        Task<Income> UpdateAsync(Income entity);
        Task<IEnumerable<Income>> GetByPayrollIdAsync(int payrollId);
    }
}
