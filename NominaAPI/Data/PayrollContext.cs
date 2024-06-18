using Microsoft.EntityFrameworkCore;
using SharedModels.Entidades;
using System.Reflection;

namespace PayrollAPI.Data
{
    public class PayrollContext : DbContext
    {
        public PayrollContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Deduction> Deductions { get; set; }
    }
}
