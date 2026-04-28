using TOGItemManager.Domain.Enums;

namespace TOGItemManager.Application.DTOs.PosicoesBonus.Responses
{
    public record PosicaoBonusResponse(int Id, TipoBonusEnum TipoBonus, int Referencia, int Valor, bool PorNivel);
    
}