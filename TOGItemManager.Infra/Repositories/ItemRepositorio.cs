using NHibernate;
using TOGItemManager.Domain.Entidades.Items;
using TOGItemManager.Domain.Entidades.Items.Interfaces;

namespace TOGItemManager.Infra.Repositories
{
    public class ItemRepositorio : IItemRepositorio
    {
        private readonly ISession session;

        public ItemRepositorio(ISession session)
        {
            this.session = session;
        }

        public void Inserir(Item item)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Save(item);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Remover(Item item)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Delete(item);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Atualizar(Item item)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Update(item);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public Item ObterPorId(int id)
        {
            return session.Get<Item>(id);
        }

        public IQueryable<Item> Query()
        {
            return session.Query<Item>();
        }

    }
}