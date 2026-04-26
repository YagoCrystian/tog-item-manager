namespace TOGItemManager.Domain.Entidades.Categorias.Interfaces
{
    public interface ICategoriaRepositorio
    {
        void Inserir(Categoria categoria);
        void Remover(Categoria categoria);
        void Atualizar(Categoria categoria);
        Categoria ObterPorId(int id);
        IQueryable<Categoria> Query();
    }
}