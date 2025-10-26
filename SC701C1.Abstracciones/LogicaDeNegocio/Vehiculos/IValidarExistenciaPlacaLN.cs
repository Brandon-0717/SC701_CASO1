
namespace SC701C1.Abstracciones.LogicaDeNegocio.Vehiculos
{
    public interface IValidarExistenciaPlacaLN
    {
        Task<CustomResponse<bool>> Validar(string placa);
    }
}
