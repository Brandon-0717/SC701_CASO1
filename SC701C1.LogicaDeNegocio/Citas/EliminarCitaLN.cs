
using SC701C1.Abstracciones.AccesoDatos.Citas;
using SC701C1.Abstracciones.LogicaDeNegocio;
using SC701C1.Abstracciones.LogicaDeNegocio.Citas;

namespace SC701C1.LogicaDeNegocio.Citas
{
    public class EliminarCitaLN : IEliminarCitaLN
    {
        private readonly IEliminarCitaAD _eliminarCitaAD;

        public EliminarCitaLN(IEliminarCitaAD eliminarCitaAD)
        {
            _eliminarCitaAD = eliminarCitaAD;
        }

        public async Task<CustomResponse<bool>> Eliminar(string idCita)
        {
            var response = new CustomResponse<bool>();
            bool eliminado = await _eliminarCitaAD.Eliminar(idCita);

            if (eliminado)
            {
                response.Mensaje = "Cita eliminada correctamente.";
                return response;
            }
            else
            {
                response.Mensaje = "No se pudo eliminar la cita.";
                response.EsError = true;
                return response;
            }
        }
    }
}
