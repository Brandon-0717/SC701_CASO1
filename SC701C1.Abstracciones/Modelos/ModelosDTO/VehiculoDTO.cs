
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SC701C1.Abstracciones.Modelos.ModelosDTO
{
    public class VehiculoDTO
    {
        [Required(ErrorMessage = "La placa es obligatoria")]
        public string Placa { get; set; } // ID

        [Required(ErrorMessage = "La marca es obligatoria")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "El año es obligatorio")]
        [Range(1900, 2100, ErrorMessage = "El año debe estar entre 1900 y 2100")]
        [DisplayName("Año")]
        public int Anio { get; set; }

        [Required(ErrorMessage = "El modelo es obligatorio")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "El kilometraje es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "El kilometraje debe ser un número positivo")]
        [DisplayName("Kilometraje")]
        public int Kilometraje { get; set; }

        [Required(ErrorMessage = "El peso es obligatorio")]
        [Range(500, 10000, ErrorMessage = "El peso debe estar entre 500 y 10,000 kg")]
        [DisplayName("Peso (Kg)")]
        public double Peso { get; set; }

        [Required(ErrorMessage = "La capacidad de combustible es obligatoria")]
        [Range(0, 200, ErrorMessage = "La capacidad debe estar entre 0 y 200 litros")]
        [DisplayName("Capacidad de Combustible (L)")]
        public double CapacidadCombustible { get; set; }

        [Required(ErrorMessage = "El color es obligatorio")]
        [DisplayName("Color")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Debe indicar si el vehículo es eléctrico")]
        [DisplayName("Vehiculo Electrico")]
        public bool VehiculoElectrico { get; set; }

        [Required(ErrorMessage = "Debe indicar si la transmisión es manual")]
        [DisplayName("Transmision Manual")]
        public bool TransmisionManual { get; set; }

        [Required(ErrorMessage = "El propietario es obligatorio")]
        [DisplayName("Propietario")]
        public int PropietarioId { get; set; } // FK

        public string? NombrePropietario { get; set; } // FK

        [DisplayName("Fecha de Registro")]
        public DateTime FechaRegistro { get; set; }

    }
}
