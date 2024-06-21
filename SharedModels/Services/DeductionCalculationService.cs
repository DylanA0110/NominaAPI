using SharedModels.Entidades;
using SharedModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Services
{
    public class DeductionCalculationService : IDeductionCalculationService
    {
        public decimal CalculateINSS(decimal totalINgresos)
        {
            return totalINgresos * 0.07m;
        }

        public decimal CalculateIR(decimal totalINgresos)
        {
            decimal ingresoAnual = totalINgresos * 12;

            decimal IR = 0;

            if (ingresoAnual > 500000.01m)
            {
                decimal calculo3 = (ingresoAnual - 500000m) * 0.30m;
                IR = (calculo3 + 82500m) / 12;
            }
            else if (ingresoAnual >= 350000.01m)
            {
                decimal calculo2 = (ingresoAnual - 350000m) * 0.25m;
                IR = (calculo2 + 45000m) / 12;
            }
            else if (ingresoAnual >= 200000.01m)
            {
                decimal calculo1 = (ingresoAnual - 200000m) * 0.2m;
                IR = (calculo1 + 15000m) / 12;
            }
            else if (ingresoAnual >= 100000.01m)
            {
                decimal sobreexceso1 = 100000m;
                decimal totalDeducir1 = ingresoAnual - sobreexceso1;
                IR = (totalDeducir1 * 0.15m) / 12;
            }

            return IR;//De forma mensual
        }

    }
}
