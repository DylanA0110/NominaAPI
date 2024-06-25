using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Dto
{
    public class DeductionDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El monto de INSS es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El monto de INSS debe ser mayor o igual a cero.")]
        public decimal INSS { get; set; }

        [Required(ErrorMessage = "El monto de IR es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El monto de IR debe ser mayor o igual a cero.")]
        public decimal IR { get; set; }

        [Required(ErrorMessage = "El ID de la nomina es requerido")]
        public int PayrollId { get; set; }
    }
}
