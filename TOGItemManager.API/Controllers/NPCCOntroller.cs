using Microsoft.AspNetCore.Mvc;
using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Application.DTOs.NPCs.Requests;
using TOGItemManager.Application.DTOs.NPCs.Responses;
using TOGItemManager.Application.Services.NPCs.Interfaces;

namespace TOGItemManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NPCController : ControllerBase
    {
        private readonly INPCAppServico npcAppServico;

        public NPCController(INPCAppServico npcAppServico)
        {
            this.npcAppServico = npcAppServico;
        }

        /// <summary>
        /// Cria um novo NPC
        /// </summary>
        /// <param name="request">Dados do NPC</param>
        /// <returns>NPC criado com sucesso</returns>
        [HttpPost]
        public IActionResult Criar([FromBody] NPCInserirRequest request)
        {
            npcAppServico.Inserir(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Atualiza um NPC existente
        /// </summary>
        /// <param name="request">Dados atualizados do NPC</param>
        /// <returns>NPC atualizado</returns>
        [HttpPut]
        public IActionResult Atualizar([FromBody] NPCUpdateRequest request)
        {
            npcAppServico.Atualizar(request);
            return Ok();
        }

        /// <summary>
        /// Remove um NPC pelo ID
        /// </summary>
        /// <param name="id">ID do NPC</param>
        /// <returns>NPC removido</returns>
        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            npcAppServico.Remover(id);
            return NoContent();
        }

        /// <summary>
        /// Obtém um NPC pelo ID
        /// </summary>
        /// <param name="id">ID do NPC</param>
        /// <returns>Dados do NPC</returns>
        [HttpGet("{id}")]
        public ActionResult<NPCResponse> ObterPorId(int id)
        {
            var npc = npcAppServico.ObterPorId(id);
            return Ok(npc);
        }

        /// <summary>
        /// Lista todos os NPCs
        /// </summary>
        /// <returns>Lista de NPCs</returns>
        [HttpGet]
        public ActionResult<PaginacaoResponse<NPCResponse>> Query([FromQuery] NPCFiltrarRequest filtro)
        {
            var npcs = npcAppServico.Query(filtro);
            return Ok(npcs);
        }

    }
}