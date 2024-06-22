using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El número de empleado es requerido.")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "El número de empleado debe tener 4 dígitos.")]
        public string EmployeeNumber { get; set; } = null!;

        [Required(ErrorMessage = "El número de identificación es requerido.")]
        [RegularExpression(@"^\d{3}-\d{6}-\d{4}[A-Z]$", ErrorMessage = "El formato de la cédula no es válido.")]
        public string IdentificationNumber { get; set; } = null!;

        [Required(ErrorMessage = "El número de INSS es requerido.")]
        [RegularExpression(@"^\d{7}-\d{1}$", ErrorMessage = "El formato del número INSS no es válido.")]
        public string INSSNumber { get; set; } = null!;

        [Required(ErrorMessage = "El número de RUC es requerido.")]
        public string RUCNumber { get; set; } = null!;

        [Required(ErrorMessage = "El primer nombre es requerido.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "El nombre debe contener solo letras.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres.")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "El segundo nombre es requerido.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "El segundo nombre debe contener solo letras.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El segundo nombre debe tener entre 3 y 50 caracteres.")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "La fecha de nacimiento es requerida.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "El género es requerido.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "El género debe contener solo letras.")]
        public string Gender { get; set; } = null!;

        [Required(ErrorMessage = "El estado civil es requerido.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "El estado civil debe contener solo letras.")]
        public string MaritalStatus { get; set; } = null!;

        [Required(ErrorMessage = "La dirección es requerida.")]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = "El teléfono es requerido.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El teléfono debe tener solo 8 dígitos.")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "El celular es requerido.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El celular debe tener solo 8 dígitos.")]
        public string CellPhone { get; set; } = null!;

        [Required(ErrorMessage = "La fecha de contratación es requerida.")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? TerminationDate { get; set; }

        [Required(ErrorMessage = "El estado activo es requerido.")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "El salario ordinario es requerido.")]
        [Range(0, double.MaxValue, ErrorMessage = "El salario ordinario debe ser mayor o igual a 0.")]
        public decimal OrdinarySalary { get; set; }
    }
}
