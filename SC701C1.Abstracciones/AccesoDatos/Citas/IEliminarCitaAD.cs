
namespace SC701C1.Abstracciones.AccesoDatos.Citas
{
    public interface IEliminarCitaAD
    {
        Task<bool> Eliminar(string idCita);
    }
}
