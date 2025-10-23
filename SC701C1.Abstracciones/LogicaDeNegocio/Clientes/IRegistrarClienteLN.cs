
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.Abstracciones.LogicaDeNegocio.Clientes
{
    public interface IRegistrarClienteLN
    {
        Task<CustomResponse<ClienteDTO>> Registrar(ClienteDTO cliente);
    }
}
