
using SC701C1.Abstracciones.ModelosDTO;

namespace SC701C1.Abstracciones.AccesoDatos.Clientes
{
    public interface IListarClienteAD
    {
        Task<List<ClienteDTO>> Listar();
    }
}
