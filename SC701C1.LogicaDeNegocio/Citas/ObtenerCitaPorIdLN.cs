
using AutoMapper;
using SC701C1.Abstracciones.AccesoDatos.Citas;
using SC701C1.Abstracciones.LogicaDeNegocio;
using SC701C1.Abstracciones.LogicaDeNegocio.Citas;
using SC701C1.Abstracciones.LogicaDeNegocio.Clientes;
using SC701C1.Abstracciones.LogicaDeNegocio.Vehiculos;
using SC701C1.Abstracciones.Modelos.ModelosDTO;
using SC701C1.LogicaDeNegocio.Clientes;

namespace SC701C1.LogicaDeNegocio.Citas
{
    public class ObtenerCitaPorIdLN : IObtenerCitaPorIdLN
    {
        private readonly IObtenerCitaPorIdAD _obtenerCitaPorIdAD;
        private readonly IObtenerClientePorIdentificacionLN _obtenerClientePorIdentificacionLN;
        private readonly IObtenerVehiculoPorPlacaLN _obtenerVehiculoPorPlacaLN;
        private readonly IMapper _mapper;

        public ObtenerCitaPorIdLN(IObtenerCitaPorIdAD obtenerCitaPorIdAD, IMapper mapper, IObtenerClientePorIdentificacionLN obtenerClientePorIdentificacionLN, IObtenerVehiculoPorPlacaLN obtenerVehiculoPorPlacaLN)
        {
            _obtenerCitaPorIdAD = obtenerCitaPorIdAD;
            _obtenerClientePorIdentificacionLN = obtenerClientePorIdentificacionLN;
            _obtenerVehiculoPorPlacaLN = obtenerVehiculoPorPlacaLN;
            _mapper = mapper;
        }

        public async Task<CustomResponse<CitaDTO>> Obtener(Guid citaId)
        {
            var response = new CustomResponse<CitaDTO>();

            var cita = await _obtenerCitaPorIdAD.Obtener(citaId);

            if (cita == null)
            {
                response.Mensaje = "Cita no encontrada.";
                response.EsError = true;
                return response;
            }

            var citaDTO = _mapper.Map<CitaDTO>(cita);
            citaDTO = await NombrarCliente(citaDTO);
            citaDTO = await NombrarVehiculo(citaDTO);

            response.Mensaje = "Cita encontrada exitosamente.";
            response.Data = citaDTO;
            return response;
        }

        private async Task<CitaDTO> NombrarCliente(CitaDTO cita)
        {
            var cliente = await _obtenerClientePorIdentificacionLN.Obtener(cita.ClienteId);
            cita.NombreCliente = cliente.Data.Nombre + " " + cliente.Data.PrimerApellido + " " +cliente.Data.SegundoApellido;
            return cita;
        }

        private async Task<CitaDTO> NombrarVehiculo(CitaDTO cita)
        {
            var vehiculo = await _obtenerVehiculoPorPlacaLN.Obtener(cita.VehiculoId);
            cita.NombreVehiculo = "Placa: " + vehiculo.Data.Placa + " - Vehiculo: " + vehiculo.Data.Marca + " " + vehiculo.Data.Modelo;
            return cita;
        }

    }
}
