
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.Abstracciones.LogicaDeNegocio.Clientes
{
    public interface IEliminarClienteLN
    {
        Task<CustomResponse<ClienteDTO>> Eliminar(int identificacion);
    }
}
