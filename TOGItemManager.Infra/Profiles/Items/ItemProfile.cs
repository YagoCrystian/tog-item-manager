using AutoMapper;
using TOGItemManager.Application.DTOs.Items.Responses;
using TOGItemManager.Domain.Entidades.Items;

namespace TOGItemManager.Infra.Profiles.Items
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemResponse>();
        }
    }
}