using MySqlX.XDevAPI;
using NHibernate;
using TOGItemManager.Domain.Entidades.Usuarios;
using TOGItemManager.Domain.Entidades.Usuarios.Interfaces;

namespace TOGItemManager.Infra.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ISession session;

        public UsuarioRepositorio(ISession session)
        {
            this.session = session;
        }
        
        public void Inserir(Usuario usuario)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Save(usuario);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Remover(Usuario usuario)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Delete(usuario);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Atualizar(Usuario usuario)
        {
            var transaction = session.BeginTransaction();

            try
            {
                session.Update(usuario);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public Usuario ObterPorId(int id)
        {
            return session.Get<Usuario>(id);
        }

        public Usuario? ObterPorEmail(string email)
        {
            return session.Query<Usuario>()
                .FirstOrDefault(u => u.Email == email);
        }

        public IQueryable<Usuario> Query()
        {
            return session.Query<Usuario>();
        }

        public bool ExisteApelido(string apelido)
        {
            return session.Query<Usuario>()
                .Any(u => u.Apelido == apelido);
        }
    }
}