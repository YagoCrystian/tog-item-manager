using TOGItemManager.Domain.Entidades.Items;
using TOGItemManager.Domain.Entidades.NPCs;

namespace TOGItemManager.Domain.Entidades.Andares
{
    public class Andar
    {
        public virtual int Id { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual NPC Governante { get; protected set; }
        public virtual NPC Administrador { get; protected set; }
        public virtual IList<Item> Itens { get; protected set; } = new List<Item>();

        
        protected Andar() { }

        public Andar(string nome, NPC governante, NPC administrador)
        {
            SetNome(nome);
            SetGovernante(governante);
            SetAdministrador(administrador);
        }

        public virtual void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do andar não pode ser vazio.");
            if (nome.Length < 3 || nome.Length > 20)
                throw new ArgumentException("O nome do andar deve ter entre 3 e 20 caracteres.");

            Nome = nome;
        }

        public virtual void SetGovernante(NPC governante)
        {
            if (governante == null)
                throw new ArgumentNullException(nameof(governante), "O governante do andar não pode ser nulo.");

            Governante = governante;
        }

        public virtual void SetAdministrador(NPC administrador)
        {
            if (administrador == null)
                throw new ArgumentNullException(nameof(administrador), "O administrador do andar não pode ser nulo.");

            Administrador = administrador;
        }
    }
}