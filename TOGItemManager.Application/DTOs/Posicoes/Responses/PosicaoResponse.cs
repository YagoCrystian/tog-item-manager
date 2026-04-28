using TOGItemManager.Application.DTOs.PosicoesBonus.Responses;

namespace TOGItemManager.Application.DTOs.Posicoes.Responses
{
    public record PosicaoResponse(
        int Id, 
        string Nome, 
        string Descricao,
        IList<PosicaoBonusResponse> Bonus
        );

}