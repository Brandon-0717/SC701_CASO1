
using SC701C1.Abstracciones.AccesoDatos.Clientes;
using SC701C1.Abstracciones.ModelosDTO;
using SC701C1.AccesoDatos.Modelos;
using SC701C1.AccesoDatos.Repositorios;

namespace SC701C1.AccesoDatos.Clientes
{
    public class ListarClienteAD : IListarClienteAD
    {

        public Task<List<ClienteDTO>> Listar() //PUEDE ROMPER SOLID
        {
            List<ClienteDTO> lista = new List<ClienteDTO>();

            foreach(ClienteAD c in ClienteRepositorio.ListaClientes)
            {
                lista.Add(new ClienteDTO
                {
                    Identificacion = c.Identificacion,
                    TipoIdentificacion = c.TipoIdentificacion,
                    Nombre = c.Nombre,
                    PrimerApellido= c.PrimerApellido,
                    SegundoApellido= c.SegundoApellido,
                    Sexo = c.Sexo,
                    Edad = c.Edad,
                    Telefono = c.Telefono,
                    CorreoElectronico = c.CorreoElectronico,
                    FechaRegistro = c.FechaRegistro
                });
            }

            return Task.FromResult(lista);
        }
  
    }
}
