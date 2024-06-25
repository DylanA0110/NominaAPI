using Microsoft.EntityFrameworkCore;
using PayrollAPI.Data;
using PayrollAPI.Repository.IRepository;
using SharedModels.Entidades;

namespace PayrollAPI.Repository
{
    public class DeductionRepository : Repository<Deduction>, IDeductionRepository
    {
        private readonly PayrollContext _context;
        public DeductionRepository(PayrollContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Deduction> UpdateAsync(Deduction entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync();
            return entity;
        }
    }
}
