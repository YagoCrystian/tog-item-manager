using Microsoft.AspNetCore.Mvc;
using TOGItemManager.Application.DTOs.BackgroundsBonus.Requests;
using TOGItemManager.Application.DTOs.BackgroundsBonus.Responses;
using TOGItemManager.Application.Services.BackgroundsBonus.Interfaces;

namespace TOGItemManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BackgroundBonusController : ControllerBase
    {
        private readonly IBackgroundBonusAppServico backgroundBonusAppServico;

        public BackgroundBonusController(IBackgroundBonusAppServico backgroundBonusAppServico)
        {
            this.backgroundBonusAppServico = backgroundBonusAppServico;
        }

        /// <summary>
        /// Cria uma nova backgroundBonus
        /// </summary>
        /// <param name="request">Dados da backgroundBonus</param>
        /// <returns>Raridade criada com sucesso</returns>
        [HttpPost]
        public IActionResult Criar([FromBody] BackgroundBonusInserirRequest request)
        {
            backgroundBonusAppServico.Inserir(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Atualiza uma backgroundBonus existente
        /// </summary>
        /// <param name="request">Dados atualizados da backgroundBonus</param>
        /// <returns>backgroundBonus atualizada</returns>
        [HttpPut]
        public IActionResult Atualizar([FromBody] BackgroundBonusUpdateRequest request)
        {
            backgroundBonusAppServico.Atualizar(request);
            return Ok();
        }

        /// <summary>
        /// Remove uma backgroundBonus pelo ID
        /// </summary>
        /// <param name="id">ID da backgroundBonus</param>
        /// <returns>backgroundBonus removida</returns>
        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            backgroundBonusAppServico.Remover(id);
            return NoContent();
        }

        /// <summary>
        /// Obtém uma backgroundBonus pelo ID
        /// </summary>
        /// <param name="id">ID da backgroundBonus</param>
        /// <returns>Dados da backgroundBonus</returns>
        [HttpGet("{id}")]
        public ActionResult<BackgroundBonusResponse> ObterPorId(int id)
        {
            var backgroundBonus = backgroundBonusAppServico.ObterEValidar(id);
        
            var response = new BackgroundBonusResponse(
                backgroundBonus.Id,
                backgroundBonus.TipoBonus,
                backgroundBonus.Referencia,
                backgroundBonus.Valor,
                backgroundBonus.EscolhaJogador
            );
        
            return Ok(response);
        }

    }
}