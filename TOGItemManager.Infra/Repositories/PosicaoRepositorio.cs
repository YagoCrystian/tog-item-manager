using NHibernate;
using TOGItemManager.Domain.Entidades.Posicoes;
using TOGItemManager.Domain.Entidades.Posicoes.Interfaces;

namespace TOGItemManager.Infra.Repositories
{
    public class PosicaoRepositorio : IPosicaoRepositorio
    {
        private readonly ISession session;

        public PosicaoRepositorio(ISession session)
        {
            this.session = session;
        }

        public void Inserir(Posicao posicao)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Save(posicao);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Remover(Posicao posicao)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Delete(posicao);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Atualizar(Posicao posicao)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Update(posicao);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public Posicao ObterPorId(int id)
        {
            return session.Get<Posicao>(id);
        }

        public IQueryable<Posicao> Query()
        {
            return session.Query<Posicao>();
        }
    }
}