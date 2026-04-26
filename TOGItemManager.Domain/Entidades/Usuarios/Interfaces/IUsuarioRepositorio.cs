namespace TOGItemManager.Domain.Entidades.Usuarios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        void Inserir(Usuario usuario);
        void Remover(Usuario usuario);
        void Atualizar(Usuario usuario);
        Usuario ObterPorId(int id);
        Usuario ObterPorEmail(string email);
        IQueryable<Usuario> Query();
        bool ExisteApelido(string apelido);
    }
}