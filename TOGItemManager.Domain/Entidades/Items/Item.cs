using TOGItemManager.Domain.Entidades.Andares;
using TOGItemManager.Domain.Entidades.Categorias;
using TOGItemManager.Domain.Entidades.Conjuntos;
using TOGItemManager.Domain.Entidades.Raridades;

namespace TOGItemManager.Domain.Entidades.Items
{
    public class Item
    {
        public virtual int Id { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual string Efeito { get; protected set; }
        public virtual float Valor { get; protected set; }
        public virtual string Dono { get; protected set; }
        public virtual Categoria Categoria { get; protected set; }
        public virtual Raridade Raridade { get; protected set; }
        public virtual Conjunto Conjunto { get; protected set; }
        public virtual IList<Andar> Andares { get; protected set; } = new List<Andar>();

        
        protected Item() { }

        public Item(string nome, string descricao, string efeito, float valor, string dono, Categoria categoria, Raridade raridade, Conjunto conjunto)
        {
            SetNome(nome);
            SetDescricao(descricao);
            SetEfeito(efeito);
            SetValor(valor);
            SetDono(dono);
            SetCategoria(categoria);
            SetRaridade(raridade);
            SetConjunto(conjunto);
        }

        public virtual void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do item não pode ser vazio.");
            if (nome.Length < 2 || nome.Length > 50)
                throw new ArgumentException("O nome do item deve ter entre 3 e 50 caracteres.");

            Nome = nome;
        }

        public virtual void SetDescricao(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentException("A descrição do item não pode ser vazia.");
            if (descricao.Length < 10 || descricao.Length > 35000)
                throw new ArgumentException("A descrição do item deve ter entre 10 e 35000 caracteres.");

            Descricao = descricao;
        }

        public virtual void SetEfeito(string efeito)
        {
            if (string.IsNullOrWhiteSpace(efeito))
                throw new ArgumentException("O efeito do item não pode ser vazio.");
            if (efeito.Length < 5 || efeito.Length > 35000)
                throw new ArgumentException("O efeito do item deve ter entre 5 e 35000 caracteres.");

            Efeito = efeito;
        }

        public virtual void SetValor(float valor)
        {
            if (valor < 0)
                throw new ArgumentException("O valor do item não pode ser negativo.");

            Valor = valor;
        }

        public virtual void SetDono(string dono)
        {
            Dono = dono;
        }

        public virtual void SetCategoria(Categoria categoria)
        {
            if (categoria == null)
                throw new ArgumentNullException(nameof(categoria), "A categoria do item não pode ser nula.");

            Categoria = categoria;
        }

        public virtual void SetRaridade(Raridade raridade)
        {
            if (raridade == null)
                throw new ArgumentNullException(nameof(raridade), "A raridade do item não pode ser nula.");

            Raridade = raridade;
        }

        public virtual void SetConjunto(Conjunto conjunto)
        {
            Conjunto = conjunto;
        }

        public virtual void AdicionarAndar(Andar andar)
        {
            if (andar == null)
                throw new ArgumentNullException(nameof(andar));

            if (!Andares.Contains(andar))
            {
                Andares.Add(andar);
            }
        }
    }
}