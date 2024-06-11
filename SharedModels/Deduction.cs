using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class Deduction
    {
        public int DeductionId { get; set; }
        public int EmployeeId { get; set; } 


        public Employee? Employee { get; set; }
    }
}
