
using SC701C1.Abstracciones.ModelosDTO;

namespace SC701C1.Abstracciones.LogicaDeNegocio.Clientes
{
    public interface IListarClienteLN
    {
        Task<CustomResponse<List<ClienteDTO>>> Listar();
    }
}
