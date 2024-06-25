using PayrollAPI.Data;
using PayrollAPI.Repository.IRepository;
using SharedModels.Entidades;

namespace PayrollAPI.Repository
{
    public class IncomeRepository : Repository<Income>, IIncomeRepository
    {
        public IncomeRepository(PayrollContext context) : base(context)
        {
        }
    }
}
