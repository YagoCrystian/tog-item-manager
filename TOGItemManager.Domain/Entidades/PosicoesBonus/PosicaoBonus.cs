using TOGItemManager.Domain.Entidades.Posicoes;
using TOGItemManager.Domain.Enums;

namespace TOGItemManager.Domain.Entidades.PosicoesBonus
{
    public class PosicaoBonus
    {
        public virtual int Id { get; protected set; }
        public virtual Posicao Posicao { get; protected set; }
        public virtual TipoBonusEnum TipoBonus { get; protected set; }
        public virtual int Referencia { get; protected set; }
        public virtual int Valor { get; protected set; }
        public virtual bool PorNivel { get; protected set; }

        protected PosicaoBonus() { }

        public PosicaoBonus(Posicao posicao, TipoBonusEnum tipoBonus, int referencia, int valor, bool porNivel)
        {
            SetPosicao(posicao);
            SetTipoBonus(tipoBonus);
            SetReferencia(referencia);
            SetValor(valor);
            SetPorNivel(porNivel);
        }

        public virtual void SetPosicao(Posicao posicao)
        {
            if (posicao == null)
                throw new ArgumentNullException(nameof(posicao));
            Posicao = posicao;
        }
        public virtual void SetTipoBonus(TipoBonusEnum tipoBonus)
        {
            if(!Enum.IsDefined(typeof(TipoBonusEnum), tipoBonus))
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
        public virtual void SetPorNivel(bool porNivel)
        {
            PorNivel = porNivel;
        }

    }
}