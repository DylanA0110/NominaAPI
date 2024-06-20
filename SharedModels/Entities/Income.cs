using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Entidades
{
    public class Income
    {
        public int Id { get; set; }
        public decimal OrdinarySalary { get; set; }
        public decimal Seniority { get; set; }
        public decimal OccupationalRisk { get; set; }
        public decimal NightShift { get; set; }
        public int PayrollId { get; set; }
        public Payroll? Payroll { get; set; }
    }
}
