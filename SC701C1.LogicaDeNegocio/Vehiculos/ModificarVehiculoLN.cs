
using AutoMapper;
using SC701C1.Abstracciones.AccesoDatos.Vehiculos;
using SC701C1.Abstracciones.LogicaDeNegocio;
using SC701C1.Abstracciones.LogicaDeNegocio.Vehiculos;
using SC701C1.Abstracciones.Modelos;
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.LogicaDeNegocio.Vehiculos
{
    public class ModificarVehiculoLN : IModificarVehiculoLN
    {
        private readonly IModificarVehiculoAD _modificarVehiculoAD;
        private readonly IMapper _mapper;

        public ModificarVehiculoLN(IModificarVehiculoAD modificarVehiculoAD, IMapper mapper)
        {
            _modificarVehiculoAD = modificarVehiculoAD;
            _mapper = mapper;
        }

        public async Task<CustomResponse<bool>> Modificar(VehiculoDTO vehiculo)
        {
            var response = new CustomResponse<bool>();

            var respuesta = await _modificarVehiculoAD.Modificar(_mapper.Map<VehiculoAD>(vehiculo));

            if (!respuesta)
            {
                response.EsError = true;
                response.Mensaje = "No se pudo modificar el vehículo.";
                return response;
            }

            response.Mensaje = "Vehículo modificado de manera exitosa.";
            return response;
        }
    }
}
