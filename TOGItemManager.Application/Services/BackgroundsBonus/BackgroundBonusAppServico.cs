using TOGItemManager.Application.DTOs.BackgroundsBonus.Requests;
using TOGItemManager.Application.Services.BackgroundsBonus.Interfaces;
using TOGItemManager.Domain.Entidades.Backgrounds;
using TOGItemManager.Domain.Entidades.Backgrounds.Interfaces;
using TOGItemManager.Domain.Entidades.BackgroundsBonus;
using TOGItemManager.Domain.Entidades.BackgroundsBonus.Interfaces;

namespace TOGItemManager.Application.Services.BackgroundsBonus
{
    public class BackgroundBonusAppServico : IBackgroundBonusAppServico
    {
        private readonly IBackgroundBonusRepositorio backgroundBonusRepositorio;
        private readonly IBackgroundRepositorio backgroundRepositorio;

        public BackgroundBonusAppServico(IBackgroundBonusRepositorio backgroundBonusRepositorio, IBackgroundRepositorio backgroundRepositorio)
        {
            this.backgroundBonusRepositorio = backgroundBonusRepositorio;
            this.backgroundRepositorio = backgroundRepositorio;
        }

        public BackgroundBonus ObterEValidar(int id)
        {
            BackgroundBonus backgroundBonus = backgroundBonusRepositorio.ObterPorId(id);

            if(backgroundBonus == null)
                throw new ArgumentException("BackgroundBonus inválido.");

            return backgroundBonus;
        }

        public void Inserir(BackgroundBonusInserirRequest request)
        {
            Background background = backgroundRepositorio.ObterPorId(request.Background);

            BackgroundBonus backgroundBonus = new BackgroundBonus(
                background,
                request.TipoBonus,
                request.Referencia,
                request.Valor,
                request.Escolha
            );

            backgroundBonusRepositorio.Inserir(backgroundBonus);
        }

        public void Atualizar(BackgroundBonusUpdateRequest request)
        {
            BackgroundBonus backgroundBonus = ObterEValidar(request.Id);

            Background background = backgroundRepositorio.ObterPorId(request.Background.Value);

            backgroundBonus.SetBackground(background);
            backgroundBonus.SetTipoBonus(request.TipoBonus.Value);
            backgroundBonus.SetReferencia(request.Referencia.Value);
            backgroundBonus.SetValor(request.Valor.Value);
            backgroundBonus.SetEscolha(request.EscolhaJogador.Value);

            backgroundBonusRepositorio.Atualizar(backgroundBonus);

        }

        public void Remover(int id)
        {
            BackgroundBonus backgroundBonus = ObterEValidar(id);

            backgroundBonusRepositorio.Remover(backgroundBonus);
        }

        
    }
}