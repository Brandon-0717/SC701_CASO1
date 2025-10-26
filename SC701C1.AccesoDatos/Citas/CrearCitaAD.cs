
using SC701C1.Abstracciones.AccesoDatos.Citas;
using SC701C1.Abstracciones.Modelos;
using SC701C1.AccesoDatos.Repositorios;

namespace SC701C1.AccesoDatos.Citas
{
    public class CrearCitaAD : ICrearCitaAD
    {
        public Task<bool> Crear(CitaAD cita)
        {
            CitaRepositorio.citas.Add(cita);
            return Task.FromResult(true); //ESTO VA EN TODOS LOS CREAR, LO CUAL
                                          //ES ERRONEO YA QUE SIEMPRE DEVUELVE TRUE AUNQUE NO SE AGREGUE
        }
    }
}
