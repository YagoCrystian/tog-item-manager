using TOGItemManager.Domain.Entidades.BackgroundsBonus;

namespace TOGItemManager.Domain.Entidades.Backgrounds
{
    public class Background
    {
        public virtual int Id { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string Descricao { get; protected set; }

        public virtual IList<BackgroundBonus> Bonus { get; protected set; } = new List<BackgroundBonus>();

        protected Background(){}

        public Background(string nome, string descricao)
        {
            SetNome(nome);
            SetDescricao(descricao);
            Bonus = new List<BackgroundBonus>();
        }

        public virtual void AddBonus(BackgroundBonus bonus)
        {
            if (bonus == null)
                throw new ArgumentNullException(nameof(bonus));

            Bonus.Add(bonus);
        }
        public virtual void SetNome(string nome)
        {
            if(string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome não pode ser nulo ou vazio.");
            if(nome.Length < 3 || nome.Length > 50)
                throw new ArgumentException("O nome deve ter entre 3 e 50 caracteres.");
            Nome = nome;
        }

        public virtual void SetDescricao(string descricao)
        {
            if(string.IsNullOrEmpty(descricao))
                throw new ArgumentException("Descricao não pode ser nulo ou vazio.");
            Descricao = descricao;
        }
        
    }
}