using TOGItemManager.Application.DTOs.Comuns.Requests;

namespace TOGItemManager.Application.DTOs.Poderes.Requests
{
    public class PoderFiltrarRequest : PaginacaoRequest
    {
        public string? Nome { get; set; }
        public string? TipoPoder { get; set; }
    }
}