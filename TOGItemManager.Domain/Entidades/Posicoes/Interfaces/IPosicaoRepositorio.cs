namespace TOGItemManager.Domain.Entidades.Posicoes.Interfaces
{
    public interface IPosicaoRepositorio
    {
        void Inserir(Posicao posicao);
        void Remover(Posicao posicao);
        void Atualizar(Posicao posicao);
        Posicao ObterPorId(int id);
        IQueryable<Posicao> Query();
    }
}