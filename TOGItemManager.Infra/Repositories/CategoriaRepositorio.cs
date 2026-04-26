using NHibernate;
using TOGItemManager.Domain.Entidades.Categorias;
using TOGItemManager.Domain.Entidades.Categorias.Interfaces;

namespace TOGItemManager.Infra.Repositories
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly ISession session;

        public CategoriaRepositorio(ISession session)
        {
            this.session = session;
        }

        public void Inserir(Categoria categoria)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Save(categoria);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Remover(Categoria categoria)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Delete(categoria);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Atualizar(Categoria categoria)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Update(categoria);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public Categoria ObterPorId(int id)
        {
            return session.Get<Categoria>(id);
        }

        public IQueryable<Categoria> Query()
        {
            return session.Query<Categoria>();
        }
    }
}