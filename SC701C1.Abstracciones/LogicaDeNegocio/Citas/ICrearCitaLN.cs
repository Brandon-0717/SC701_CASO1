
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.Abstracciones.LogicaDeNegocio.Citas
{
    public interface ICrearCitaLN
    {
        Task<CustomResponse<CitaDTO>> Crear(CitaDTO citaDTO);
    }
}
