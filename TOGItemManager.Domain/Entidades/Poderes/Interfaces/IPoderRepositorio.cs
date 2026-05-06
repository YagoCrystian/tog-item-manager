namespace TOGItemManager.Domain.Entidades.Poderes.Interfaces
{
    public interface IPoderRepositorio
    {
        void Inserir(Poder poder);
        void Remover(Poder poder);
        void Atualizar(Poder poder);
        Poder ObterPorId(int id);
        IQueryable<Poder> Query();
    }
}