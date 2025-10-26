
using SC701C1.Abstracciones.AccesoDatos.Citas;
using SC701C1.Abstracciones.Modelos;
using SC701C1.AccesoDatos.Repositorios;

namespace SC701C1.AccesoDatos.Citas
{
    public class ObtenerCitaPorIdAD : IObtenerCitaPorIdAD
    {
        public Task<CitaAD> Obtener(Guid citaId)
        {
            return Task.FromResult(CitaRepositorio.citas.FirstOrDefault(c => c.CitaId == citaId));
        }
    }
}
