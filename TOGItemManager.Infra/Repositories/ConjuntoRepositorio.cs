using NHibernate;
using TOGItemManager.Domain.Entidades.Conjuntos;
using TOGItemManager.Domain.Entidades.Conjuntos.Interfaces;

namespace TOGItemManager.Infra.Repositories
{
    public class ConjuntoRepositorio : IConjuntoRepositorio
    {
    
        private readonly ISession session;

        public ConjuntoRepositorio(ISession session)
        {
            this.session = session;
        }

        public void Inserir(Conjunto conjunto)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Save(conjunto);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Remover(Conjunto conjunto)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Delete(conjunto);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Atualizar(Conjunto conjunto)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Update(conjunto);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public Conjunto ObterPorId(int id)
        {
            return session.Get<Conjunto>(id);
        }

        public IQueryable<Conjunto> Query()
        {
            return session.Query<Conjunto>();
        }
    }
    
}