using TOGItemManager.Application.DTOs.Backgrounds.Requests;
using TOGItemManager.Application.DTOs.Backgrounds.Responses;
using TOGItemManager.Application.DTOs.BackgroundsBonus.Responses;
using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Application.Extensoes.Queryable;
using TOGItemManager.Application.Services.Backgrounds.Interfaces;
using TOGItemManager.Domain.Entidades.Backgrounds;
using TOGItemManager.Domain.Entidades.Backgrounds.Interfaces;

namespace TOGItemManager.Application.Services.Backgrounds
{
    public class BackgroundAppServico : IBackgroundAppServico
    {
        private readonly IBackgroundRepositorio backgroundRepositorio;
        public BackgroundAppServico(IBackgroundRepositorio backgroundRepositorio)
        {
            this.backgroundRepositorio = backgroundRepositorio;
        }

        public Background ObterEValidar(int id)
        {
            Background background = backgroundRepositorio.ObterPorId(id);

            if (background == null)
                throw new ArgumentException("Background não encontrado.");

            return background;
        
        }
        public void Inserir(BackgroundInserirRequest request)
        {
            Background background = new Background(
                request.Nome,
                request.Descricao
            );

            backgroundRepositorio.Inserir(background); 
        }

        public void Atualizar(BackgroundUpdateRequest request)
        {
            Background background = ObterEValidar(request.Id);

            if(!string.IsNullOrWhiteSpace(request.Nome))
                background.SetNome(request.Nome);

            if(!string.IsNullOrWhiteSpace(request.Descricao))
                background.SetDescricao(request.Descricao);

            backgroundRepositorio.Atualizar(background);
        }

        public void Remover(int id)
        {
            Background background = ObterEValidar(id);
            
            backgroundRepositorio.Remover(background);
        }

        public PaginacaoResponse<BackgroundResponse> Query(BackgroundFiltrarRequest filtro)
        {
            var query = backgroundRepositorio.Query();

            if (!string.IsNullOrWhiteSpace(filtro.Nome))
            {
                query = query.Where(b => b.Nome.Contains(filtro.Nome));
            }

            if(filtro.SortBy.ToLower() == "nome")
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(b => b.Nome)
                    : query.OrderByDescending(b => b.Nome);
            }
            else
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(b => b.Id)
                    : query.OrderByDescending(b => b.Id);
            }

            var totalItens = query.Count();

            var backgrounds = query.Paginar(filtro).ToList();

            var data = backgrounds.Select(b => new BackgroundResponse(
                b.Id, 
                b.Nome, 
                b.Descricao,
                b.Bonus.Select(bb => new BackgroundBonusResponse(
                    bb.Id,
                    bb.TipoBonus,
                    bb.Referencia,
                    bb.Valor,
                    bb.EscolhaJogador
                ))
                .ToList()))
                .ToList();

            return new PaginacaoResponse<BackgroundResponse>(
                data,
                filtro.Pagina,
                filtro.TamanhoPagina,
                totalItens
            );
        }
    }
}