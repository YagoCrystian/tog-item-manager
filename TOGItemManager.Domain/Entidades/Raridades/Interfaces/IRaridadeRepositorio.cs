namespace TOGItemManager.Domain.Entidades.Raridades.Interfaces
{
    public interface IRaridadeRepositorio
    {
        void Inserir(Raridade raridade);
        void Remover(Raridade raridade);
        void Atualizar(Raridade raridade);
        Raridade ObterPorId(int id);
        IQueryable<Raridade> Query();

    }
}