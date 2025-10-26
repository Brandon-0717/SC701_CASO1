
using SC701C1.Abstracciones.AccesoDatos.Citas;
using SC701C1.Abstracciones.Modelos;
using SC701C1.AccesoDatos.Repositorios;

namespace SC701C1.AccesoDatos.Citas
{
    public class ModificarCitaAD : IModificarCitaAD
    {
        public Task<bool> Modificar(CitaAD cita)
        {
            var citaActual = CitaRepositorio.citas.FirstOrDefault(c => c.CitaId == cita.CitaId);
            citaActual.FechaCita = cita.FechaCita;
            citaActual.Estado = cita.Estado;

            return Task.FromResult(true);//tambien esta mal ;-;
        }
    }
}
