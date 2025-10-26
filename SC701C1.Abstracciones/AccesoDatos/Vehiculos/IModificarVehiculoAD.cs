
using SC701C1.Abstracciones.Modelos;

namespace SC701C1.Abstracciones.AccesoDatos.Vehiculos
{
    public interface IModificarVehiculoAD
    {
        Task<bool> Modificar(VehiculoAD vehiculo);
    }
}
