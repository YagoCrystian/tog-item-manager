namespace TOGItemManager.Domain.Entidades.NPCs
{
    public class NPC
    {
        public virtual int Id { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string Tipo { get; protected set; }

        protected NPC() { }

        public NPC(string nome, string tipo)
        {
            SetNome(nome);
            SetTipo(tipo);
        }

        public virtual void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do NPC não pode ser vazio.");
            if (nome.Length < 3 || nome.Length > 100)
                throw new ArgumentException("O nome do NPC deve ter entre 3 e 100 caracteres.");

            Nome = nome;
        }

        public virtual void SetTipo(string tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo))
                throw new ArgumentException("O tipo do NPC não pode ser vazio.");
            if (tipo.Length < 3 || tipo.Length > 100)
                throw new ArgumentException("O tipo do NPC deve ter entre 3 e 100 caracteres.");

            Tipo = tipo;
        }
    }
}