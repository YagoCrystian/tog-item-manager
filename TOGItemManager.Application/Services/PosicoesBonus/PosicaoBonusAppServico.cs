using TOGItemManager.Application.DTOs.PosicoesBonus.Requests;
using TOGItemManager.Application.DTOs.PosicoesBonus.Responses;
using TOGItemManager.Application.Services.PosicoesBonus.Interfaces;
using TOGItemManager.Domain.Entidades.Posicoes;
using TOGItemManager.Domain.Entidades.Posicoes.Interfaces;
using TOGItemManager.Domain.Entidades.PosicoesBonus;
using TOGItemManager.Domain.Entidades.PosicoesBonus.Interfaces;

namespace TOGItemManager.Application.Services.PosicoesBonus
{
    public class PosicaoBonusAppServico : IPosicaoBonusAppServico
    {
        private readonly IPosicaoBonusRepositorio posicaoBonusRepositorio;
        private readonly IPosicaoRepositorio posicaoRepositorio;

        public PosicaoBonusAppServico(IPosicaoBonusRepositorio posicaoBonusRepositorio, IPosicaoRepositorio posicaoRepositorio)
        {
            this.posicaoBonusRepositorio = posicaoBonusRepositorio;
            this.posicaoRepositorio = posicaoRepositorio;
        }

        public PosicaoBonus ObterEValidar(int id)
        {
            PosicaoBonus posicaoBonus = posicaoBonusRepositorio.ObterPorId(id);

            if(posicaoBonus == null)
                throw new ArgumentException("PosicaoBonus inválido.");

            return posicaoBonus;
        }

        public void Inserir(PosicaoBonusInserirRequest request)
        {
            Posicao posicao = posicaoRepositorio.ObterPorId(request.Posicao);

            PosicaoBonus posicaoBonus = new PosicaoBonus(
                posicao,
                request.TipoBonus,
                request.Referencia,
                request.Valor,
                request.PorNivel
            );

            posicaoBonusRepositorio.Inserir(posicaoBonus);
        }

        public void Atualizar(PosicaoBonusUpdateRequest request)
        {
            PosicaoBonus posicaoBonus = ObterEValidar(request.Id);

            Posicao posicao = posicaoRepositorio.ObterPorId(request.Posicao.Value);

            posicaoBonus.SetPosicao(posicao);
            posicaoBonus.SetTipoBonus(request.TipoBonus.Value);
            posicaoBonus.SetReferencia(request.Referencia.Value);
            posicaoBonus.SetValor(request.Valor.Value);
            posicaoBonus.SetPorNivel(request.PorNivel.Value);

            posicaoBonusRepositorio.Atualizar(posicaoBonus);

        }

        public void Remover(int id)
        {
            PosicaoBonus posicaoBonus = ObterEValidar(id);

            posicaoBonusRepositorio.Remover(posicaoBonus);
        }

        public PosicaoBonusResponse ObterPorId(int id)
        {
            PosicaoBonus posicaoBonus = posicaoBonusRepositorio.ObterPorId(id);
            if(posicaoBonus == null)
                throw new ArgumentException("PosicaoBonus inválido.");

            return new PosicaoBonusResponse(posicaoBonus.Id, posicaoBonus.TipoBonus, posicaoBonus.Referencia, posicaoBonus.Valor, posicaoBonus.PorNivel);
        }


    }
}