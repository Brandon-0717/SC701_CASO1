
using SC701C1.Abstracciones.AccesoDatos.Vehiculos;
using SC701C1.AccesoDatos.Repositorios;

namespace SC701C1.AccesoDatos.Vehiculos
{
    public class EliminarVehiculoAD : IEliminarVehiculoAD
    {
        public Task<bool> Eliminar(string placa)
        {
            bool eliminado = VehiculoRepositorio.vehiculos.RemoveAll(p => p.Placa.Equals(placa)) > 0;
            return Task.FromResult(eliminado);
        }
    }
}
