using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Application.DTOs.Items.Requests;
using TOGItemManager.Application.DTOs.Items.Responses;
using TOGItemManager.Application.Extensoes.Queryable;
using TOGItemManager.Application.Services.Items.Interfaces;
using TOGItemManager.Domain.Entidades.Andares.Interfaces;
using TOGItemManager.Domain.Entidades.Categorias.Interfaces;
using TOGItemManager.Domain.Entidades.Conjuntos.Interfaces;
using TOGItemManager.Domain.Entidades.Items;
using TOGItemManager.Domain.Entidades.Items.Interfaces;
using TOGItemManager.Domain.Entidades.Raridades.Interfaces;

namespace TOGItemManager.Application.Services.Items
{
    public class ItemAppServico : IItemAppServico
    {
        private readonly IItemRepositorio itemRepositorio;
        private readonly ICategoriaRepositorio categoriaRepositorio;
        private readonly IRaridadeRepositorio raridadeRepositorio;
        private readonly IConjuntoRepositorio conjuntoRepositorio;
        private readonly IAndarRepositorio andarRepositorio;

        public ItemAppServico(IItemRepositorio itemRepositorio, IRaridadeRepositorio raridadeRepositorio, ICategoriaRepositorio categoriaRepositorio, IConjuntoRepositorio conjuntoRepositorio, IAndarRepositorio andarRepositorio)
        {
            this.itemRepositorio = itemRepositorio;
            this.raridadeRepositorio = raridadeRepositorio;
            this.categoriaRepositorio = categoriaRepositorio;
            this.conjuntoRepositorio = conjuntoRepositorio;
            this.andarRepositorio = andarRepositorio;
        }

        public void Inserir(ItemInserirRequest request)
        {
            var categoria = categoriaRepositorio.ObterPorId(request.Categoria);
            var raridade = raridadeRepositorio.ObterPorId(request.Raridade);
            var conjunto = conjuntoRepositorio.ObterPorId(request.Conjunto);

            var item = new Item(request.Nome, request.Descricao, request.Efeito, request.Valor, request.Dono ,categoria, raridade, conjunto);

            itemRepositorio.Inserir(item);
        }

        public void Atualizar(ItemUpdateRequest request)
        {
            var item = itemRepositorio.ObterPorId(request.Id);

            if (item == null)
                throw new Exception("Item não encontrado.");

            var categoria = categoriaRepositorio.ObterPorId(request.Categoria);
            if (categoria == null)
                throw new Exception("Categoria inválida.");

            var raridade = raridadeRepositorio.ObterPorId(request.Raridade);
            if (raridade == null)
                throw new Exception("Raridade inválida.");

            var conjunto = conjuntoRepositorio.ObterPorId(request.Conjunto);
            if (conjunto == null)
                throw new Exception("Conjunto inválido.");

            item.SetNome(request.Nome);
            item.SetDescricao(request.Descricao);
            item.SetEfeito(request.Efeito);
            item.SetValor(request.Valor);
            item.SetDono(request.Dono);

            item.SetCategoria(categoria);
            item.SetRaridade(raridade);
            item.SetConjunto(conjunto);

            itemRepositorio.Atualizar(item);
        }

        public void AtualizarParcial(ItemPatchRequest request)
        {
            var item = itemRepositorio.ObterPorId(request.Id);

            if (item == null)
                throw new Exception("Item não encontrado.");

            if (!string.IsNullOrWhiteSpace(request.Nome))
                item.SetNome(request.Nome);

            if (!string.IsNullOrWhiteSpace(request.Descricao))
                item.SetDescricao(request.Descricao);

            if (!string.IsNullOrWhiteSpace(request.Efeito))
                item.SetEfeito(request.Efeito);

            if (request.Valor.HasValue)
                item.SetValor(request.Valor.Value);

            if (!string.IsNullOrWhiteSpace(request.Dono))
                item.SetDono(request.Dono);

            if (request.Categoria.HasValue)
            {
                var categoria = categoriaRepositorio.ObterPorId(request.Categoria.Value);
                item.SetCategoria(categoria);
            }

            if (request.Raridade.HasValue)
            {
                var raridade = raridadeRepositorio.ObterPorId(request.Raridade.Value);
                item.SetRaridade(raridade);
            }

            if (request.Conjunto.HasValue)
            {
                var conjunto = conjuntoRepositorio.ObterPorId(request.Conjunto.Value);
                item.SetConjunto(conjunto);
            }

            itemRepositorio.Atualizar(item);
        }

