
using SC701C1.Abstracciones.Modelos;

namespace SC701C1.Abstracciones.AccesoDatos.Vehiculos
{
    public interface ICrearVehiculoAD
    {
        Task<bool> Crear(ClienteAD cliente);
    }
}
