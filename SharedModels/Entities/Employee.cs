using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Entidades
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeNumber { get; set; } = null!;
        public string IdentificationNumber { get; set; } = null!;
        public string INSSNumber { get; set; } = null!;
        public string RUCNumber { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public string MaritalStatus { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string CellPhone { get; set; } = null!;
        public DateOnly HireDate { get; set; }
        public DateOnly? TerminationDate { get; set; }
        public bool IsActive { get; set; }
        public decimal OrdinarySalary { get; set; }
        public ICollection<Payroll>? Payrolls { get; set; }
       
    }
}
