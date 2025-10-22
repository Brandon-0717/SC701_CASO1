
using AutoMapper;
using SC701C1.Abstracciones.Modelos;
using SC701C1.Abstracciones.Modelos.ModelosDTO;
namespace SC701C1.LogicaDeNegocio.Mapper
{
    public class MapeoClases : Profile
    {
        public MapeoClases()
        {
            CreateMap<ClienteAD, ClienteDTO>();
            CreateMap<ClienteDTO, ClienteAD>();
        }
    }
}
