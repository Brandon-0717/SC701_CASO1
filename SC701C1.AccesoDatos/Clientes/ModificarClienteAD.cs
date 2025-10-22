
using SC701C1.Abstracciones.AccesoDatos.Clientes;
using SC701C1.Abstracciones.Modelos;
using SC701C1.AccesoDatos.Repositorios;

namespace SC701C1.AccesoDatos.Clientes
{
    public class ModificarClienteAD : IModificarClienteAD
    {
        public Task<bool> Modificar(ClienteAD cliente)
        {
            ClienteAD clienteActual = ClienteRepositorio.ListaClientes.FirstOrDefault(c => c.Identificacion == cliente.Identificacion);
            clienteActual.Nombre = cliente.Nombre;
            clienteActual.PrimerApellido = cliente.PrimerApellido;
            clienteActual.SegundoApellido = cliente.SegundoApellido;
            clienteActual.Sexo = cliente.Sexo;
            clienteActual.Edad = cliente.Edad;
            clienteActual.Telefono = cliente.Telefono;
            clienteActual.CorreoElectronico = cliente.CorreoElectronico;
            return Task.FromResult(true);
        }
    }
}
