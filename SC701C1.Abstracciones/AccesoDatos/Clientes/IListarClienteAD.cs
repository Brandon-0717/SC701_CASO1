
using SC701C1.Abstracciones.Modelos;

namespace SC701C1.Abstracciones.AccesoDatos.Clientes
{
    public interface IListarClienteAD
    {
        Task<List<ClienteAD>> Listar();
    }
}
