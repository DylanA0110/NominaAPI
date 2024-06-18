using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedModels.Entidades;

namespace PayrollAPI.EntityConfigurations
{
    public class IncomeConfiguration : IEntityTypeConfiguration<Income>
    {
        public void Configure(EntityTypeBuilder<Income> builder)
        {

            // Relación con Employee (muchos a uno)
            builder.HasOne<Employee>(i => i.Employee)
                   .WithMany()  // No especificamos la propiedad de navegación en Employee
                   .HasForeignKey(i => i.EmployeeId)
                   .IsRequired();
            // Relación con Payroll (uno a uno o muchos a uno, según el diseño)
            builder.HasOne<Payroll>(i => i.Payroll)
                   .WithMany(p => p.Incomes)
                   .HasForeignKey(i => i.PayrollId)
                   .IsRequired();
        }
    }
}
