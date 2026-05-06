using Microsoft.AspNetCore.Mvc;
using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Application.DTOs.Poderes.Requests;
using TOGItemManager.Application.DTOs.Poderes.Responses;
using TOGItemManager.Application.Services.Poderes.Interfaces;

namespace TOGItemManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PoderController : ControllerBase
    {
        private readonly IPoderAppServico poderAppServico;

        public PoderController(IPoderAppServico poderAppServico)
        {
            this.poderAppServico = poderAppServico;
        }

        /// <summary>
        /// Cria uma nova poder
        /// </summary>
        /// <param name="request">Dados da poder</param>
        /// <returns>Raridade criada com sucesso</returns>
        [HttpPost]
        public IActionResult Criar([FromBody] PoderInserirRequest request)
        {
            poderAppServico.Inserir(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Atualiza uma poder existente
        /// </summary>
        /// <param name="request">Dados atualizados da poder</param>
        /// <returns>poder atualizada</returns>
        [HttpPut]
        public IActionResult Atualizar([FromBody] PoderUpdateRequest request)
        {
            poderAppServico.Atualizar(request);
            return Ok();
        }

        /// <summary>
        /// Remove uma poder pelo ID
        /// </summary>
        /// <param name="id">ID da poder</param>
        /// <returns>poder removida</returns>
        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            poderAppServico.Remover(id);
            return NoContent();
        }

        /// <summary>
        /// Obtém uma poder pelo ID
        /// </summary>
        /// <param name="id">ID da poder</param>
        /// <returns>Dados da poder</returns>
        [HttpGet("{id}")]
        public ActionResult<PoderResponse> ObterPorId(int id)
        {
            var poder = poderAppServico.ObterEValidar(id);
            return Ok(poder);
        }

        /// <summary>
        /// Lista todas as poders
        /// </summary>
        /// <returns>Lista de poders</returns>
        [HttpGet]
        public ActionResult<PaginacaoResponse<PoderResponse>> Query([FromQuery] PoderFiltrarRequest filtro)
        {
            var resultado = poderAppServico.Query(filtro);
            return Ok(resultado);
        }
    }
}