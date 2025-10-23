
namespace SC701C1.Abstracciones.AccesoDatos.Clientes
{
    public interface IValidarExistenciaAD
    {
        Task<bool> ValidarExistencia(int identificacion);
    }
}
