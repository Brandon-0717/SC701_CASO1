
using SC701C1.Abstracciones.AccesoDatos.Vehiculos;
using SC701C1.Abstracciones.Modelos;
using SC701C1.AccesoDatos.Repositorios;

namespace SC701C1.AccesoDatos.Vehiculos
{
    public class ObtenerVehiculosAD : IObtenerVehiculosAD
    {
        public Task<List<VehiculoAD>> Obtener()
        {
            return Task.FromResult(VehiculoRepositorio.vehiculos);
        } 
    }
}
