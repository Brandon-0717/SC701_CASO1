
namespace SC701C1.Abstracciones.Modelos
{
    public class ClienteAD
    {
        public int Identificacion { get; set; } //ID

        public string TipoIdentificacion { get; set; } 

        public string Nombre { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public bool Sexo { get; set; } 

        public int Edad { get; set; }

        public string Telefono { get; set; }

        public string CorreoElectronico { get; set; }

        public DateTime FechaRegistro { get; set; }
    }
}