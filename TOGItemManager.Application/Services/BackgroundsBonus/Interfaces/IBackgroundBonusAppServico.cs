using TOGItemManager.Application.DTOs.BackgroundsBonus.Requests;
using TOGItemManager.Domain.Entidades.BackgroundsBonus;

namespace TOGItemManager.Application.Services.BackgroundsBonus.Interfaces
{
    public interface IBackgroundBonusAppServico
    {
        BackgroundBonus ObterEValidar(int id);
        void Inserir(BackgroundBonusInserirRequest request);
        void Atualizar(BackgroundBonusUpdateRequest request);
        void Remover(int id);
    }
}