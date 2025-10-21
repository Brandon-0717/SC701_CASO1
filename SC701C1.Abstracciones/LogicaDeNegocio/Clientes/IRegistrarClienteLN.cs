
using SC701C1.Abstracciones.ModelosDTO;

namespace SC701C1.Abstracciones.LogicaDeNegocio.Clientes
{
    public interface IRegistrarClienteLN
    {
        Task<CustomResponse<ClienteDTO>> Regisrar(ClienteDTO cliente);
    }
}
