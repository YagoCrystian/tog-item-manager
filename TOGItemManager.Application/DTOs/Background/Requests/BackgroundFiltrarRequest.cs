using TOGItemManager.Application.DTOs.Comuns.Requests;

namespace TOGItemManager.Application.DTOs.Background.Requests
{
    public class BackgroundFiltrarRequest : PaginacaoRequest
    {
        public string? Nome { get; set; }
    }
}