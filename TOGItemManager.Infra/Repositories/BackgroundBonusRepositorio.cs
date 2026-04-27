using NHibernate;
using TOGItemManager.Domain.Entidades.BackgroundsBonus;
using TOGItemManager.Domain.Entidades.BackgroundsBonus.Interfaces;

namespace TOGItemManager.Infra.Repositories
{
    public class BackgroundBonusRepositorio : IBackgroundBonusRepositorio
    {
        private readonly ISession session;

        public BackgroundBonusRepositorio(ISession session)
        {
            this.session = session;
        }

        public void Inserir(BackgroundBonus backgroundBonus)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Save(backgroundBonus);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Remover(BackgroundBonus backgroundBonus)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Delete(backgroundBonus);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Atualizar(BackgroundBonus backgroundBonus)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Update(backgroundBonus);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public BackgroundBonus ObterPorId(int id)
        {
            return session.Get<BackgroundBonus>(id);
        }

        public IQueryable<BackgroundBonus> Query()
        {
            return session.Query<BackgroundBonus>();
        }
    }
}