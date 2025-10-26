
using SC701C1.Abstracciones.Modelos;

namespace SC701C1.Abstracciones.AccesoDatos.Citas
{
    public interface IObtenerCitaPorIdAD
    {
        Task<CitaAD> Obtener(Guid citaId);
    }
}
