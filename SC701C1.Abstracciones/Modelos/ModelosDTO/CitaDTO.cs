
using System.ComponentModel.DataAnnotations;

namespace SC701C1.Abstracciones.Modelos.ModelosDTO
{
    public class CitaDTO
    {
        public string CitaId { get; set; }

        [Required(ErrorMessage = "La fecha de la cita es obligatoria")]
        [DataType(DataType.DateTime)]
        public DateTime FechaCita { get; set; }

        [Required(ErrorMessage = "El cliente es obligatorio")]
        public string ClienteId { get; set; }

        [Required(ErrorMessage = "El vehículo es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del vehículo debe ser mayor que cero")]
        public int VehiculoId { get; set; }

        [Required(ErrorMessage = "El estado de la cita es obligatorio")]
        [RegularExpression("^(Ingresada|Cancelada|Concluida)$", ErrorMessage = "Estado inválido")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Debe especificar al menos una atención")]
        [MinLength(1, ErrorMessage = "Debe haber al menos una atención registrada")]
        public List<string> Atenciones { get; set; }

    }
}
