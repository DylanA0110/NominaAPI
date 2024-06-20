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


            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Payrolls)
                .WithOne(p => p.Employee)
                .HasForeignKey(p => p.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Payroll>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Payroll>()
                .HasOne(p => p.Employee)
                .WithMany(e => e.Payrolls)
                .HasForeignKey(p => p.EmployeeId);

            modelBuilder.Entity<Payroll>()
                .HasMany(p => p.Incomes)
                .WithOne(i => i.Payroll)
                .HasForeignKey(i => i.PayrollId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Payroll>()
                .HasMany(p => p.Deductions)
                .WithOne(d => d.Payroll)
                .HasForeignKey(d => d.PayrollId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Income>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Deduction>()
                .HasKey(d => d.Id);

        }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Deduction> Deductions { get; set; }
    }
}
