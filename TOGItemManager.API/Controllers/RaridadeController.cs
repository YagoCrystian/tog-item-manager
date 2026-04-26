using Microsoft.AspNetCore.Mvc;
using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Application.DTOs.Raridades.Requests;
using TOGItemManager.Application.DTOs.Raridades.Responses;
using TOGItemManager.Application.Services.Raridades.Interfaces;

namespace TOGItemManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RaridadeController : ControllerBase
    {
        private readonly IRaridadeAppServico raridadeAppServico;

        public RaridadeController(IRaridadeAppServico raridadeAppServico)
        {
            this.raridadeAppServico = raridadeAppServico;
        }

        /// <summary>
        /// Cria uma nova raridade
        /// </summary>
        /// <param name="request">Dados da raridade</param>
        /// <returns>Raridade criada com sucesso</returns>
        [HttpPost]
        public IActionResult Criar([FromBody] RaridadeCreateRequest request)
        {
            raridadeAppServico.Inserir(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Atualiza uma raridade existente
        /// </summary>
        /// <param name="request">Dados atualizados da raridade</param>
        /// <returns>Raridade atualizada</returns>
        [HttpPut]
        public IActionResult Atualizar([FromBody] RaridadeUpdateRequest request)
        {
            raridadeAppServico.Atualizar(request);
            return Ok();
        }

        /// <summary>
        /// Remove uma raridade pelo ID
        /// </summary>
        /// <param name="id">ID da raridade</param>
        /// <returns>Raridade removida</returns>
        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            raridadeAppServico.Remover(id);
            return NoContent();
        }

        /// <summary>
        /// Obtém uma raridade pelo ID
        /// </summary>
        /// <param name="id">ID da raridade</param>
        /// <returns>Dados da raridade</returns>
        [HttpGet("{id}")]
        public ActionResult<RaridadeResponse> ObterPorId(int id)
        {
            var raridade = raridadeAppServico.ObterPorId(id);
            return Ok(raridade);
        }

        /// <summary>
        /// Lista todas as raridades
        /// </summary>
        /// <returns>Lista de raridades</returns>
        [HttpGet]
        public ActionResult<PaginacaoResponse<RaridadeResponse>> Query([FromQuery] RaridadeFiltrarRequest filtro)
        {
            var raridades = raridadeAppServico.Query(filtro);
            return Ok(raridades);
        }
    }
}