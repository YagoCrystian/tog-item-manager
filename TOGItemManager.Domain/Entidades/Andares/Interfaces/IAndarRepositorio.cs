namespace TOGItemManager.Domain.Entidades.Andares.Interfaces
{
    public interface IAndarRepositorio
    {
        void Inserir(Andar andar);
        void Remover(Andar andar);
        void Atualizar(Andar andar);
        Andar ObterPorId(int id);
        IQueryable<Andar> Query();
    }
}