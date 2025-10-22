
using SC701C1.Abstracciones.Modelos;

namespace SC701C1.AccesoDatos.Repositorios
{
    public class CitaRepositorio
    {
        List<CitaAD> citas = new List<CitaAD>
        {
            new CitaAD
            {
                CitaId = "CITA001",
                FechaCita = DateTime.Now.AddDays(2),
                ClienteId = "101230456",
                VehiculoId = 1,
                Estado = "Programada",
                Atenciones = new List<string> { "Cambio de aceite", "Revisión general" }
            },
            new CitaAD
            {
                CitaId = "CITA002",
                FechaCita = DateTime.Now.AddDays(5),
                ClienteId = "204567891",
                VehiculoId = 2,
                Estado = "Confirmada",
                Atenciones = new List<string> { "Diagnóstico eléctrico", "Actualización de software" }
            },
            new CitaAD
            {
                CitaId = "CITA003",
                FechaCita = DateTime.Now.AddDays(1),
                ClienteId = "305678912",
                VehiculoId = 3,
                Estado = "Pendiente",
                Atenciones = new List<string> { "Inspección de frenos", "Cambio de filtro de aire" }
            }
        };

    }
}
