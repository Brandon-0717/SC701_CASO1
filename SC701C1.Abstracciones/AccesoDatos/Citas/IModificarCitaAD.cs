
using SC701C1.Abstracciones.Modelos;

namespace SC701C1.Abstracciones.AccesoDatos.Citas
{
    public interface IModificarCitaAD
    {
        Task<bool> Modificar(CitaAD cita);
    }
}
