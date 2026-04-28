using AutoMapper;
using TOGItemManager.Application.DTOs.Supertabelas.Responses;
using TOGItemManager.Domain.Entidades.Supertabelas;

namespace TOGItemManager.Infra.Profiles.SupertabelasProfile
{
    public class SupertabelaProfile : Profile
    {
        public SupertabelaProfile()
        {
            CreateMap<Supertabela, SupertabelaResponse>();
        }
    }
}