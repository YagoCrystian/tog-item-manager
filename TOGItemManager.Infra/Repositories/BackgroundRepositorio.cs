using NHibernate;
using TOGItemManager.Domain.Entidades.Backgrounds;
using TOGItemManager.Domain.Entidades.Backgrounds.Interfaces;

namespace TOGItemManager.Infra.Repositories
{
    public class BackgroundRepositorio : IBackgroundRepositorio
    {
        private readonly ISession session;

        public BackgroundRepositorio(ISession session)
        {
            this.session = session;
        }

        public void Inserir(Background background)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Save(background);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Remover(Background background)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Delete(background);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Atualizar(Background background)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Update(background);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public Background ObterPorId(int id)
        {
            return session.Get<Background>(id);
        }

        public IQueryable<Background> Query()
        {
            return session.Query<Background>();
        }
    }
}