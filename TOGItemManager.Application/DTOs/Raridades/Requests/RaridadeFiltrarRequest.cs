using TOGItemManager.Application.DTOs.Comuns.Requests;

namespace TOGItemManager.Application.DTOs.Raridades.Requests
{
    public class RaridadeFiltrarRequest : PaginacaoRequest
    {
        public string? Nome { get; set; }
    }
}