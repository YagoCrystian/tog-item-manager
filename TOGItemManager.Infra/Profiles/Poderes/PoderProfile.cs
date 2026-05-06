using AutoMapper;
using TOGItemManager.Application.DTOs.Poderes.Responses;
using TOGItemManager.Domain.Entidades.Poderes;

namespace TOGItemManager.Infra.Profiles.Poderes
{
    public class PoderProfile : Profile
    {
        public PoderProfile()
        {
            CreateMap<Poder, PoderResponse>();
        }
    }
}