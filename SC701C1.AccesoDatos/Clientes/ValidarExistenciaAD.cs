
using SC701C1.Abstracciones.AccesoDatos.Clientes;
using SC701C1.AccesoDatos.Repositorios;

namespace SC701C1.AccesoDatos.Clientes
{
    public class ValidarExistenciaAD : IValidarExistenciaAD
    {
        public Task<bool> ValidarExistencia(int identificacion)
        {
            return Task.FromResult(ClienteRepositorio.ListaClientes.Any(c => c.Identificacion == identificacion));
        }
    }
}
