
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.Abstracciones.LogicaDeNegocio.Vehiculos
{
    public interface IModificarVehiculoLN
    {
        Task<CustomResponse<bool>> Modificar(VehiculoDTO vehiculo);
    }
}
