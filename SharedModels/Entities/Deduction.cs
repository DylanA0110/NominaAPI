using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Entidades
{
    public class Deduction
    {
        public int Id { get; set; }
        public decimal INSS { get; set; }
        public decimal IR { get; set; }
        public int PayrollId { get; set; }
        public Payroll? Payroll { get; set; }
    }
}
