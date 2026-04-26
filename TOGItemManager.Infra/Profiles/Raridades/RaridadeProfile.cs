using AutoMapper;
using TOGItemManager.Application.DTOs.Raridades.Responses;
using TOGItemManager.Domain.Entidades.Raridades;

namespace TOGItemManager.Infra.Profiles.Raridades
{
    public class RaridadeProfile : Profile
    {   
        public RaridadeProfile()
        {
            CreateMap<Raridade, RaridadeResponse>();
        }
    }
}