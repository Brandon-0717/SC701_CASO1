using SC701C1.Abstracciones.Modelos;

namespace SC701C1.Abstracciones.AccesoDatos.Vehiculos
{
    public interface IObtenerVehiculoPorPlacaAD
    {
        Task<VehiculoAD> Obtener(string placa);
    }
}
