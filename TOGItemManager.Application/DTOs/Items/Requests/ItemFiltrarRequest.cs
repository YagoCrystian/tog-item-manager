using TOGItemManager.Application.DTOs.Comuns.Requests;

namespace TOGItemManager.Application.DTOs.Items.Requests
{
    public class ItemFiltrarRequest : PaginacaoRequest
    {
        public string? Nome { get; set; }
        public float? Valor { get; set; }
        public string? Dono { get; set; }
        public int? Categoria { get; set; }
        public int? Raridade { get; set; }
        public int? Conjunto { get; set; }

    }
}