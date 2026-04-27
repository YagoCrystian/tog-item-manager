using TOGItemManager.Application.DTOs.Comuns.Requests;

namespace TOGItemManager.Application.DTOs.Backgrounds.Requests
{
    public class BackgroundFiltrarRequest : PaginacaoRequest
    {
        public string? Nome { get; set; }
    }
}