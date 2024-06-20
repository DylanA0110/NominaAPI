using SharedModels.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Interfaces
{
    public interface IPayrollCalculationService
    {
        Payroll CalculatePayroll(Employee employee, DateOnly startDate, DateOnly endDate);
    }
}
