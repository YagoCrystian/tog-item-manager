using TOGItemManager.Domain.Entidades.Usuarios.Interfaces;
using TOGItemManager.Domain.Servicos.Usuarios.Interfaces;

namespace TOGItemManager.Domain.Servicos.Usuarios
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IUsuarioRepositorio usuarioRepositorio;

        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio)
        {
            this.usuarioRepositorio = usuarioRepositorio;
        }

        public bool ApelidoDisponivel(string apelido)
        {
            return !usuarioRepositorio.ExisteApelido(apelido);
        }

    }
}