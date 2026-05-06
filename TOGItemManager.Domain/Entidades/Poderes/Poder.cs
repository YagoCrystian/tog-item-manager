using System.Security.Cryptography;

namespace TOGItemManager.Domain.Entidades.Poderes
{
    public class Poder
    {
        public virtual int Id { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string TipoPoder { get; protected set; }
        public virtual string Descricao { get; protected set; }
        
        protected Poder() { }

        public Poder(string nome, string tipoPoder, string descricao)
        {
            SetNome(nome);
            SetTipoPoder(tipoPoder);
            SetDescricao(descricao);
        }

        public virtual void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do poder não pode ser vazio.");

            Nome = nome;
        }

        public virtual void SetTipoPoder(string tipoPoder)
        {
            if (string.IsNullOrWhiteSpace(tipoPoder))
                throw new ArgumentException("O tipo do poder não pode ser vazio.");

            TipoPoder = tipoPoder;
        }

        public virtual void SetDescricao(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentException("A descrição do poder não pode ser vazia.");

            Descricao = descricao;
        }
    }
}