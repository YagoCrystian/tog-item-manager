using TOGItemManager.Application.DTOs.Comuns.Requests;

namespace TOGItemManager.Application.DTOs.NPCs.Requests
{
    public class NPCFiltrarRequest : PaginacaoRequest
    {
        public string? Nome { get; set; }
        public string? Tipo { get; set; }
        
    }
}