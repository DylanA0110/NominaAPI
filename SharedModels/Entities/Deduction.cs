using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Entidades
{
    public class Deduction
    {
        public int DeductionId { get; set; }
        public int EmployeeId { get; set; }
        public decimal INSS { get; set; }
        public decimal IR { get; set; }
        public Employee? Employee { get; set; }
    }
}
