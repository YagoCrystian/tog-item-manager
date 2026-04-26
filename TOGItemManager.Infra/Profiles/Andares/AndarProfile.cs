using AutoMapper;
using TOGItemManager.Application.DTOs.Andares.Responses;
using TOGItemManager.Domain.Entidades.Andares;

namespace TOGItemManager.Infra.Profiles.Andares
{
    public class AndarProfile : Profile
    {
        public AndarProfile()
        {
            CreateMap<Andar, AndarResponse>();
        }
        
    }
}