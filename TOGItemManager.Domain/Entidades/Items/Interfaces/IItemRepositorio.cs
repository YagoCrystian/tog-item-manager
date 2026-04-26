namespace TOGItemManager.Domain.Entidades.Items.Interfaces
{
    public interface IItemRepositorio
    {
        void Inserir(Item item);
        void Remover(Item item);
        void Atualizar(Item item);
        Item ObterPorId(int id);
        IQueryable<Item> Query();
    }
}