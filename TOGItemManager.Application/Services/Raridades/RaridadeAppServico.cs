using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Application.DTOs.Raridades.Requests;
using TOGItemManager.Application.DTOs.Raridades.Responses;
using TOGItemManager.Application.Extensoes.Queryable;
using TOGItemManager.Application.Services.Raridades.Interfaces;
using TOGItemManager.Domain.Entidades.Raridades;
using TOGItemManager.Domain.Entidades.Raridades.Interfaces;

namespace TOGItemManager.Application.Services.Raridades
{
    public class RaridadeAppServico : IRaridadeAppServico
    {
        private readonly IRaridadeRepositorio raridadeRepositorio;

        public RaridadeAppServico(IRaridadeRepositorio raridadeRepositorio)
        {
            this.raridadeRepositorio = raridadeRepositorio;
        }

        public void Inserir(RaridadeCreateRequest request)
        {
            var raridade = new Raridade(request.Nome);

            raridadeRepositorio.Inserir(raridade);
        }

        public void Atualizar(RaridadeUpdateRequest request)
        {
            var raridade = raridadeRepositorio.ObterPorId(request.Id);

            if (raridade == null)
                throw new Exception("Raridade não encontrada.");

            raridade.SetNome(request.Nome);

            raridadeRepositorio.Atualizar(raridade);
        }

        public void Remover(int id)
        {
            var raridade = raridadeRepositorio.ObterPorId(id);

            if (raridade == null)
                throw new Exception("Raridade não encontrada.");

            raridadeRepositorio.Remover(raridade);
        }

        public RaridadeResponse ObterPorId(int id)
        {
            var raridade = raridadeRepositorio.ObterPorId(id);

            if (raridade == null)
                throw new Exception("Raridade não encontrada.");

            return new RaridadeResponse(raridade.Id, raridade.Nome);

        }
        public PaginacaoResponse<RaridadeResponse> Query(RaridadeFiltrarRequest filtro)
        {
            var query = raridadeRepositorio.Query();

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

            var raridades = query
                .Paginar(filtro)
                .ToList();

            var data = raridades
                .Select(r => new RaridadeResponse(r.Id, r.Nome))
                .ToList();

            return new PaginacaoResponse<RaridadeResponse>(
                data,
                filtro.Pagina,
                filtro.TamanhoPagina,
                totalItens
            );
        }
    }
}