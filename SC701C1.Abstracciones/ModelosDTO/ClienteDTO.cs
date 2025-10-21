
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SC701C1.Abstracciones.ModelosDTO
{
    public class ClienteDTO
    {
        [Required(ErrorMessage = "La identificación es obligatoria")]
        public int Identificacion { get; set; } //ID

        [Required(ErrorMessage = "El tipo de identificación es obligatiorio")]
        [DisplayName("Tipo de Identificación")]
        public string TipoIdentificacion { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El primer apellido es obligatorio")]
        [DisplayName("Primer Apellido")]
        public string PrimerApellido { get; set; }

        [Required(ErrorMessage = "El segundo apellido es obligatorio")]
        [DisplayName("Segundo Apellido")]
        public string SegundoApellido { get; set; }

        [Required(ErrorMessage = "El sexo es obligatorio")]
        public bool Sexo { get; set; }

        [Range(18, int.MaxValue, ErrorMessage = "Debe ser mayor de edad")]
        [Required(ErrorMessage = "La edad es obligatoria")]
        public int Edad { get; set; }

        [Phone(ErrorMessage = "El telefono debe terner formato válido")]
        [Required(ErrorMessage = "El telefono es obligatorio")]
        public string Telefono { get; set; }

        [EmailAddress(ErrorMessage = "Formato inválido")]
        [Required(ErrorMessage = "El correo es obligatorio")]
        public string CorreoElectronico { get; set; }

        [DisplayName("Fecha de Registro")]
        public DateTime FechaRegistro { get; set; }

    }
}
