
namespace SC701C1.Abstracciones.AccesoDatos.Vehiculos
{
    public interface IValidarExistenciaPlacaAD
    {
        Task<bool> Validar(string placa);
    }
}
