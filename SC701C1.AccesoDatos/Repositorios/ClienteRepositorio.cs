

using SC701C1.Abstracciones.Modelos;

namespace SC701C1.AccesoDatos.Repositorios
{
     internal static class ClienteRepositorio
    {
        #region Datos Quemados
        internal static List<ClienteAD> ListaClientes = new List<ClienteAD>
        {
            new ClienteAD
            {
                Identificacion = 101230456,
                TipoIdentificacion = "FISICA NACIONAL",
                Nombre = "Laura",
                PrimerApellido = "González",
                SegundoApellido = "Mora",
                Sexo = false,
                Edad = 32,
                Telefono = "8888-1234",
                CorreoElectronico = "laura.gm@example.com",
                FechaRegistro = DateTime.Now.AddDays(-15)
            },
            new ClienteAD
            {
                Identificacion = 204567891,
                TipoIdentificacion = "DIMEX",
                Nombre = "Carlos",
                PrimerApellido = "Ramírez",
                SegundoApellido = "Vargas",
                Sexo = true,
                Edad = 45,
                Telefono = "8999-5678",
                CorreoElectronico = "carlos.rv@example.com",
                FechaRegistro = DateTime.Now.AddDays(-30)
            },
            new ClienteAD
            {
                Identificacion = 305678912,
                TipoIdentificacion = "JURIDICA",
                Nombre = "Empresa XYZ",
                PrimerApellido = "",
                SegundoApellido = "",
                Sexo = true,
                Edad = 0,
                Telefono = "2222-0000",
                CorreoElectronico = "contacto@xyzcorp.com",
                FechaRegistro = DateTime.Now.AddDays(-5)
            }
        };
        #endregion
    }
}
