
using SC701C1.Abstracciones.AccesoDatos.Clientes;
using SC701C1.Abstracciones.Modelos;
using SC701C1.AccesoDatos.Repositorios;

namespace SC701C1.AccesoDatos.Clientes
{
    public class ListarClienteAD : IListarClienteAD
    {
        public Task<List<ClienteAD>> Listar()
        {
            return Task.FromResult(ClienteRepositorio.ListaClientes);
        }
    }
}
