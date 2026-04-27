using TOGItemManager.Application.DTOs.Comuns.Requests;

namespace TOGItemManager.Application.DTOs.BackgroundsBonus.Requests
{
    public class BackgroundBonusFiltrarRequest : PaginacaoRequest
    {
        public string? Name { get; set; }
        public int? Background { get; set; }
        public int? TipoBonus { get; set; }
        public bool? Escolha { get; set; }        
        
    }
}