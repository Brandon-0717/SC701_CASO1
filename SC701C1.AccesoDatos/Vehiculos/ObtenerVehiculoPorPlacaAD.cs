
using SC701C1.Abstracciones.AccesoDatos.Vehiculos;
using SC701C1.Abstracciones.Modelos;
using SC701C1.AccesoDatos.Repositorios;

namespace SC701C1.AccesoDatos.Vehiculos
{
    public class ObtenerVehiculoPorPlacaAD : IObtenerVehiculoPorPlacaAD
    {
        public Task<VehiculoAD> Obtener(string placa)
        {
            var vehiculo = VehiculoRepositorio.vehiculos.FirstOrDefault(v => v.Placa == placa);
            return Task.FromResult(vehiculo);
        }
    }
}
