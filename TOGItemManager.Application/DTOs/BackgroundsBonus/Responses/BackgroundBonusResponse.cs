using TOGItemManager.Domain.Enums;

namespace TOGItemManager.Application.DTOs.BackgroundsBonus.Responses
{
    public record BackgroundBonusResponse(int Id, TipoBonusEnum TipoBonus, int Referencia, int Valor, bool Escolha);

}