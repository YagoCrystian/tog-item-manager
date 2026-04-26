using NHibernate;
using TOGItemManager.Domain.Entidades.NPCs;
using TOGItemManager.Domain.Entidades.NPCs.Interfaces;

namespace TOGItemManager.Infra.Repositories
{
    public class NPCRepositorio : INPCRepositorio
    {
        private readonly ISession session;

        public NPCRepositorio(ISession session)
        {
            this.session = session;
        }

        public void Inserir(NPC npc)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Save(npc);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Remover(NPC npc)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Delete(npc);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Atualizar(NPC npc)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Update(npc);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public NPC ObterPorId(int id)
        {
            return session.Get<NPC>(id);
        }   

        public IQueryable<NPC> Query()
        {
            return session.Query<NPC>();
        }

    }
}