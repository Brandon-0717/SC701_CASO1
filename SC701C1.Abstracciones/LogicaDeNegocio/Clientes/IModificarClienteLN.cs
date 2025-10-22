
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.Abstracciones.LogicaDeNegocio.Clientes
{
    public interface IModificarClienteLN
    {
        Task<CustomResponse<ClienteDTO>> Modificar(ClienteDTO cliente);
    }
}
