
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.Abstracciones.LogicaDeNegocio.Clientes
{
    public interface IListarClienteLN
    {
        Task<CustomResponse<List<ClienteDTO>>> Listar();
    }
}
