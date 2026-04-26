using TOGItemManager.Domain.Enums;

namespace TOGItemManager.Domain.Entidades.Perfis
{
    public class Perfil
    {
        public virtual int Id { get; protected set; }

        public virtual PerfilEnum PerfilTipo { get; protected set; }

        public virtual string Descricao { get; protected set; }

        protected Perfil() {}

        public Perfil(PerfilEnum perfilTipo, string descricao)
        {
            SetPerfilTipo(perfilTipo);
            SetDescricao(descricao);
        }

        public virtual void SetDescricao(string descricao)
        {
            if(string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentException("A descrição do perfil não pode ser vazia.");

            if(descricao.Length < 3 || descricao.Length > 200)
                throw new ArgumentException("A descrição deve ter entre 3 e 200 caracteres.");

            Descricao = descricao;
        }

        public virtual void SetPerfilTipo(PerfilEnum perfilTipo)
        {
            if(!Enum.IsDefined(typeof(PerfilEnum), perfilTipo))
                throw new ArgumentException("Perfil inválido.");

            PerfilTipo = perfilTipo;
        }
    }
}