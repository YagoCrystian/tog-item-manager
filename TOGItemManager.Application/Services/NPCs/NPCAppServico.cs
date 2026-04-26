using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Application.DTOs.NPCs.Requests;
using TOGItemManager.Application.DTOs.NPCs.Responses;
using TOGItemManager.Application.Extensoes.Queryable;
using TOGItemManager.Application.Services.NPCs.Interfaces;
using TOGItemManager.Domain.Entidades.NPCs;
using TOGItemManager.Domain.Entidades.NPCs.Interfaces;

namespace TOGItemManager.Application.Services.NPCs
{
    public class NPCAppServico : INPCAppServico
    {
        private readonly INPCRepositorio npcRepositorio;

        public NPCAppServico(INPCRepositorio npcRepositorio)
        {
            this.npcRepositorio = npcRepositorio;
        }

        public void Inserir(NPCInserirRequest request)
        {
            var npc = new NPC(request.Nome, request.Tipo);

            npcRepositorio.Inserir(npc);
        }

        public void Atualizar(NPCUpdateRequest request)
        {
            var npc = npcRepositorio.ObterPorId(request.Id);

            if (npc == null)
                throw new Exception("NPC não encontrado.");

            npc.SetNome(request.Nome);
            npc.SetTipo(request.Tipo);

            npcRepositorio.Atualizar(npc);
        }

        public void Remover(int id)
        {
            var npc = npcRepositorio.ObterPorId(id);

            if (npc == null)
                throw new Exception("NPC não encontrado.");

            npcRepositorio.Remover(npc);
        }

        public NPC ObterPorId(int id)
        {
            var npc = npcRepositorio.ObterPorId(id);

            if (npc == null)
                throw new Exception("NPC não encontrado.");

            return npc;
        }

        public PaginacaoResponse<NPCResponse> Query(NPCFiltrarRequest filtro)
        {
            var query = npcRepositorio.Query();

            if (!string.IsNullOrEmpty(filtro.Nome))
            {
                query = query.Where(c => c.Nome.Contains(filtro.Nome));
            }

            if (!string.IsNullOrEmpty(filtro.Tipo))
            {
                query = query.Where(c => c.Tipo.Contains(filtro.Tipo));
            }

            if (filtro.SortBy.ToLower() == "nome")
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(c => c.Nome)
                    : query.OrderByDescending(c => c.Nome);
            }
            else if (filtro.SortBy.ToLower() == "tipo")
            {
                query = filtro.Direction.ToLower() == "asc"
                    ? query.OrderBy(c => c.Tipo)
                    : query.OrderByDescending(c => c.Tipo);
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
                .Select(c => new NPCResponse(c.Id, c.Nome, c.Tipo))
                .ToList();

            return new PaginacaoResponse<NPCResponse>(
                data,
                filtro.Pagina,
                filtro.TamanhoPagina,
                totalItens
            );
        }

    }
}