
using SC701C1.Abstracciones.Modelos;

namespace SC701C1.Abstracciones.AccesoDatos.Vehiculos
{
    public interface IObtenerVehiculosPorClienteAD
    {
        Task<List<VehiculoAD>> Obtener(int clienteId);
    }
}
