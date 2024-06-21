using SharedModels.Entidades;
using SharedModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Services
{
    public class PayrollService : IPayrollCalculationService
    {
        public Payroll CalculatePayroll(Employee employee, DateOnly startDate, DateOnly endDate)
        {
            throw new NotImplementedException();
        }
    }
}
