using PayrollAPI.Data;
using PayrollAPI.Repository.IRepository;
using SharedModels.Entidades;

namespace PayrollAPI.Repository
{
    public class DeductionRepository : Repository<Deduction>, IDeductionRepository
    {
        public DeductionRepository(PayrollContext context) : base(context)
        {
        }
    }
}
