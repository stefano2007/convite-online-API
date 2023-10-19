using AutoMapper;
using ConviteOnline.Application.DTOs;
using ConviteOnline.Domain.Entities;

namespace ConviteOnline.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //TODO: Criar as Commands quando adicionar o Mediator
            CreateMap<Foto, FotoDTO>().ReverseMap();
            //CreateMap<FotoDTO, FotoCommand>();
            //CreateMap<FotoCriarDTO, LaunchCreateCommand>();
            //CreateMap<FotoAlterarDTO, FotoUpdateCommand>();

            CreateMap<Resposta, RespostaDTO>().ReverseMap();
        }
    }
}
