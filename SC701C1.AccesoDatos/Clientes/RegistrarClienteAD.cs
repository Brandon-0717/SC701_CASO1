
using SC701C1.Abstracciones.AccesoDatos.Clientes;
using SC701C1.Abstracciones.Modelos;
using SC701C1.AccesoDatos.Repositorios;

namespace SC701C1.AccesoDatos.Clientes
{
    public class RegistrarClienteAD : IRegistrarClienteAD
    {
        public Task<bool> Registrar(ClienteAD cliente)
        {
            ClienteRepositorio.ListaClientes.Add(cliente);
            return Task.FromResult(true);
        }
    }
}
