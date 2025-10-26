
using AutoMapper;
using SC701C1.Abstracciones.AccesoDatos.Vehiculos;
using SC701C1.Abstracciones.LogicaDeNegocio;
using SC701C1.Abstracciones.LogicaDeNegocio.Vehiculos;
using SC701C1.Abstracciones.Modelos;
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.LogicaDeNegocio.Vehiculos
{
    public class CrearVehiculoLN : ICrearVehiculoLN
    {
        private readonly ICrearVehiculoAD _crearVehiculoAD;
        private readonly IValidarExistenciaPlacaLN _validarExistenciaPlacaLN;
        private readonly IMapper _mapper;

        public CrearVehiculoLN(ICrearVehiculoAD crearVehiculoAD, IMapper mapper, IValidarExistenciaPlacaLN validarExistenciaPlacaLN)
        {
            _crearVehiculoAD = crearVehiculoAD;
            _mapper = mapper;
            _validarExistenciaPlacaLN = validarExistenciaPlacaLN;
        }

        public async Task<CustomResponse<VehiculoDTO>> Crear(VehiculoDTO vehiculo)
        {
            var response = new CustomResponse<VehiculoDTO>();

            var respuestaValidacion = await _validarExistenciaPlacaLN.Validar(vehiculo.Placa);

            if (respuestaValidacion.EsError)
            {
                response.EsError = true;
                response.Mensaje = respuestaValidacion.Mensaje;
                return response;
            }

            vehiculo.FechaRegistro = DateTime.Now;
            bool resultado = await _crearVehiculoAD.Crear(_mapper.Map<VehiculoAD>(vehiculo));

            if(!resultado)
            {
                response.EsError = true;
                response.Mensaje = "Error al crear el vehículo.";
                return response;
            }

            response.Mensaje = "Vehículo creado exitosamente.";
            return response;
        }
    }
}
