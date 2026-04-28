using TOGItemManager.Domain.Enums;

namespace TOGItemManager.Application.DTOs.PosicoesBonus.Requests
{
    public class PosicaoBonusUpdateRequest
    {
        public int Id { get; set; }
        public int? Posicao { get; set; }
        public TipoBonusEnum? TipoBonus { get; set; }
        public int? Referencia { get; set; }
        public int? Valor { get; set; }
        public bool? PorNivel { get; set; }
    }
}