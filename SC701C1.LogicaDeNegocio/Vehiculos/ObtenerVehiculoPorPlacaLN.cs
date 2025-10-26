
using AutoMapper;
using SC701C1.Abstracciones.AccesoDatos.Vehiculos;
using SC701C1.Abstracciones.LogicaDeNegocio;
using SC701C1.Abstracciones.LogicaDeNegocio.Clientes;
using SC701C1.Abstracciones.LogicaDeNegocio.Vehiculos;
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.LogicaDeNegocio.Vehiculos
{
    public class ObtenerVehiculoPorPlacaLN : IObtenerVehiculoPorPlacaLN
    {
        private readonly IObtenerVehiculoPorPlacaAD _obtenerVehiculoPorPlacaAD;
        private readonly IObtenerClientePorIdentificacionLN _obtenerClientePorIdentificacionLN;

        private readonly IMapper _mapper;

        public ObtenerVehiculoPorPlacaLN(IObtenerVehiculoPorPlacaAD obtenerVehiculoPorPlacaAD, IMapper mapper, IObtenerClientePorIdentificacionLN obtenerClientePorIdentificacionLN)
        {
            _obtenerVehiculoPorPlacaAD = obtenerVehiculoPorPlacaAD;
            _obtenerClientePorIdentificacionLN = obtenerClientePorIdentificacionLN;
            _mapper = mapper;
        }

        public async Task<CustomResponse<VehiculoDTO>> Obtener(string placa)
        {
            var response = new CustomResponse<VehiculoDTO>();

            var vehiculoAD = await _obtenerVehiculoPorPlacaAD.Obtener(placa);
            
            if (vehiculoAD == null)
            {
                response.Mensaje = "Vehículo no encontrado.";
                response.EsError = true;
                return response;
            }

            var VehiculoDTO = _mapper.Map<VehiculoDTO>(vehiculoAD);
            VehiculoDTO = await AsignarNombrePropietario(VehiculoDTO);
            response.Data = VehiculoDTO;
            response.Mensaje = "Vehículo obtenido con éxito.";
            return response;
        }

        private async Task<VehiculoDTO> AsignarNombrePropietario(VehiculoDTO vehiculo)
        {
            var cliente = await _obtenerClientePorIdentificacionLN.Obtener(vehiculo.PropietarioId);
            if (cliente.Data != null)
            {
                vehiculo.NombrePropietario = cliente.Data.Nombre + " " + cliente.Data.PrimerApellido + " " + cliente.Data.SegundoApellido;
            }
            return vehiculo;
        }
    }
}
