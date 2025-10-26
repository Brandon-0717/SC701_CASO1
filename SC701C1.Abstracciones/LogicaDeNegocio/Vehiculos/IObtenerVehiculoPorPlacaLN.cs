
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.Abstracciones.LogicaDeNegocio.Vehiculos
{
    public interface IObtenerVehiculoPorPlacaLN
    {
        Task<CustomResponse<VehiculoDTO>> Obtener(string placa);
    }
}
