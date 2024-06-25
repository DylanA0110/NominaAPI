using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dto
{
    public class IncomeCreateDTO
    {
        [Required(ErrorMessage = "El salario ordinario es obligatorio.")]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "El salario ordinario debe ser mayor o igual a cero.")]
        public decimal OrdinarySalary { get; set; }

        [Required(ErrorMessage = "La antigüedad es obligatoria.")]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "La antigüedad debe ser mayor o igual a cero.")]
        public decimal Seniority { get; set; }

        [Required(ErrorMessage = "El riesgo laboral es obligatorio.")]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "El riesgo laboral debe ser mayor o igual a cero.")]
        public decimal OccupationalRisk { get; set; }

        [Required(ErrorMessage = "El turno nocturno es obligatorio.")]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "El turno nocturno debe ser mayor o igual a cero.")]
        public decimal NightShift { get; set; }

        [Required(ErrorMessage = "Las horas extras son obligatorias.")]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Las horas extras deben ser mayor o igual a cero.")]
        public decimal Overtime { get; set; }

        [Required(ErrorMessage = "El ID de la nomina es requerido")]
        public int PayrollId { get; set; }
    }
}
