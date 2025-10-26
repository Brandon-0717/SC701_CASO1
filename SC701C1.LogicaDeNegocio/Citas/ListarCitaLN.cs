
using AutoMapper;
using SC701C1.Abstracciones.AccesoDatos.Citas;
using SC701C1.Abstracciones.AccesoDatos.Clientes;
using SC701C1.Abstracciones.LogicaDeNegocio;
using SC701C1.Abstracciones.LogicaDeNegocio.Citas;
using SC701C1.Abstracciones.LogicaDeNegocio.Clientes;
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.LogicaDeNegocio.Citas
{
    public class ListarCitaLN : IListarCitaLN
    {
        private readonly IListarCitaAD _listarCitaAD;
        private readonly IObtenerClientePorIdentificacionLN _obtenerClientePorIdentificacionLN;
        private readonly IMapper _mapper;

        public ListarCitaLN(IListarCitaAD listarCitaAD, IMapper mapper, IObtenerClientePorIdentificacionLN obtenerClientePorIdentificacionLN)
        {
            _listarCitaAD = listarCitaAD;
            _obtenerClientePorIdentificacionLN = obtenerClientePorIdentificacionLN;
            _mapper = mapper;
        }

        public async Task<CustomResponse<List<CitaDTO>>> Listar()
        {
            var response = new CustomResponse<List<CitaDTO>> ();
            var lista = await _listarCitaAD.Listar();

            if (lista == null || !lista.Any()){ 
                response.EsError = true;
                response.Mensaje = "No se encontraron citas.";
                return response;
            }
            
            var listaDTO = _mapper.Map<List<CitaDTO>>(lista);

            response.Mensaje = "Citas encontradas exitosamente.";
            response.Data = await NombrarCliente(listaDTO);
            return response;
        }

        private async Task<List<CitaDTO>> NombrarCliente(List<CitaDTO> lista)
        {
            foreach (var cita in lista)
            {
                var clienteResponse = await _obtenerClientePorIdentificacionLN.Obtener(cita.ClienteId);
                if (!clienteResponse.EsError && clienteResponse.Data != null)
                {
                    cita.NombreCliente = clienteResponse.Data.Nombre + ' ' +
                                         clienteResponse.Data.PrimerApellido + ' ' + 
                                         clienteResponse.Data.SegundoApellido;
                }
            }
            return lista;
        }
    }
}
