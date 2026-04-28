using TOGItemManager.Domain.Enums;

namespace TOGItemManager.Application.DTOs.PosicoesBonus.Requests
{
    public record PosicaoBonusInserirRequest(int Posicao, TipoBonusEnum TipoBonus, int Referencia, int Valor, bool PorNivel);

}