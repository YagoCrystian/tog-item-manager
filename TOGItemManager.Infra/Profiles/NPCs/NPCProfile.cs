using AutoMapper;
using TOGItemManager.Application.DTOs.NPCs.Responses;
using TOGItemManager.Domain.Entidades.NPCs;

namespace TOGItemManager.Infra.Profiles.NPCs
{
    public class NPCProfile : Profile
    {
        public NPCProfile()
        {
            CreateMap<NPC, NPCResponse>();
        }
    }
}