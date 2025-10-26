
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.Abstracciones.LogicaDeNegocio.Citas
{
    public interface IObtenerCitaPorIdLN
    {
        Task<CustomResponse<CitaDTO>> Obtener(Guid citaId);
    }
}
