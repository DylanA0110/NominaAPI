using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class Payroll
    {
        public int PayrollId { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public decimal OrdinaryIncome { get; set; }
        public decimal ExtraordinaryIncome { get; set; }
        public decimal RiskAllowance { get; set; }
        public decimal NightShiftAllowance { get; set; }
        public decimal INSS { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal OtherDeductions { get; set; }
        public decimal NetSalary { get; set; }
    }
}
