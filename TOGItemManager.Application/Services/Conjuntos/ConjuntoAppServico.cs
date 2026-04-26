
using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Application.DTOs.Conjuntos.Requests;
using TOGItemManager.Application.DTOs.Conjuntos.Responses;
using TOGItemManager.Application.Extensoes.Queryable;
using TOGItemManager.Application.Services.Conjuntos.Interfaces;
using TOGItemManager.Domain.Entidades.Conjuntos;
using TOGItemManager.Domain.Entidades.Conjuntos.Interfaces;

namespace TOGItemManager.Application.Services.Conjuntos
{
    public class ConjuntoAppServico : IConjuntoAppServico
    {
        private readonly IConjuntoRepositorio conjuntoRepositorio;

        public ConjuntoAppServico(IConjuntoRepositorio conjuntoRepositorio)
        {
            this.conjuntoRepositorio = conjuntoRepositorio;
        }

        public void Inserir(ConjuntoInserirRequest request)
        {
            var conjunto = new Conjunto(request.Nome);

            conjuntoRepositorio.Inserir(conjunto);
        }

        public void Atualizar(ConjuntoUpdateRequest request)
        {
            var conjunto = conjuntoRepositorio.ObterPorId(request.Id);

            if (conjunto == null)
                throw new Exception("Conjunto não encontrado.");

            conjunto.SetNome(request.Nome);

            conjuntoRepositorio.Atualizar(conjunto);
        }

        public void Remover(int id)
        {
            var conjunto = conjuntoRepositorio.ObterPorId(id);

            if (conjunto == null)
                throw new Exception("Conjunto não encontrado.");

            conjuntoRepositorio.Remover(conjunto);
        }

        public ConjuntoResponse ObterPorId(int id)
        {
            var conjunto = conjuntoRepositorio.ObterPorId(id);

            if (conjunto == null)
                throw new Exception("Conjunto não encontrado.");

            return new ConjuntoResponse(conjunto.Id, conjunto.Nome);
        }

        public PaginacaoResponse<ConjuntoResponse> Query(ConjuntoFiltrarRequest filtro)
        {
            var query = conjuntoRepositorio.Query();

            if (!string.IsNullOrEmpty(filtro.Nome))
            {
                query = query.Where(c => c.Nome.Contains(filtro.Nome));
            }

            if (filtro.SortBy.ToLower() == "nome")
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(c => c.Nome)
                    : query.OrderByDescending(c => c.Nome);
            }
            else
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(c => c.Id)
                    : query.OrderByDescending(c => c.Id);
            }

            var totalItens = query.Count();

            var conjuntos = query
                .Paginar(filtro)
                .ToList();

            var data = conjuntos
                .Select(c => new ConjuntoResponse(c.Id, c.Nome))
                .ToList();

            return new PaginacaoResponse<ConjuntoResponse>(
                data,
                filtro.Pagina,
                filtro.TamanhoPagina,
                totalItens
            );
        }

    }
}