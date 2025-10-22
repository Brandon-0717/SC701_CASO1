
using AutoMapper;
using SC701C1.Abstracciones.AccesoDatos.Clientes;
using SC701C1.Abstracciones.LogicaDeNegocio;
using SC701C1.Abstracciones.LogicaDeNegocio.Clientes;
using SC701C1.Abstracciones.Modelos;
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.LogicaDeNegocio.Clientes
{
    public class ModificarClienteLN : IModificarClienteLN
    {
        private readonly IModificarClienteAD _modificarClienteAD;
        private readonly IMapper _mapper;

        public ModificarClienteLN(IModificarClienteAD modificarClienteAD, IMapper mapper)
        {
            _modificarClienteAD = modificarClienteAD;
            _mapper = mapper;
        }

        public async Task<CustomResponse<ClienteDTO>> Modificar(ClienteDTO cliente)
        {
            var respuesta = new CustomResponse<ClienteDTO>();

            if (cliente.Edad < 18)
            {
                respuesta.EsError = true;
                respuesta.Mensaje = "El cliente debe ser mayor de edad.";
                return respuesta;
            }

            if (!await _modificarClienteAD.Modificar(_mapper.Map<ClienteAD>(cliente)))
            {
                respuesta.EsError = true;
                respuesta.Mensaje = "No se pudo modificar el cliente.";
                return respuesta;
            }
            return respuesta;
        }

    }
}
