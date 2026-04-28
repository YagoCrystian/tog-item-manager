using TOGItemManager.Application.DTOs.PosicoesBonus.Requests;
using TOGItemManager.Application.DTOs.PosicoesBonus.Responses;
using TOGItemManager.Domain.Entidades.PosicoesBonus;

namespace TOGItemManager.Application.Services.PosicoesBonus.Interfaces
{
    public interface IPosicaoBonusAppServico
    {
        PosicaoBonus ObterEValidar(int id);
        void Inserir(PosicaoBonusInserirRequest request);
        void Atualizar(PosicaoBonusUpdateRequest request);
        void Remover(int id);

        PosicaoBonusResponse ObterPorId(int id);
    }
}