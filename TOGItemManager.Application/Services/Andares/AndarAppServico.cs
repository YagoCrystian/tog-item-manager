using TOGItemManager.Application.DTOs.Andares.Requests;
using TOGItemManager.Application.DTOs.Andares.Responses;
using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Application.DTOs.Items.Responses;
using TOGItemManager.Application.Extensoes.Queryable;
using TOGItemManager.Application.Services.Andares.Interfaces;
using TOGItemManager.Domain.Entidades.Andares;
using TOGItemManager.Domain.Entidades.Andares.Interfaces;
using TOGItemManager.Domain.Entidades.NPCs.Interfaces;

namespace TOGItemManager.Application.Services.Andares
{
    public class AndarAppServico : IAndarAppServico
    {
        private readonly IAndarRepositorio andarRepositorio;
        private readonly INPCRepositorio npcRepositorio;

        public AndarAppServico(IAndarRepositorio andarRepositorio, INPCRepositorio npcRepositorio)
        {
            this.andarRepositorio = andarRepositorio;
            this.npcRepositorio = npcRepositorio;
        }

        public void Inserir(AndarInserirRequest request)
        {
            var governante = npcRepositorio.ObterPorId(request.Governante);
            var administrador = npcRepositorio.ObterPorId(request.Administrador);
            var andar = new Andar(request.Nome, governante, administrador);

            andarRepositorio.Inserir(andar);
        }

        public void Atualizar(AndarUpdateRequest request)
        {
            var andar = andarRepositorio.ObterPorId(request.Id);

            if (andar == null)
                throw new Exception("Andar não encontrado.");

            var governante = npcRepositorio.ObterPorId(request.Governante);
            var administrador = npcRepositorio.ObterPorId(request.Administrador);

            andar.SetNome(request.Nome);
            andar.SetGovernante(governante);
            andar.SetAdministrador(administrador);

            andarRepositorio.Atualizar(andar);
        }

        public void Remover(int id)
        {
            var andar = andarRepositorio.ObterPorId(id);

            if (andar == null)
                throw new Exception("Andar não encontrado.");

            andarRepositorio.Remover(andar);
        }

        public Andar ObterPorId(int id)
        {
            var andar = andarRepositorio.ObterPorId(id);

            if (andar == null)
                throw new Exception("Andar não encontrado.");

            return andar;
        }

        public PaginacaoResponse<AndarResponse> Query(AndarFiltrarRequest filtro)
        {
            var query = andarRepositorio.Query();

            if (!string.IsNullOrEmpty(filtro.Nome))
            {
                query = query.Where(c => c.Nome.Contains(filtro.Nome));
            }

            if (filtro.Governante.HasValue)
            {
                query = query.Where(c => c.Governante.Id == filtro.Governante.Value);
            }

            if (filtro.Administrador.HasValue)
            {
                query = query.Where(c => c.Administrador.Id == filtro.Administrador.Value);
            }

            if (filtro.SortBy.ToLower() == "nome")
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(c => c.Nome)
                    : query.OrderByDescending(c => c.Nome);
            }
            else if (filtro.SortBy.ToLower() == "governante")
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(c => c.Governante.Id)
                    : query.OrderByDescending(c => c.Governante.Id);
            }
            else if (filtro.SortBy.ToLower() == "administrador")
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(c => c.Administrador.Id)
                    : query.OrderByDescending(c => c.Administrador.Id);
            }
            else
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(c => c.Id)
                    : query.OrderByDescending(c => c.Id);
            }

            var totalItens = query.Count();

            var andares = query
                .Paginar(filtro)
                .ToList();

            var data = andares
                .Select(r => new AndarResponse(r.Id, r.Nome, r.Governante.Id, r.Administrador.Id))
                .ToList();
                
            return new PaginacaoResponse<AndarResponse>(
                data,
                filtro.Pagina,
                filtro.TamanhoPagina,
                totalItens
            );
        }
        public IList<ItemResponse> ListarItensDoAndar(int andarId)
        {
            var andar = andarRepositorio.ObterPorId(andarId);
        
            if (andar == null)
                throw new Exception("Andar não encontrado.");
        
            return andar.Itens.Select(item => new ItemResponse(
                item.Id,
                item.Nome,
                item.Descricao,
                item.Efeito,
                item.Valor,
                item.Dono,
                item.Categoria.Id,
                item.Raridade.Id,
                item.Conjunto.Id
            )).ToList();
        }

    }
}