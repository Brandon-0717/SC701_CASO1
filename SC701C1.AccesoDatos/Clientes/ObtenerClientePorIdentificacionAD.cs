
using SC701C1.Abstracciones.AccesoDatos.Clientes;
using SC701C1.Abstracciones.Modelos;
using SC701C1.AccesoDatos.Repositorios;

namespace SC701C1.AccesoDatos.Clientes
{
    public class ObtenerClientePorIdentificacionAD : IObtenerClientePorIdentificacionAD
    {
        public Task<ClienteAD> Obtener(int identificacion)
        {
            ClienteAD cliente = ClienteRepositorio.ListaClientes.FirstOrDefault(c => c.Identificacion == identificacion);

            return Task.FromResult(cliente);
        }
    }
}
