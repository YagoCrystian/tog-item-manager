namespace TOGItemManager.Domain.Entidades.Backgrounds.Interfaces
{
    public interface IBackgroundRepositorio
    {
        void Inserir(Background background);
        void Remover(Background background);
        void Atualizar(Background background);
        Background ObterPorId(int id);
        IQueryable<Background> Query();
    }
}