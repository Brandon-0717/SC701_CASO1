
namespace SC701C1.Abstracciones.AccesoDatos.Vehiculos
{
    public interface IEliminarVehiculoAD
    {
        Task<bool> Eliminar(string placa);
    }
}
