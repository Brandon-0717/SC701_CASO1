
namespace SC701C1.AccesoDatos.Modelos
{
    public class CitaAD
    {
        public string CitaId { get; set; }

        public DateTime FechaCita { get; set; }

        public string ClienteId { get; set; }

        public int VehiculoId { get; set; }

        public string Estado { get; set; }

        public List<String> Atenciones { get; set; }

    }
}
