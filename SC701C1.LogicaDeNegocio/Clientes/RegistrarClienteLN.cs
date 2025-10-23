
using AutoMapper;
using SC701C1.Abstracciones.AccesoDatos.Clientes;
using SC701C1.Abstracciones.LogicaDeNegocio;
using SC701C1.Abstracciones.LogicaDeNegocio.Clientes;
using SC701C1.Abstracciones.Modelos;
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.LogicaDeNegocio.Clientes
{
    public class RegistrarClienteLN : IRegistrarClienteLN
    {
        private readonly IRegistrarClienteAD _registrarClienteAD;
        private readonly IMapper _mapper;
        private readonly IValidarExistenciaAD _validarExistenciaAD;

        public RegistrarClienteLN(IRegistrarClienteAD registrarClienteAD, IMapper mapper, IValidarExistenciaAD validarExistenciaAD)
        {
            _registrarClienteAD = registrarClienteAD;
            _mapper = mapper;
            _validarExistenciaAD = validarExistenciaAD;
        }


        public async Task<CustomResponse<ClienteDTO>> Registrar(ClienteDTO cliente)
        {
            var respuesta = new CustomResponse<ClienteDTO>();

            bool existe = await _validarExistenciaAD.ValidarExistencia(cliente.Identificacion);

            if (existe)
            {
                respuesta.EsError = true;
                respuesta.Mensaje = "El cliente con la identificación proporcionada ya existe.";
                return respuesta;
            }

            if (cliente.Edad < 18)
            {
                respuesta.EsError = true;
                respuesta.Mensaje = "El cliente debe ser mayor de edad.";
                return respuesta;
            }

            cliente.FechaRegistro = DateTime.Now;
            bool resultado = await _registrarClienteAD.Registrar(_mapper.Map<ClienteAD>(cliente));

            if (!resultado)
            {
                respuesta.EsError = true;
                respuesta.Mensaje = "Error al registrar el cliente.";
                return respuesta;
            }

            respuesta.EsError = false;
            respuesta.Mensaje = "Cliente registrado exitosamente.";
            return respuesta;
        }

    }
}
