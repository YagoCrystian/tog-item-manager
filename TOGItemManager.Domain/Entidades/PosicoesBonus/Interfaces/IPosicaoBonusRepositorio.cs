namespace TOGItemManager.Domain.Entidades.PosicoesBonus.Interfaces
{
    public interface IPosicaoBonusRepositorio
    {
        void Inserir(PosicaoBonus posicaoBonus);
        void Remover(PosicaoBonus posicaoBonus);
        void Atualizar(PosicaoBonus posicaoBonus);
        PosicaoBonus ObterPorId(int id);
        IQueryable<PosicaoBonus> Query();
    }
}