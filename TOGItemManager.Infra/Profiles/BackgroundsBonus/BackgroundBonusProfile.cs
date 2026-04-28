using AutoMapper;
using TOGItemManager.Application.DTOs.BackgroundsBonus.Responses;
using TOGItemManager.Domain.Entidades.BackgroundsBonus;

namespace TOGItemManager.Infra.Profiles.BackgroundsBonus
{
    public class BackgroundBonusProfile : Profile
    {
        public BackgroundBonusProfile()
        {
            CreateMap<BackgroundBonus, BackgroundBonusResponse>();
        }
    }
}