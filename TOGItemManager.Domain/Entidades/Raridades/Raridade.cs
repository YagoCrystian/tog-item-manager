namespace TOGItemManager.Domain.Entidades.Raridades
{
    public class Raridade
    {
        public virtual int Id { get; protected set; }
        public virtual string Nome { get; protected set; }

        protected Raridade() { }

        public Raridade(string nome)
        {
            SetNome(nome);
        }

        public virtual void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome da raridade é obrigatório.");
            if (nome.Length < 3 ||nome.Length > 100)
                throw new ArgumentException("O nome da raridade não pode exceder 100 caracteres.");

            Nome = nome;
        }


    }
}