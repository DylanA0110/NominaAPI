using SharedModels.Entidades;
using SharedModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Services
{
    public class IncomeCalculationService : IIncomeCalculationService
    {
        public decimal CalculateNightShift(Employee employee)
        {
            return employee.OrdinarySalary * 0.2m;
        }

        private decimal CalcularSalarioPorHora(decimal ordinarySalary)
        {
            decimal salarioPorDia = ordinarySalary / 30;
            return salarioPorDia / 8;
        }

        public decimal CalculateOccupationalRisk(Employee employee)
        {
            return employee.OrdinarySalary * 0.2m;
        }

        public decimal CalculateOverTime(Employee employee, int overTime)
        {
            if (overTime != 0)
            {
                return CalcularSalarioPorHora(employee.OrdinarySalary) * 2 * overTime;
            }
            else
                return 0;
        }

        public decimal CalculateSeniority(Employee employee)
        {
            if (CalcularYearsTrabajados(employee) > 6)
            {
                return 0;
            }
            if (CalcularYearsTrabajados(employee) < 4)
            {
                decimal antiguedad1 = employee.OrdinarySalary / 12;
                return antiguedad1;
            }
            if (CalcularYearsTrabajados(employee) > 5 || CalcularYearsTrabajados(employee) < 6)
            {
                decimal antiguedad2 = (CalcularSalarioPorDia(employee) * 20) / 12;

                return antiguedad2;
            }

            else
                return 0;
        }

        public int CalcularYearsTrabajados(Employee employee)
        {
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Today);

            int yearsWorked = currentDate.Year - employee.HireDate.Year;

            if (employee.HireDate.DayOfYear > currentDate.DayOfYear)
            {
                yearsWorked--;
            }

            return yearsWorked;
        }

        private decimal CalcularSalarioPorDia(Employee employee)
        {
            return employee.OrdinarySalary / 30;
        }
    }
}
