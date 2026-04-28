using TOGItemManager.Application.DTOs.Supertabelas.Requests;
using TOGItemManager.Application.DTOs.Supertabelas.Responses;
using TOGItemManager.Application.Services.Supertabelas.Interfaces;
using TOGItemManager.Domain.Entidades.Supertabelas;
using TOGItemManager.Domain.Entidades.Supertabelas.Interfaces;

namespace TOGItemManager.Application.Services.Supertabelas
{
    public class SupertabelaAppServico : ISupertabelaAppServico
    {
        private readonly ISupertabelaRepositorio supertabelaRepositorio;

        public SupertabelaAppServico(ISupertabelaRepositorio supertabelaRepositorio)
        {
            this.supertabelaRepositorio = supertabelaRepositorio;
        }

        public Supertabela ObterEValidar(int id)
        {
            Supertabela supertabela = supertabelaRepositorio.ObterPorId(id);

            if (supertabela == null)
                throw new ArgumentException("Supertabela não encontrado.");

            return supertabela;
        
        }
        public void Inserir(SupertabelaInserirRequest request)
        {
            Supertabela supertabela = new Supertabela(
                request.NP,
                request.Velocidade,
                request.Carga,
                request.DanoCura,
                request.BonusDano,
                request.Distancia,
                request.Multiplicador
            );

            supertabelaRepositorio.Inserir(supertabela); 
        }

        public void Atualizar(SupertabelaUpdateRequest request)
        {
            Supertabela supertabela = ObterEValidar(request.Id);

            supertabela.SetNP(request.NP.Value);
            supertabela.SetVelocidade(request.Velocidade.Value);
            supertabela.SetCarga(request.Carga.Value);
            supertabela.SetDanoCura(request.DanoCura);
            supertabela.SetBonusDano(request.BonusDano.Value);
            supertabela.SetDistancia(request.Distancia.Value);
            supertabela.SetMultiplicador(request.Multiplicador.Value);

            supertabelaRepositorio.Atualizar(supertabela);
        }

        public void Remover(int id)
        {
            Supertabela supertabela = ObterEValidar(id);
            
            supertabelaRepositorio.Remover(supertabela);
        }

        public SupertabelaResponse ObterPorId(int id)
        {
            Supertabela supertabela = ObterEValidar(id);

            return new SupertabelaResponse
            (
                supertabela.Id,
                supertabela.NP,
                supertabela.Velocidade,
                supertabela.Carga,
                supertabela.DanoCura,
                supertabela.BonusDano,
                supertabela.Distancia,
                supertabela.Multiplicador
            );
        }

        
    }
}