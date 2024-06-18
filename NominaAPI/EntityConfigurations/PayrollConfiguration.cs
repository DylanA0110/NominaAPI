using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedModels.Entidades;

namespace PayrollAPI.EntityConfigurations
{
    public class PayrollConfiguration : IEntityTypeConfiguration<Payroll>
    {
        public void Configure(EntityTypeBuilder<Payroll> builder)
        {
            builder.HasKey(p => p.PayrollId);

            // Relación Payroll - Employee (muchos a uno)
            builder.HasOne(p => p.Employee)
                .WithMany(e => e.Payrolls)
                .HasForeignKey(p => p.EmployeeId);

            // Relación Payroll - Income (uno a muchos)
            builder.HasMany(p => p.Incomes)
                .WithOne(i => i.Payroll)
                .HasForeignKey(i => i.PayrollId);

            // Relación Payroll - Deduction (uno a muchos)
            builder.HasMany(p => p.Deductions)
                .WithOne(d => d.Payroll)
                .HasForeignKey(d => d.PayrollId);
        }
    }
}
