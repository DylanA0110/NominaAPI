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
        public async Task<IEnumerable<Income>> GetByPayrollIdAsync(int payrollId)
        {
            try
            {
                // Implementación para buscar ingresos por ID de nómina
                var incomes = await _context.Incomes
                    .Where(i => i.PayrollId == payrollId)
                    .ToListAsync();

                return incomes;
            }
            catch (Exception ex)
            {
                // Manejar excepciones según sea necesario
                throw new Exception($"Error al obtener ingresos por ID de nómina {payrollId}: {ex.Message}");
            }
        }
    }
}
