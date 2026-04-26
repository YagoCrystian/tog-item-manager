using AutoMapper;
using TOGItemManager.Application.DTOs.Categorias.Responses;
using TOGItemManager.Domain.Entidades.Categorias;

namespace TOGItemManager.Infra.Profiles.Categorias
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<Categoria, CategoriaResponse>();
        }
    }
}