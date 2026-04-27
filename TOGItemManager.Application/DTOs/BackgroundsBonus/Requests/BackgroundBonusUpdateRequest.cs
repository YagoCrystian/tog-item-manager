using TOGItemManager.Domain.Enums;

namespace TOGItemManager.Application.DTOs.BackgroundsBonus.Requests
{
    public class BackgroundBonusUpdateRequest
    {
        public int Id { get; set; }
        public int? Background { get; set; }
        public TipoBackgroundBonusEnum? TipoBonus { get; set; }
        public int? Referencia { get; set; }
        public int? Valor { get; set; }
        public bool? EscolhaJogador { get; set; }
    }
}