using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Application.DTOs.Poderes.Requests;
using TOGItemManager.Application.DTOs.Poderes.Responses;
using TOGItemManager.Application.Extensoes.Queryable;
using TOGItemManager.Application.Services.Poderes.Interfaces;
using TOGItemManager.Domain.Entidades.Poderes;
using TOGItemManager.Domain.Entidades.Poderes.Interfaces;

namespace TOGItemManager.Application.Services.Poderes
{
    public class PoderAppServico : IPoderAppServico
    {
        private readonly IPoderRepositorio poderRepositorio;

        public PoderAppServico(IPoderRepositorio poderRepositorio)
        {
            this.poderRepositorio = poderRepositorio;
        }

        public Poder ObterEValidar(int id)
        {
            Poder poder = poderRepositorio.ObterPorId(id);

            if (poder == null)
                throw new ArgumentException("Poder não encontrado.");

            return poder;
        
        }
        public void Inserir(PoderInserirRequest request)
        {
            Poder poder = new Poder(
                request.Nome,
                request.TipoPoder,
                request.Descricao
            );

            poderRepositorio.Inserir(poder); 
        }

        public void Atualizar(PoderUpdateRequest request)
        {
            Poder poder = ObterEValidar(request.Id);

            if(!string.IsNullOrWhiteSpace(request.Nome))
                poder.SetNome(request.Nome);

            if(!string.IsNullOrWhiteSpace(request.TipoPoder))
                poder.SetTipoPoder(request.TipoPoder);

            if(!string.IsNullOrWhiteSpace(request.Descricao))
                poder.SetDescricao(request.Descricao);

            poderRepositorio.Atualizar(poder);
        }

        public void Remover(int id)
        {
            Poder poder = ObterEValidar(id);
            
            poderRepositorio.Remover(poder);
        }

        public PaginacaoResponse<PoderResponse> Query(PoderFiltrarRequest filtro)
        {
            var query = poderRepositorio.Query();

            if (!string.IsNullOrWhiteSpace(filtro.Nome))
            {
                query = query.Where(b => b.Nome.Contains(filtro.Nome));
            }

            if (!string.IsNullOrWhiteSpace(filtro.TipoPoder))
            {
                query = query.Where(b => b.TipoPoder.Contains(filtro.TipoPoder));
            }

            if(filtro.SortBy.ToLower() == "nome")
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(b => b.Nome)
                    : query.OrderByDescending(b => b.Nome);
            }

            else if(filtro.SortBy.ToLower() == "tipopoder")
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(b => b.TipoPoder)
                    : query.OrderByDescending(b => b.TipoPoder);
            }

            else
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(b => b.Id)
                    : query.OrderByDescending(b => b.Id);
            }

            var totalItens = query.Count();

            var poderes = query.Paginar(filtro).ToList();

            var data = poderes.Select(b => new PoderResponse(
                b.Id, 
                b.Nome, 
                b.TipoPoder,
                b.Descricao))
                .ToList();

            return new PaginacaoResponse<PoderResponse>(
                data,
                filtro.Pagina,
                filtro.TamanhoPagina,
                totalItens
            );
        }
    }
}