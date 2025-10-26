
using SC701C1.Abstracciones.Modelos;

namespace SC701C1.AccesoDatos.Repositorios
{
    public static class CitaRepositorio
    {
        internal static List<CitaAD> citas = new List<CitaAD>
        {
            new CitaAD
            {
                CitaId = Guid.NewGuid(),
                FechaCita = DateTime.Now.AddDays(2),
                ClienteId = 101230456,
                VehiculoId = "ABC123",
                Estado = "Programada",
                Atenciones = new List<string> { "Cambio de aceite", "Revisión general" }
            },
            new CitaAD
            {
                CitaId = Guid.NewGuid(),
                FechaCita = DateTime.Now.AddDays(5),
                ClienteId = 204567891,
                VehiculoId = "XYZ789",
                Estado = "Confirmada",
                Atenciones = new List<string> { "Diagnóstico eléctrico", "Actualización de software" }
            },
            new CitaAD
            {
                CitaId = Guid.NewGuid(),
                FechaCita = DateTime.Now.AddDays(1),
                ClienteId = 305678912,
                VehiculoId = "LMN456",
                Estado = "Pendiente",
                Atenciones = new List<string> { "Inspección de frenos", "Cambio de filtro de aire" }
            }
        };

    }
}
