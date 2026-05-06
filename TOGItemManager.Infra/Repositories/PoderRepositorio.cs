using NHibernate;
using TOGItemManager.Domain.Entidades.Poderes;
using TOGItemManager.Domain.Entidades.Poderes.Interfaces;

namespace TOGItemManager.Infra.Repositories
{
    public class PoderRepositorio : IPoderRepositorio
    {
        private readonly ISession session;

        public PoderRepositorio(ISession session)
        {
            this.session = session;
        }

        public void Inserir(Poder poder)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Save(poder);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Remover(Poder poder)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Delete(poder);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Atualizar(Poder poder)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Update(poder);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public Poder ObterPorId(int id)
        {
            return session.Get<Poder>(id);
        }

        public IQueryable<Poder> Query()
        {
            return session.Query<Poder>();
        }
    }
}