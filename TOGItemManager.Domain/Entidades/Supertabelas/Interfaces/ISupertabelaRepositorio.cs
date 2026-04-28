namespace TOGItemManager.Domain.Entidades.Supertabelas.Interfaces
{
    public interface ISupertabelaRepositorio
    {
        void Inserir(Supertabela supertabela);
        void Remover(Supertabela supertabela);
        void Atualizar(Supertabela supertabela);
        Supertabela ObterPorId(int id);
        IQueryable<Supertabela> Query();
    }
}