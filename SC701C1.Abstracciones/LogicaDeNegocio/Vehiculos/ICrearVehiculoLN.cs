
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.Abstracciones.LogicaDeNegocio.Vehiculos
{
    public interface ICrearVehiculoLN
    {
        Task<CustomResponse<VehiculoDTO>> Crear(VehiculoDTO vehiculo);
    }
}
