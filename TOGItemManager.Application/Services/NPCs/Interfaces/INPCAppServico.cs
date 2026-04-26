using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Application.DTOs.NPCs.Requests;
using TOGItemManager.Application.DTOs.NPCs.Responses;
using TOGItemManager.Domain.Entidades.NPCs;

namespace TOGItemManager.Application.Services.NPCs.Interfaces
{
    public interface INPCAppServico
    {
        void Inserir(NPCInserirRequest request);
        void Atualizar(NPCUpdateRequest request);   
        void Remover(int id);
        NPC ObterPorId(int id);
        PaginacaoResponse<NPCResponse> Query(NPCFiltrarRequest filtro);
    }
}