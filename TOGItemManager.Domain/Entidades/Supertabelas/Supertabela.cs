namespace TOGItemManager.Domain.Entidades.Supertabelas
{
    public class Supertabela
    {
        public virtual int Id { get; protected set; }
        public virtual int NP { get; protected set; }
        public virtual int Velocidade { get; protected set; }
        public virtual int Carga { get; protected set; }
        public virtual string DanoCura { get; protected set; }
        public virtual int BonusDano { get; protected set; }
        public virtual decimal Distancia { get; protected set; }
        public virtual decimal Multiplicador { get; protected set; }
        
        protected Supertabela() { }

        public Supertabela(
            int np, 
            int velocidade, 
            int carga, 
            string danoCura, 
            int bonusDano, 
            decimal distancia, 
            decimal multiplicador
        )
        {
            SetNP(np);
            SetVelocidade(velocidade);
            SetCarga(carga);
            SetDanoCura(danoCura);
            SetBonusDano(bonusDano);
            SetDistancia(distancia);
            SetMultiplicador(multiplicador);
        }

        public virtual void SetNP(int np)
        {
            if (np < 0)
                throw new ArgumentException("NP deve ser maior que zero.");

            NP = np;
        }
        public virtual void SetVelocidade(int velocidade)
        {
            if (velocidade < 0)
                throw new ArgumentException("Velocidade deve ser maior que zero.");

            Velocidade = velocidade;
        }
        public virtual void SetCarga(int carga)
        {
            if (carga < 0)
                throw new ArgumentException("Carga deve ser maior que zero.");

            Carga = carga;
        }
        public virtual void SetDanoCura(string danoCura)
        {
            if (string.IsNullOrWhiteSpace(danoCura))
                throw new ArgumentException("Dano/Cura não pode ser vazio.");

            DanoCura = danoCura;
        }
        public virtual void SetBonusDano(int bonusDano)
        {
            BonusDano = bonusDano;
        }
        public virtual void SetDistancia(decimal distancia)
        {
            if (distancia < 0)
                throw new ArgumentException("Distância deve ser maior que zero.");

            Distancia = distancia;
        }
        public virtual void SetMultiplicador(decimal multiplicador)
        {
            if (multiplicador < 0)
                throw new ArgumentException("Multiplicador deve ser maior que zero.");

            Multiplicador = multiplicador;
        }
    }
}