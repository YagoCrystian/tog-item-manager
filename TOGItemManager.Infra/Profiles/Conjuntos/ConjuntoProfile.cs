using AutoMapper;
using TOGItemManager.Application.DTOs.Conjuntos.Responses;
using TOGItemManager.Domain.Entidades.Conjuntos;

namespace TOGItemManager.Infra.Profiles.Conjuntos
{
    public class ConjuntoProfile : Profile
    {
        public ConjuntoProfile()
        {
            CreateMap<Conjunto, ConjuntoResponse>();
        }
    }
}