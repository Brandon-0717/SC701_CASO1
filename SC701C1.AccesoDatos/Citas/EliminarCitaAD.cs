
using SC701C1.Abstracciones.AccesoDatos.Citas;
using SC701C1.AccesoDatos.Repositorios;

namespace SC701C1.AccesoDatos.Citas
{
    public class EliminarCitaAD : IEliminarCitaAD
    {
        public Task<bool> Eliminar(string idCita)
        {
            bool eliminado = CitaRepositorio.citas.RemoveAll(c => c.CitaId.Equals(idCita)) > 0;
            return Task.FromResult(eliminado);
        }
    }
}
