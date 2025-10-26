
using SC701C1.Abstracciones.AccesoDatos.Vehiculos;
using SC701C1.AccesoDatos.Repositorios;

namespace SC701C1.AccesoDatos.Vehiculos
{
    public class ValidarExistenciaPlacaAD : IValidarExistenciaPlacaAD
    {
        public Task<bool> Validar(string placa)
        {
            return Task.FromResult(VehiculoRepositorio.vehiculos.Any(v => v.Placa.Equals(placa)));
        }
    }
}
