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
        public async Task<IEnumerable<Deduction>> GetByPayrollIdAsync(int payrollId)
        {
            try
            {
                var deductions = await _context.Deductions
                    .Where(d => d.PayrollId == payrollId)
                    .ToListAsync();

                return deductions;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener deducciones por ID de nómina {payrollId}: {ex.Message}");
            }
        }
        public async Task<Deduction> UpdateAsync(Deduction entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync();
            return entity;
        }
    }
}
