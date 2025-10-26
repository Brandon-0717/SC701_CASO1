using AutoMapper;
using SC701C1.Abstracciones.AccesoDatos.Citas;
using SC701C1.Abstracciones.LogicaDeNegocio;
using SC701C1.Abstracciones.LogicaDeNegocio.Citas;
using SC701C1.Abstracciones.Modelos;
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.LogicaDeNegocio.Citas
{
    public class CrearCitaLN : ICrearCitaLN
    {
        private readonly ICrearCitaAD _crearCitaAD;
        private readonly IMapper _mapper;

        public CrearCitaLN(ICrearCitaAD crearCitaAD, IMapper mapper)
        {
            _crearCitaAD = crearCitaAD;
            _mapper = mapper;
        }

        public async Task<CustomResponse<CitaDTO>> Crear(CitaDTO citaDTO)
        {
            var response = new CustomResponse<CitaDTO>();

            citaDTO.CitaId = Guid.NewGuid();
            citaDTO.Estado = "Ingresada";

            bool creado = await _crearCitaAD.Crear(_mapper.Map<CitaAD>(citaDTO));

            if (!creado)
            {
                response.EsError = true;
                response.Mensaje = "Error al crear la cita.";
                return response;
            }

            response.Mensaje = "Cita agendada exitosamente.";
            return response;
        }
    }
}
