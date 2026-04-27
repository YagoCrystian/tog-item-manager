using NHibernate;
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
    }
}