using TOGItemManager.Application.DTOs.Comuns.Requests;

namespace TOGItemManager.Application.DTOs.PosicoesBonus.Requests
{
    public class PosicaoBonusFiltrarRequest : PaginacaoRequest
    {
        public int? Posicao { get; set; }
        public int? TipoBonus { get; set; }
        public bool? PorNivel { get; set; }        
        
    }
    
}