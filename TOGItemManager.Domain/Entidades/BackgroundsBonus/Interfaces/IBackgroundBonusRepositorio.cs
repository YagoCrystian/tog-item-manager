namespace TOGItemManager.Domain.Entidades.BackgroundsBonus.Interfaces
{
    public interface IBackgroundBonusRepositorio
    {
        void Inserir(BackgroundBonus backgroundBonus);
        void Remover(BackgroundBonus backgroundBonus);
        void Atualizar(BackgroundBonus backgroundBonus);
        BackgroundBonus ObterPorId(int id);
        IQueryable<BackgroundBonus> Query();
    }
}