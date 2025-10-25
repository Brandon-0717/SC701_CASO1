using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.Abstracciones.LogicaDeNegocio.Vehiculos
{
    public interface IObtenerVehiculosPorClienteLN
    {
        Task<CustomResponse<List<VehiculoDTO>>> Obtener(int clienteId);
    }
}
