
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.Abstracciones.LogicaDeNegocio.Vehiculos
{
    public interface IEliminarVehiculoLN
    {
        Task<CustomResponse<VehiculoDTO>> Eliminar(string placa);
    }
}
