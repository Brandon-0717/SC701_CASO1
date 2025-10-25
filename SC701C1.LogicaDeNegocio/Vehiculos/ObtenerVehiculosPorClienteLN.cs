
using AutoMapper;
using SC701C1.Abstracciones.AccesoDatos.Vehiculos;
using SC701C1.Abstracciones.LogicaDeNegocio;
using SC701C1.Abstracciones.LogicaDeNegocio.Vehiculos;
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.LogicaDeNegocio.Vehiculos
{
    public class ObtenerVehiculosPorClienteLN : IObtenerVehiculosPorClienteLN
    {
        private readonly IObtenerVehiculosPorClienteAD _obtenerVehiculosPorClienteAD;
        private readonly IMapper _mapper;

        public ObtenerVehiculosPorClienteLN(IObtenerVehiculosPorClienteAD obtenerVehiculosPorClienteAD, IMapper mapper)
        {
            _obtenerVehiculosPorClienteAD = obtenerVehiculosPorClienteAD;
            _mapper = mapper;
        }


        public async Task<CustomResponse<List<VehiculoDTO>>> Obtener(int clienteId)
        {
            var response = new CustomResponse<List<VehiculoDTO>>();
            var listaVehiculosDTO = _mapper.Map<List<VehiculoDTO>>(_obtenerVehiculosPorClienteAD.Obtener(clienteId));
            
            var respeustaValidacion = await Validar(listaVehiculosDTO);

            if (respeustaValidacion.EsError)
            {
                response.EsError = true;
                response.Mensaje = respeustaValidacion.Mensaje;
                return response;
            }

            response.Mensaje = "Vehículos obtenidos correctamente.";
            response.Data = listaVehiculosDTO;
            return response;
        }

        private async Task<CustomResponse<VehiculoDTO>> Validar(List<VehiculoDTO> listaVehiculosDTO)
        {
            var response = new CustomResponse<VehiculoDTO>();

            if (listaVehiculosDTO == null || listaVehiculosDTO.Count == 0)
            {
                response.EsError = true;
                response.Mensaje = "No se encontraron vehículos para el cliente proporcionado.";
                return response;
            }

            return response;
        }
    }
}
