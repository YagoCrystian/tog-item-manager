using AutoMapper;
using TOGItemManager.Application.DTOs.Backgrounds.Responses;
using TOGItemManager.Domain.Entidades.Backgrounds;

namespace TOGItemManager.Infra.Profiles.Backgrounds
{
    public class BackgroundProfile : Profile
    {
        public BackgroundProfile()
        {
            CreateMap<Background, BackgroundResponse>();
        }
    }
}