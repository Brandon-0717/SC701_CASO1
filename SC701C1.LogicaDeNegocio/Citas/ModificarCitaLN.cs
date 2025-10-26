
using AutoMapper;
using SC701C1.Abstracciones.AccesoDatos.Citas;
using SC701C1.Abstracciones.LogicaDeNegocio;
using SC701C1.Abstracciones.LogicaDeNegocio.Citas;
using SC701C1.Abstracciones.Modelos;
using SC701C1.Abstracciones.Modelos.ModelosDTO;

namespace SC701C1.LogicaDeNegocio.Citas
{
    public class ModificarCitaLN : IModificarCitaLN
    {
        private readonly IModificarCitaAD _modificarCitaAD;
        private IMapper _mapper;

        public ModificarCitaLN(IModificarCitaAD modificarCitaAD, IMapper mapper)
        {
            _modificarCitaAD = modificarCitaAD;
            _mapper = mapper;
        }

        public async Task<CustomResponse<CitaDTO>> Modificar(CitaDTO cita)
        {
            var response = new CustomResponse<CitaDTO>();

            bool modificado = await _modificarCitaAD.Modificar(_mapper.Map<CitaAD>(cita));

            if (!modificado)
            {
                response.EsError = true;
                response.Mensaje = "No se pudo modificar la cita.";
                return response;
            }

            response.Mensaje = "Cita modificada exitosamente.";
            return response;

        }
    }
}
