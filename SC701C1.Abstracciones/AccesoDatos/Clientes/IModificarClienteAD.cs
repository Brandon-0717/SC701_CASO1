
using SC701C1.Abstracciones.Modelos;

namespace SC701C1.Abstracciones.AccesoDatos.Clientes
{
    public interface IModificarClienteAD
    {
        Task<bool> Modificar(ClienteAD cliente);
    }
}
