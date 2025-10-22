
using SC701C1.Abstracciones.AccesoDatos.Clientes;
using SC701C1.AccesoDatos.Repositorios;

namespace SC701C1.AccesoDatos.Clientes
{
    public class EliminarClienteAD : IEliminarClienteAD
    {
        public Task<bool> Eliminar(int identificacion)
        {
            bool eliminado = ClienteRepositorio.ListaClientes.RemoveAll(c => c.Identificacion == identificacion) > 0;
            return Task.FromResult(eliminado);
        }
    }
}
