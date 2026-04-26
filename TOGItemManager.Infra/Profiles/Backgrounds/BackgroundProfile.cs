using AutoMapper;
using TOGItemManager.Application.DTOs.Background.Responses;
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