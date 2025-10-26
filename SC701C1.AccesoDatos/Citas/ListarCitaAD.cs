
using SC701C1.Abstracciones.AccesoDatos.Citas;
using SC701C1.Abstracciones.Modelos;
using SC701C1.AccesoDatos.Repositorios;

namespace SC701C1.AccesoDatos.Citas
{
    public class ListarCitaAD : IListarCitaAD
    {
        public Task<List<CitaAD>> Listar()
        {
            return Task.FromResult(CitaRepositorio.citas);
        }
    }
}
