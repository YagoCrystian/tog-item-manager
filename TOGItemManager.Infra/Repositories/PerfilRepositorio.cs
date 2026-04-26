using NHibernate;
using TOGItemManager.Domain.Entidades.Perfis;
using TOGItemManager.Domain.Entidades.Perfis.Interfaces;

namespace TOGItemManager.Infra.Repositories
{
    public class PerfilRepositorio : IPerfilRepositorio
    {
        private readonly ISession session;

        public PerfilRepositorio(ISession session)
        {
            this.session = session;
        }

        public void Inserir(Perfil perfil)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Save(perfil);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Remover(Perfil perfil)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Delete(perfil);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Atualizar(Perfil perfil)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Update(perfil);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public Perfil ObterPorId(int id)
        {
            return session.Get<Perfil>(id);
        }   

        public IQueryable<Perfil> Query()
        {
            return session.Query<Perfil>();
        }
    }
}