namespace TOGItemManager.Domain.Entidades.Conjuntos
{
    public class Conjunto
    {
        public virtual int Id { get; protected set; }
        public virtual string Nome { get; protected set; }

        protected Conjunto() { }

        public Conjunto(string nome)
        {
            SetNome(nome);
        }

        public virtual void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do conjunto não pode ser vazio.");
            if (nome.Length < 3 || nome.Length > 30)
                throw new ArgumentException("O nome do conjunto deve ter entre 3 e 30 caracteres.");

            Nome = nome;
        }
    }


}