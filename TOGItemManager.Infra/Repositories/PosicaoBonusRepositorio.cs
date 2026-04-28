using NHibernate;
using TOGItemManager.Domain.Entidades.PosicoesBonus;
using TOGItemManager.Domain.Entidades.PosicoesBonus.Interfaces;

namespace TOGItemManager.Infra.Repositories
{
    public class PosicaoBonusRepositorio : IPosicaoBonusRepositorio
    {
        private readonly ISession session;

        public PosicaoBonusRepositorio(ISession session)
        {
            this.session = session;
        }

        public void Inserir(PosicaoBonus posicaoBonus)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Save(posicaoBonus);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Remover(PosicaoBonus posicaoBonus)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Delete(posicaoBonus);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Atualizar(PosicaoBonus posicaoBonus)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Update(posicaoBonus);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public PosicaoBonus ObterPorId(int id)
        {
            return session.Get<PosicaoBonus>(id);
        }

        public IQueryable<PosicaoBonus> Query()
        {
            return session.Query<PosicaoBonus>();
        }
    }
}