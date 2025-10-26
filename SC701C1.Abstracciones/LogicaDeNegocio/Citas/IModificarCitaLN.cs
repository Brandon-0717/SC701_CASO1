
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.Abstracciones.LogicaDeNegocio.Citas
{
    public interface IModificarCitaLN
    {
        Task<CustomResponse<CitaDTO>> Modificar(CitaDTO cita);
    }
}
