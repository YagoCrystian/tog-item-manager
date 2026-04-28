using AutoMapper;
using TOGItemManager.Application.DTOs.PosicoesBonus.Responses;
using TOGItemManager.Domain.Entidades.PosicoesBonus;

namespace TOGItemManager.Infra.Profiles.PosicoesBonus
{
    public class PosicaoBonusProfile : Profile
    {
        public PosicaoBonusProfile()
        {
            CreateMap<PosicaoBonus, PosicaoBonusResponse>();
        }
    }
}