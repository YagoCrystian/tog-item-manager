using AutoMapper;
using TOGItemManager.Application.DTOs.Perfis.Responses;
using TOGItemManager.Domain.Entidades.Perfis;

namespace TOGItemManager.Infra.Profiles.Perfis
{
    public class PerfilProfiles : Profile
    {
        public PerfilProfiles()
        {
            CreateMap<Perfil, PerfilResponse>();

        }
    }
}