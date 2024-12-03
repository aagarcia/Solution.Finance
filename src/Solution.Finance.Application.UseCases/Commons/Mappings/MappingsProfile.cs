using AutoMapper;
using Solution.Finance.Application.UseCases.Commons.DTOs.Usuario;
using Solution.Finance.Domain.Entities;

namespace Solution.Finance.Application.UseCases.Commons.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<CrearUsuarioDTO, Usuario>().ReverseMap();
            CreateMap<ActualizarUsuarioDTO, Usuario>().ReverseMap();
            CreateMap<EliminarUsuarioDTO, Usuario>().ReverseMap();
            CreateMap<RespuestaUsuarioDTO, Usuario>().ReverseMap();
        }
    }
}
