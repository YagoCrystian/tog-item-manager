namespace TOGItemManager.Domain.Entidades.Posicoes
{
    public class Posicao
    {
        public virtual int Id { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string Descricao { get; protected set; }

        protected Posicao() { }

        public Posicao(string nome, string Descricao)
        {
            SetNome(nome);
            SetDescricao(Descricao);
        }

        public virtual void SetNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("O nome da posição não pode ser vazio.");

            Nome = nome;
        }

        public virtual void SetDescricao(string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
                throw new ArgumentException("A descrição da posição não pode ser vazia.");

            Descricao = descricao;
        }
    }
}