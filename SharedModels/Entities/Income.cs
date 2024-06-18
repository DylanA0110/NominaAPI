using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Entidades
{
    public class Income
    {
        public int IncomeId { get; set; }
        public int EmployeeId { get; set; }
        public int PayrollId { get; set; }
        public decimal OrdinarySalary { get; set; }
        public decimal Seniority { get; set; }
        public decimal OccupationalRisk { get; set; }
        public decimal NightShift { get; set; }

        public Employee? Employee { get; set; }
        public Payroll? Payroll { get; set; }

    }
}
