using NHibernate;
using TOGItemManager.Domain.Entidades.Raridades;
using TOGItemManager.Domain.Entidades.Raridades.Interfaces;

namespace TOGItemManager.Infra.Repositories
{
    public class RaridadeRepositorio : IRaridadeRepositorio
    {
        private readonly ISession session;

        public RaridadeRepositorio(ISession session)
        {
            this.session = session;
        }

        public void Inserir(Raridade raridade)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Save(raridade);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Remover(Raridade raridade)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Delete(raridade);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Atualizar(Raridade raridade)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Update(raridade);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public Raridade ObterPorId(int id)
        {
            return session.Get<Raridade>(id);
        }

        public IQueryable<Raridade> Query()
        {
            return session.Query<Raridade>();
        }
    }
}