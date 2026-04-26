using AutoMapper;
using TOGItemManager.Application.DTOs.Usuarios.Responses;
using TOGItemManager.Domain.Entidades.Usuarios;

namespace TOGItemManager.Infra.Profiles.Usuarios
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioResponse>();
        }
    }
}