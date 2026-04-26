namespace TOGItemManager.Domain.Entidades.Conjuntos.Interfaces
{
    public interface IConjuntoRepositorio
    {
        void Inserir(Conjunto conjunto);
        void Remover(Conjunto conjunto);
        void Atualizar(Conjunto conjunto);
        Conjunto ObterPorId(int id);
        IQueryable<Conjunto> Query();
    }
}