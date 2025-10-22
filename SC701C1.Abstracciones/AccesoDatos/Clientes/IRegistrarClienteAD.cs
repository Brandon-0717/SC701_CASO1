
using SC701C1.Abstracciones.Modelos;

namespace SC701C1.Abstracciones.AccesoDatos.Clientes
{
    public interface IRegistrarClienteAD
    {
        Task<bool> Registrar(ClienteAD cliente); 
    }
}
