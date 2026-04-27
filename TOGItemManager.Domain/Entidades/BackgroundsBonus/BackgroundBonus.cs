using TOGItemManager.Domain.Entidades.Backgrounds;
using TOGItemManager.Domain.Enums;

namespace TOGItemManager.Domain.Entidades.BackgroundsBonus
{
    public class BackgroundBonus
    {
        public virtual int Id { get; protected set; }
        public virtual Background Background { get; protected set; }
        public virtual TipoBackgroundBonusEnum TipoBonus { get; protected set; }
        public virtual int Referencia { get; protected set; }
        public virtual int Valor { get; protected set; }
        public virtual bool EscolhaJogador { get; protected set; }
        
        protected BackgroundBonus(){}

        public BackgroundBonus(Background background, TipoBackgroundBonusEnum tipoBonus, int referencia, int valor, bool escolha)
        {
            SetBackground(background);
            SetTipoBonus(tipoBonus);
            SetReferencia(referencia);
            SetValor(valor);
            SetEscolha(escolha);
        }
        
        public virtual void SetBackground(Background background)
        {
            if(background == null)
                throw new ArgumentNullException(nameof(background), "O background não pode ser nulo.");

            Background = background;
        }

        public virtual void SetTipoBonus(TipoBackgroundBonusEnum tipoBonus)
        {
            if(!Enum.IsDefined(typeof(TipoBackgroundBonusEnum), tipoBonus))
                throw new ArgumentException("Tipo de bonus inválido.");
            
            TipoBonus = tipoBonus;
        }

        public virtual void SetReferencia(int referencia)
        {
            if(referencia < 0)
                throw new ArgumentException("Referencia inválida.");

            Referencia = referencia;
        }

        public virtual void SetValor(int valor)
        {
            if(valor < 0)
                throw new ArgumentException("Valor inválido.");

            Valor = valor;
        }

        public virtual void SetEscolha(bool escolha)
        {
            EscolhaJogador = escolha;
        }
    }
}