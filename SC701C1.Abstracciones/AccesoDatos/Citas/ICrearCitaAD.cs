
using SC701C1.Abstracciones.Modelos;

namespace SC701C1.Abstracciones.AccesoDatos.Citas
{
    public interface ICrearCitaAD
    {
        Task<bool> Crear(CitaAD cita);
    }
}
