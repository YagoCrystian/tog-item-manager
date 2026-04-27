using TOGItemManager.Domain.Entidades.Backgrounds;
using TOGItemManager.Domain.Enums;

namespace TOGItemManager.Application.DTOs.BackgroundsBonus.Responses
{
    public record BackgroundBonusResponse(int Id, Background Background, TipoBackgroundBonusEnum TipoBonus, int Referencia, int Valor, bool Escolha);

}