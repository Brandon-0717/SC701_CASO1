
using SC701C1.Abstracciones.AccesoDatos.Clientes;
using SC701C1.Abstracciones.LogicaDeNegocio;
using SC701C1.Abstracciones.LogicaDeNegocio.Clientes;
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.LogicaDeNegocio.Clientes
{
    public class EliminarClienteLN : IEliminarClienteLN
    {
        private readonly IEliminarClienteAD _eliminarClienteAD;
        public EliminarClienteLN(IEliminarClienteAD eliminarClienteAD)
        {
            _eliminarClienteAD = eliminarClienteAD;
        }

        public async Task<CustomResponse<ClienteDTO>> Eliminar(int identificacion)
        {
            var respuesta = new CustomResponse<ClienteDTO>();

            bool resultado = await _eliminarClienteAD.Eliminar(identificacion);

            if (resultado)
            {
                respuesta.Mensaje = "Cliente eliminado de manera exitosa";
                return respuesta;
            }
            respuesta.EsError = true;
            respuesta.Mensaje = "No se pudo eliminar el cliente";
            return respuesta;
        }
    }
}
