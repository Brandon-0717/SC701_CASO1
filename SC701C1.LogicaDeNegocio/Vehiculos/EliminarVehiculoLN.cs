
using AutoMapper;
using SC701C1.Abstracciones.AccesoDatos.Vehiculos;
using SC701C1.Abstracciones.LogicaDeNegocio;
using SC701C1.Abstracciones.LogicaDeNegocio.Vehiculos;
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.LogicaDeNegocio.Vehiculos
{
    public class EliminarVehiculoLN : IEliminarVehiculoLN
    {
        private readonly IEliminarVehiculoAD _eliminarVehiculoAD;
        private readonly IMapper _mapper;

        public EliminarVehiculoLN(IEliminarVehiculoAD eliminarVehiculoAD, IMapper mapper)
        {
            _eliminarVehiculoAD = eliminarVehiculoAD;
            _mapper = mapper;
        }

        public async Task<CustomResponse<VehiculoDTO>> Eliminar(string placa)
        {
            var response = new CustomResponse<VehiculoDTO>();
           
            bool eliminado = await _eliminarVehiculoAD.Eliminar(placa);
            
            if (!eliminado)
            {
                response.EsError = true;
                response.Mensaje = "Error al eliminar el vehiculo";
                return response;
            }

            response.Mensaje = "Vehiculo eliminado exitosamente";
            return response;
        }
    }
}
