using PayrollAPI.Data;
using PayrollAPI.Repository.IRepository;
using SharedModels.Entidades;

namespace PayrollAPI.Repository
{
    public class PayrollRepository : Repository<Payroll>, IPayrollRepository
    {
        public PayrollRepository(PayrollContext context) : base(context)
        {
        }
    }
}
