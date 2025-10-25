
using SC701C1.Abstracciones.AccesoDatos.Vehiculos;
using SC701C1.Abstracciones.Modelos;
using SC701C1.AccesoDatos.Repositorios;

namespace SC701C1.AccesoDatos.Vehiculos
{
    public class CrearVehiculoAD : ICrearVehiculoAD
    {
        public Task<bool> Crear(VehiculoAD vehiculo)
        {
            VehiculoRepositorio.vehiculos.Add(vehiculo);
            return Task.FromResult(true);
        }
    }
}
