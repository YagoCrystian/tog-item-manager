namespace TOGItemManager.Domain.Entidades.Perfis.Interfaces
{
    public interface IPerfilRepositorio
    {
        void Inserir(Perfil perfil);
        void Remover(Perfil perfil);
        void Atualizar(Perfil perfil);
        Perfil ObterPorId(int id);
        IQueryable<Perfil> Query();
    }
}