namespace TOGItemManager.Domain.Entidades.Categorias
{
    public class Categoria
    {
        public virtual int Id { get; protected set; }
        public virtual string Nome { get; protected set; }

        protected Categoria() { }

        public Categoria(string nome)
        {
            SetNome(nome);
        }

        public virtual void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome da categoria não pode ser vazio.");
            if (nome.Length < 3 || nome.Length > 100)
                throw new ArgumentException("O nome da categoria deve ter entre 3 e 100 caracteres.");

            Nome = nome;
        }

    }
}