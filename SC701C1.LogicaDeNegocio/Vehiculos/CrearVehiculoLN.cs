
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
        private readonly IMapper _mapper;

        public CrearVehiculoLN(ICrearVehiculoAD crearVehiculoAD, IMapper mapper)
        {
            _crearVehiculoAD = crearVehiculoAD;
            _mapper = mapper;
        }

        public async Task<CustomResponse<VehiculoDTO>> Crear(VehiculoDTO vehiculo)
        {
            CustomResponse<VehiculoDTO> response = new CustomResponse<VehiculoDTO>();

            vehiculo.FechaRegistro = DateTime.Now;
            bool resultado = await _crearVehiculoAD.Crear(_mapper.Map<VehiculoAD>(vehiculo));
            return resultado
                ? new CustomResponse<VehiculoDTO>
                {
                    Mensaje = "Vehículo creado exitosamente.",
                    Data = vehiculo
                }
                : new CustomResponse<VehiculoDTO>
                {
                    EsError = true,
                    Mensaje = "Error al crear el vehículo."
                };
        }
    }
}
