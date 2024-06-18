using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedModels.Entidades;

namespace PayrollAPI.EntityConfigurations
{
    public class DeductionConfiguration : IEntityTypeConfiguration<Deduction>
    {
        public void Configure(EntityTypeBuilder<Deduction> builder)
        {
            builder.HasKey(d => d.DeductionId);

            // Relación con Employee (muchos a uno)
            builder.HasOne<Employee>(d => d.Employee)
                   .WithMany()  // No especificamos la propiedad de navegación en Employee
                   .HasForeignKey(d => d.EmployeeId)
                   .IsRequired();

            // Relación con Payroll (uno a muchos)
            builder.HasOne<Payroll>(d => d.Payroll)
                   .WithMany(p => p.Deductions)
                   .HasForeignKey(d => d.PayrollId)
                   .IsRequired();
        }
    }
}
