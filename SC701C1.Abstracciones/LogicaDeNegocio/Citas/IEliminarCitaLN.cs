
namespace SC701C1.Abstracciones.LogicaDeNegocio.Citas
{
    public interface IEliminarCitaLN
    {
        Task<CustomResponse<bool>> Eliminar(string idCita);
    }
}
