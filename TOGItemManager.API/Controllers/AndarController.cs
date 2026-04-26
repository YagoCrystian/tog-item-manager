using Microsoft.AspNetCore.Mvc;
using TOGItemManager.Application.DTOs.Andares.Requests;
using TOGItemManager.Application.DTOs.Andares.Responses;
using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Application.Services.Andares.Interfaces;

namespace TOGItemManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AndarController : ControllerBase
    {
        private readonly IAndarAppServico andarAppServico;

        public AndarController(IAndarAppServico andarAppServico)
        {
            this.andarAppServico = andarAppServico;
        }

        /// <summary>
        /// Cria um novo andar
        /// </summary>
        /// <param name="request">Dados do andar</param>
        /// <returns>Andar criado com sucesso</returns>
        [HttpPost]
        public IActionResult Criar([FromBody] AndarInserirRequest request)
        {
            andarAppServico.Inserir(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Atualiza um andar existente
        /// </summary>
        /// <param name="request">Dados atualizados do andar</param>
        /// <returns>Andar atualizado</returns>
        [HttpPut]
        public IActionResult Atualizar([FromBody] AndarUpdateRequest request)
        {
            andarAppServico.Atualizar(request);
            return Ok();
        }

        /// <summary>
        /// Remove um andar pelo ID
        /// </summary>
        /// <param name="id">ID do andar</param>
        /// <returns>Andar removido</returns>
        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            andarAppServico.Remover(id);
            return NoContent();
        }

        /// <summary>
        /// Obtém um andar pelo ID
        /// </summary>
        /// <param name="id">ID do andar</param>
        /// <returns>Dados do andar</returns>
        [HttpGet("{id}")]
        public ActionResult<AndarResponse> ObterPorId(int id)
        {
            var andar = andarAppServico.ObterPorId(id);
            return Ok(andar);
        }

        /// <summary>
        /// Lista todos os andares
        /// </summary>
        /// <returns>Lista de andares</returns>
        [HttpGet]
        public ActionResult<PaginacaoResponse<AndarResponse>> Query([FromQuery] AndarFiltrarRequest filtro)
        {
            var andares = andarAppServico.Query(filtro);
            return Ok(andares);
        }

        [HttpGet("{andarId}/itens")]
        public IActionResult ListarItensDoAndar(int andarId)
        {
            try
            {
                var itens = andarAppServico.ListarItensDoAndar(andarId);
                return Ok(itens);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}