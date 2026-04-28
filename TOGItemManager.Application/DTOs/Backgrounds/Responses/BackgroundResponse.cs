using TOGItemManager.Application.DTOs.BackgroundsBonus.Responses;

namespace TOGItemManager.Application.DTOs.Backgrounds.Responses
{
    public record BackgroundResponse(
        int Id, 
        string Nome, 
        string Descricao,
        IList<BackgroundBonusResponse> Bonus
    );

}