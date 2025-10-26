
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.Abstracciones.LogicaDeNegocio.Citas
{
    public interface IListarCitaLN
    {
        Task<CustomResponse<List<CitaDTO>>> Listar();
    }
}
