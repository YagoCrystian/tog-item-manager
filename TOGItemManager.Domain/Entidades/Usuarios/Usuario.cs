using TOGItemManager.Domain.Entidades.Perfis;
using TOGItemManager.Domain.Enums;

namespace TOGItemManager.Domain.Entidades.Usuarios
{
    public class Usuario
    {
        public virtual int Id { get; protected set; }

        public virtual string Nome { get; protected set; }

        public virtual string Apelido { get; protected set; }

        public virtual string Email { get; protected set; }

        public virtual string Senha { get; protected set; }

        public virtual DateTime DataCriacao { get; protected set; }

        public virtual DateTime DataModificado { get; protected set; }

        public virtual StatusUsuarioEnum Status { get; protected set; }

        public virtual Perfil Perfil { get; protected set; }

        protected Usuario() {}

        public Usuario(string nome, string apelido, string email, string senha, DateTime dataCriado, DateTime dataModificado, StatusUsuarioEnum status, Perfil perfil)
        {
            SetNome(nome);
            SetApelido(apelido);
            SetEmail(email);
            SetSenha(senha);
            SetDataCriacao(dataCriado);
            SetDataModificado(dataModificado);
            SetPerfil(perfil);
            SetStatusUsuario(status);
        }

        

        public virtual void SetNome(string nome)
        {
            if(string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome inválido.");
    
            Nome = nome;
        }
    
        public virtual void SetApelido(string apelido)
        {
            if(string.IsNullOrWhiteSpace(apelido))
                throw new ArgumentException("Apelido inválido.");

            Apelido = apelido;
        }
    
        public virtual void SetEmail(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email inválido.");
    
            Email = email;
        }
    
        public virtual void SetSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
                throw new ArgumentException("Senha inválida");
            Senha = senha;
        }

        public virtual void SetPerfil(Perfil perfil)
        {
            if (perfil == null)
                throw new ArgumentNullException(nameof(perfil), "Perfil não pode ser nulo.");

            Perfil = perfil;
        }

        public virtual void SetDataCriacao(DateTime dataCriacao)
        {
            DataCriacao = dataCriacao;
        }

        public virtual void SetDataModificado(DateTime dataModificado)
        {
            DataModificado = dataModificado;
        }

        public virtual void SetStatusUsuario(StatusUsuarioEnum status)
        {
            if(!Enum.IsDefined(typeof(StatusUsuarioEnum), status))
                throw new ArgumentException("Status inválido.");
            Status = status;
        }

        public virtual void AlterarEmail(string email)
        {
            if(DateTime.UtcNow < DataModificado.AddHours(72))
                throw new ArgumentException("Email so pode ser alterado após 72 horas.");
            if(!string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email inválido.");
            Email = email;
        }
    }
}