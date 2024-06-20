using SharedModels.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Interfaces
{
    public interface IIncomeCalculationService
    {
        decimal CalculateOrdinarySalary(Employee employee);
        decimal CalculateSeniority(Employee employee);
        decimal CalculateOccupationalRisk(Employee employee);
        decimal CalculateNightShift(Employee employee);
    }
}
