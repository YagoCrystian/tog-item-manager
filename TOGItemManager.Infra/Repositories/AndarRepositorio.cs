using NHibernate;
using TOGItemManager.Domain.Entidades.Andares;
using TOGItemManager.Domain.Entidades.Andares.Interfaces;

namespace TOGItemManager.Infra.Repositories
{
    public class AndarRepositorio : IAndarRepositorio
    {
        private readonly ISession session;

        public AndarRepositorio(ISession session)
        {
            this.session = session;
        }

        public void Inserir(Andar andar)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Save(andar);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Remover(Andar andar)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Delete(andar);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Atualizar(Andar andar)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Update(andar);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public Andar ObterPorId(int id)
        {
            return session.Get<Andar>(id);
        }

        public IQueryable<Andar> Query()
        {
            return session.Query<Andar>();
        }    
    }
}