        public void Remover(int id)
        {
            var item = itemRepositorio.ObterPorId(id);

            if (item == null)
                throw new Exception("Item não encontrado.");

            itemRepositorio.Remover(item);
        }

        public ItemResponse ObterPorId(int id)
        {
            var item = itemRepositorio.ObterPorId(id);
        
            if (item == null)
                throw new Exception("Item não encontrado.");
        
            return new ItemResponse(
                item.Id,
                item.Nome,
                item.Descricao,
                item.Efeito,
                item.Valor,
                item.Dono,
                item.Categoria.Id,
                item.Raridade.Id,
                item.Conjunto.Id
            );
        }

        public PaginacaoResponse<ItemResponse> Query(ItemFiltrarRequest filtro)
        {
            var query = itemRepositorio.Query();

            if (!string.IsNullOrEmpty(filtro.Nome))
            {
                query = query.Where(c => c.Nome.Contains(filtro.Nome));
            }

            if (filtro.Valor.HasValue)
            {
                query = query.Where(i => i.Valor == filtro.Valor);
            }

            if(!string.IsNullOrEmpty(filtro.Dono))
            {
                query = query.Where(i => i.Dono.Contains(filtro.Dono));
            }

            if (filtro.Categoria.HasValue)
            {
                query = query.Where(i => i.Categoria.Id == filtro.Categoria.Value);
            }

            if (filtro.Conjunto.HasValue)
            {
                query = query.Where(i => i.Conjunto.Id == filtro.Conjunto.Value);
            }
            if (filtro.Categoria.HasValue)
            {
                query = query.Where(i => i.Categoria.Id == filtro.Categoria.Value);
            }
            if (filtro.Raridade.HasValue)
            {
                query = query.Where(i => i.Raridade.Id == filtro.Raridade.Value);
            }

            if (filtro.SortBy.ToLower() == "nome")
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(c => c.Nome)
                    : query.OrderByDescending(c => c.Nome);
            }
            else if (filtro.SortBy.ToLower() == "valor")
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(c => c.Valor)
                    : query.OrderByDescending(c => c.Valor);
            }
            else if (filtro.SortBy.ToLower() == "dono")
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(c => c.Dono)
                    : query.OrderByDescending(c => c.Dono);
            }
            else if (filtro.SortBy.ToLower() == "categoria")
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(c => c.Categoria)
                    : query.OrderByDescending(c => c.Categoria);
            }
            else if (filtro.SortBy.ToLower() == "raridade")
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(c => c.Raridade)
                    : query.OrderByDescending(c => c.Raridade);
            }
            else if (filtro.SortBy.ToLower() == "conjunto")
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(c => c.Conjunto)
                    : query.OrderByDescending(c => c.Conjunto);
            }
            else
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(c => c.Id)
                    : query.OrderByDescending(c => c.Id);
            }

            var totalItens = query.Count();

            var itens = query
                .Paginar(filtro)
                .ToList();

            var data = itens
                .Select(c => new ItemResponse(c.Id, c.Nome, c.Descricao, c.Efeito, c.Valor, c.Dono, c.Categoria.Id, c.Raridade.Id, c.Conjunto.Id))
                .ToList();

            return new PaginacaoResponse<ItemResponse>(
                data,
                filtro.Pagina,
                filtro.TamanhoPagina,
                totalItens
            );
        }

        public void AdicionarItemAoAndar(int itemId, int andarId)
        {
            var andar = andarRepositorio.ObterPorId(andarId);
            if (andar == null)
                throw new Exception("Andar não encontrado.");

            var item = itemRepositorio.ObterPorId(itemId);
            if (item == null)
                throw new Exception("Item não encontrado.");

            item.AdicionarAndar(andar);

            itemRepositorio.Atualizar(item);
        }

    }
}