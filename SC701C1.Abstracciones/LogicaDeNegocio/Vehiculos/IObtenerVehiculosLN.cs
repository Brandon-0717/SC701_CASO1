
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.Abstracciones.LogicaDeNegocio.Vehiculos
{
    public interface IObtenerVehiculosLN
    {
        Task<CustomResponse<List<VehiculoDTO>>> Obtener();
    }
}
