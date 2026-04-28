using AutoMapper;
using TOGItemManager.Application.DTOs.Posicoes.Responses;
using TOGItemManager.Domain.Entidades.Posicoes;

namespace TOGItemManager.Infra.Profiles.Posicoes
{
    public class PosicaoProfile : Profile
    {
        public PosicaoProfile()
        {
            CreateMap<Posicao, PosicaoResponse>();
        }
    }
}