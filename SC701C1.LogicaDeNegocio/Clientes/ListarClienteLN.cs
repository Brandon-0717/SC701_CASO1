
using SC701C1.Abstracciones.AccesoDatos.Clientes;
using SC701C1.Abstracciones.LogicaDeNegocio;
using SC701C1.Abstracciones.LogicaDeNegocio.Clientes;
using SC701C1.Abstracciones.ModelosDTO;

namespace SC701C1.LogicaDeNegocio.Clientes
{
    public class ListarClienteLN : IListarClienteLN
    {

        private IListarClienteAD _listarClienteAD;

        public ListarClienteLN(IListarClienteAD ListarClienteAD)
        {
            _listarClienteAD = ListarClienteAD;
        }

        public async Task<CustomResponse<List<ClienteDTO>>> Listar()
        {
            var respuesta = new CustomResponse<List<ClienteDTO>>();
            var lista = await _listarClienteAD.Listar();
            respuesta.Data = lista;
            return respuesta;
        }
    }
}
