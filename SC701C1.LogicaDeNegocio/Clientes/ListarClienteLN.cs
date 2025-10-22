
using AutoMapper;
using SC701C1.Abstracciones.AccesoDatos.Clientes;
using SC701C1.Abstracciones.LogicaDeNegocio;
using SC701C1.Abstracciones.LogicaDeNegocio.Clientes;
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.LogicaDeNegocio.Clientes
{
    public class ListarClienteLN : IListarClienteLN
    {

        private readonly IListarClienteAD _listarClienteAD;
        private readonly IMapper _mapper;

        public ListarClienteLN(IListarClienteAD ListarClienteAD, IMapper mapper)
        {
            _listarClienteAD = ListarClienteAD;
            _mapper = mapper;
        }

        public async Task<CustomResponse<List<ClienteDTO>>> Listar()
        {
            var respuesta = new CustomResponse<List<ClienteDTO>>();
            var lista = await _listarClienteAD.Listar();
            respuesta.Data = _mapper.Map<List<ClienteDTO>>(lista);
            return respuesta;
        }
    }
}
