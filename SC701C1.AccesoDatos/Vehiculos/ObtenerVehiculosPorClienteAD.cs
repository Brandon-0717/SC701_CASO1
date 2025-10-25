using SC701C1.Abstracciones.AccesoDatos.Vehiculos;
using SC701C1.Abstracciones.Modelos;
using SC701C1.AccesoDatos.Repositorios;

namespace SC701C1.AccesoDatos.Vehiculos
{
    internal class ObtenerVehiculosPorClienteAD : IObtenerVehiculosPorClienteAD
    {
        public Task<List<VehiculoAD>> Obtener(int clienteId)
        {
            List<VehiculoAD> lista = VehiculoRepositorio.vehiculos.Where(v => v.PropietarioId == clienteId).ToList();
            return Task.FromResult(lista);
        }
    }
}
