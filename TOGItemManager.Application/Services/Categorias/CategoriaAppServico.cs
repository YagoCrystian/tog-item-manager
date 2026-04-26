using TOGItemManager.Application.DTOs.Categorias.Requests;
using TOGItemManager.Application.DTOs.Categorias.Responses;
using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Application.Services.Categorias.Interfaces;
using TOGItemManager.Domain.Entidades.Categorias;
using TOGItemManager.Domain.Entidades.Categorias.Interfaces;
using TOGItemManager.Application.Extensoes.Queryable;


namespace TOGItemManager.Application.Services.Categorias
{
    public class CategoriaAppServico : ICategoriaAppServico
    {
        private readonly ICategoriaRepositorio categoriaRepositorio;

        public CategoriaAppServico(ICategoriaRepositorio categoriaRepositorio)
        {
            this.categoriaRepositorio = categoriaRepositorio;
        }

        public void Inserir(CategoriaInserirRequest request)
        {
            var categoria = new Categoria(request.Nome);

            categoriaRepositorio.Inserir(categoria);
        }

        public void Atualizar(CategoriaAtualizarRequest request)
        {
            var categoria = categoriaRepositorio.ObterPorId(request.Id);

            if (categoria == null)
                throw new Exception("Categoria não encontrada.");

            categoria.SetNome(request.Nome);

            categoriaRepositorio.Atualizar(categoria);
        }

        public void Remover(int id)
        {
            var categoria = categoriaRepositorio.ObterPorId(id);

            if (categoria == null)
                throw new Exception("Categoria não encontrada.");

            categoriaRepositorio.Remover(categoria);
        }

        public CategoriaResponse ObterPorId(int id)
        {
            var categoria = categoriaRepositorio.ObterPorId(id);

            if (categoria == null)
                throw new Exception("Categoria não encontrada.");

            return new CategoriaResponse(categoria.Id, categoria.Nome);

        }

        public PaginacaoResponse<CategoriaResponse> Query(CategoriaFiltrarRequest filtro)
        {
            var query = categoriaRepositorio.Query();

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

            var categorias = query
                .Paginar(filtro)
                .ToList();

            var data = categorias
                .Select(c => new CategoriaResponse(c.Id, c.Nome))
                .ToList();

            return new PaginacaoResponse<CategoriaResponse>(
                data,
                filtro.Pagina,
                filtro.TamanhoPagina,
                totalItens
            );
        }
    }
}
