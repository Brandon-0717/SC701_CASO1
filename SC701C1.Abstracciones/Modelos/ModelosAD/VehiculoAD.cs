
namespace SC701C1.Abstracciones.Modelos
{
    public class VehiculoAD
    {
        public string Placa { get; set; } //ID

        public string Marca { get; set; }

        public int Anio { get; set; }

        public string Modelo { get; set; }

        public int Kilometraje { get; set; }

        public double Peso { get; set; }

        public double CapacidadCombustible { get; set; }

        public string Color { get; set; }

        public bool VehiculoElectrico { get; set; }

        public bool TransmisionManual { get; set; }

        public int PropietarioId { get; set; } //FK

        public DateTime FechaRegistro { get; set; }
    }
}
