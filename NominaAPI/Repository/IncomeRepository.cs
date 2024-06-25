using Microsoft.EntityFrameworkCore;
using PayrollAPI.Data;
using PayrollAPI.Repository.IRepository;
using SharedModels.Entidades;

namespace PayrollAPI.Repository
{
    public class IncomeRepository : Repository<Income>, IIncomeRepository
    {
        private readonly PayrollContext _context;
        public IncomeRepository(PayrollContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Income> UpdateAsync(Income entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync();
            return entity;
        }
    }
}
