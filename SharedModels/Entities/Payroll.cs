using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Entidades
{
    public class Payroll
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public decimal NetSalary { get; set; }

        public Employee? Employee { get; set; }
        public List<Income>? Incomes { get; set; }
        public List<Deduction>? Deductions { get; set; }
    }
}
