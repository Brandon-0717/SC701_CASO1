
using AutoMapper;
using SC701C1.Abstracciones.AccesoDatos.Clientes;
using SC701C1.Abstracciones.AccesoDatos.Vehiculos;
using SC701C1.Abstracciones.LogicaDeNegocio;
using SC701C1.Abstracciones.LogicaDeNegocio.Clientes;
using SC701C1.Abstracciones.LogicaDeNegocio.Vehiculos;
using SC701C1.Abstracciones.Modelos;
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.LogicaDeNegocio.Vehiculos
{
    public class ObtenerVehiculosLN : IObtenerVehiculosLN
    {
        private readonly IObtenerVehiculosAD _obtenerVehiculosAD;
        private readonly IObtenerClientePorIdentificacionLN _obtenerClientePorIdentificacionLN;
        private readonly IMapper _mapper;

        public ObtenerVehiculosLN(IObtenerVehiculosAD obtenerVehiculosAD, IMapper mapper, IObtenerClientePorIdentificacionLN obtenerClientePorIdentificacionLN)
        {
            _obtenerVehiculosAD = obtenerVehiculosAD;
            _obtenerClientePorIdentificacionLN = obtenerClientePorIdentificacionLN;
            _mapper = mapper;
        }

        public async Task<CustomResponse<List<VehiculoDTO>>> Obtener()
        {
            var respuesta = new CustomResponse<List<VehiculoDTO>>();
            var lista =  await _obtenerVehiculosAD.Obtener();
            var listaDto = _mapper.Map<List<VehiculoDTO>>(lista);

            listaDto = await AsignarNombrePropietario(listaDto);
            respuesta.Data = listaDto;
            return respuesta;
        }

        private async Task<List<VehiculoDTO>> AsignarNombrePropietario(List<VehiculoDTO> lista)
        {
            foreach (var vehiculo in lista)
            {
                var cliente = await _obtenerClientePorIdentificacionLN.Obtener(vehiculo.PropietarioId);
                if (cliente.Data != null)
                {
                    vehiculo.NombrePropietario = cliente.Data.Nombre + " " + cliente.Data.PrimerApellido + " " + cliente.Data.SegundoApellido; 
                }
            }
            return lista;
        }

    }
}
