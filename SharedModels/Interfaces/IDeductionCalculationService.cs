using SharedModels.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Interfaces
{
    public interface IDeductionCalculationService
    {
        decimal CalculateINSS(decimal totalINgresos);
        decimal CalculateIR(decimal totalINgresos);
    }
}
