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
        private readonly IIncomeCalculationService _incomeCalculationService;
        private readonly IDeductionCalculationService _deductionCalculationService;

        public PayrollService(IIncomeCalculationService incomeCalculationService, IDeductionCalculationService deductionCalculationService)
        {
            _incomeCalculationService = incomeCalculationService;
            _deductionCalculationService = deductionCalculationService;
        }

        public Payroll CalculatePayroll(Employee employee, DateOnly startDate, DateOnly endDate, int overTimeHours)
        {
            Payroll payroll = new Payroll
            {
                EmployeeId = employee.Id,
                StartDate = startDate,
                EndDate = endDate,
                Employee = employee,
                Incomes = new List<Income>(),
                Deductions = new List<Deduction>()
            };

            // Calcular ingresos
            decimal nightShift = _incomeCalculationService.CalculateNightShift(employee);
            decimal occupationalRisk = _incomeCalculationService.CalculateOccupationalRisk(employee);
            decimal overTime = _incomeCalculationService.CalculateOverTime(employee, overTimeHours); // Ejemplo: 10 horas extra
            decimal seniority = _incomeCalculationService.CalculateSeniority(employee);
            decimal ordinarySalary = employee.OrdinarySalary;

            Income income = new Income
            {
                OrdinarySalary = ordinarySalary,
                Seniority = seniority,
                OccupationalRisk = occupationalRisk,
                NightShift = nightShift,
                Overtime = overTime,
                Payroll = payroll
            };

            payroll.Incomes.Add(income);

            decimal totalIncomes = ordinarySalary + nightShift + occupationalRisk + overTime + seniority;

            // Calcular deducciones
            decimal INSS = _deductionCalculationService.CalculateINSS(totalIncomes);
            decimal IR = _deductionCalculationService.CalculateIR(totalIncomes);

            Deduction deduction = new Deduction
            {
                INSS = INSS,
                IR = IR,
                Payroll = payroll
            };

            payroll.Deductions.Add(deduction);

            decimal totalDeductions = INSS + IR;

            // Calcular salario neto
            payroll.NetSalary = totalIncomes - totalDeductions;

            return payroll;
        }
    }
}

