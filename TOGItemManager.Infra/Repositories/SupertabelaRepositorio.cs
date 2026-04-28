using NHibernate;
using TOGItemManager.Domain.Entidades.Supertabelas;
using TOGItemManager.Domain.Entidades.Supertabelas.Interfaces;

namespace TOGItemManager.Infra.Repositories
{
    public class SupertabelaRepositorio : ISupertabelaRepositorio
    {
        private readonly ISession session;

        public SupertabelaRepositorio(ISession session)
        {
            this.session = session;
        }

        public void Inserir(Supertabela supertabela)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Save(supertabela);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Remover(Supertabela supertabela)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Delete(supertabela);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Atualizar(Supertabela supertabela)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Update(supertabela);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public Supertabela ObterPorId(int id)
        {
            return session.Get<Supertabela>(id);
        }

        public IQueryable<Supertabela> Query()
        {
            return session.Query<Supertabela>();
        }
    }
}