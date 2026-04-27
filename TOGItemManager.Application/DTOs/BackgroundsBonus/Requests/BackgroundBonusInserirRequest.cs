using TOGItemManager.Domain.Enums;

namespace TOGItemManager.Application.DTOs.BackgroundsBonus.Requests
{
    public record BackgroundBonusInserirRequest(int Background, TipoBackgroundBonusEnum TipoBonus, int Referencia, int Valor, bool Escolha);

}