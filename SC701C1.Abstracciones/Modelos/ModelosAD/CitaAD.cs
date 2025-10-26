
namespace SC701C1.Abstracciones.Modelos
{
    public class CitaAD
    {
        public string CitaId { get; set; }

        public DateTime FechaCita { get; set; }

        public int ClienteId { get; set; }

        public string VehiculoId { get; set; }

        public string Estado { get; set; }

        public List<String> Atenciones { get; set; }

    }
}
