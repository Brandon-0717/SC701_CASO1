
namespace SC701C1.Abstracciones.AccesoDatos.Clientes
{
    public interface IEliminarClienteAD
    {
        Task<bool> Eliminar(int identificacion);
    }
}
