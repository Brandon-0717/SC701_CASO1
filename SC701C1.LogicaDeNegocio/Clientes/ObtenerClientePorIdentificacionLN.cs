
using AutoMapper;
using SC701C1.Abstracciones.AccesoDatos.Clientes;
using SC701C1.Abstracciones.LogicaDeNegocio;
using SC701C1.Abstracciones.LogicaDeNegocio.Clientes;
using SC701C1.Abstracciones.Modelos;
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.LogicaDeNegocio.Clientes
{
    public class ObtenerClientePorIdentificacionLN : IObtenerClientePorIdentificacionLN
    {
        private readonly IObtenerClientePorIdentificacionAD _ObtenerClientePorIdentificacionAD;
        private readonly IMapper _mapper;

        public ObtenerClientePorIdentificacionLN(IObtenerClientePorIdentificacionAD obtenerClientePorIdentificacionAD, IMapper mapper)
        {
            _ObtenerClientePorIdentificacionAD = obtenerClientePorIdentificacionAD;
            _mapper = mapper;
        }
        public async Task<CustomResponse<ClienteDTO>> Obtener(int identificacion)
        {
            var respuesta = new CustomResponse<ClienteDTO>();
            var cliente = await _ObtenerClientePorIdentificacionAD.Obtener(identificacion);

            var validacion = Validar(cliente);
            if (validacion.EsError)
            {
                return respuesta;
            }

            respuesta.Data = _mapper.Map<ClienteDTO>(cliente);
            respuesta.EsError = false;
            return respuesta;
        }

        private CustomResponse<ClienteDTO> Validar(ClienteAD cliente)
        {
            var respuesta = new CustomResponse<ClienteDTO>();

            if (cliente == null)
            {
                respuesta.EsError = false;
                respuesta.Mensaje = "No se encontró un cliente con la identificación proporcionada.";
                return respuesta;
            }

            return respuesta;
        }
    }
}
