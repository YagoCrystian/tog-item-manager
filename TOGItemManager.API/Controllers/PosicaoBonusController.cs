using Microsoft.AspNetCore.Mvc;
using TOGItemManager.Application.DTOs.PosicoesBonus.Requests;
using TOGItemManager.Application.DTOs.PosicoesBonus.Responses;
using TOGItemManager.Application.Services.PosicoesBonus.Interfaces;

namespace TOGItemManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PosicaoBonusController : ControllerBase
    {
        private readonly IPosicaoBonusAppServico posicaoBonusAppServico;

        public PosicaoBonusController(IPosicaoBonusAppServico posicaoBonusAppServico)
        {
            this.posicaoBonusAppServico = posicaoBonusAppServico;
        }

        /// <summary>
        /// Cria uma nova posicaoBonus
        /// </summary>
        /// <param name="request">Dados da posicaoBonus</param>
        /// <returns>Raridade criada com sucesso</returns>
        [HttpPost]
        public IActionResult Criar([FromBody] PosicaoBonusInserirRequest request)
        {
            posicaoBonusAppServico.Inserir(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Atualiza uma posicaoBonus existente
        /// </summary>
        /// <param name="request">Dados atualizados da posicaoBonus</param>
        /// <returns>posicaoBonus atualizada</returns>
        [HttpPut]
        public IActionResult Atualizar([FromBody] PosicaoBonusUpdateRequest request)
        {
            posicaoBonusAppServico.Atualizar(request);
            return Ok();
        }

        /// <summary>
        /// Remove uma posicaoBonus pelo ID
        /// </summary>
        /// <param name="id">ID da posicaoBonus</param>
        /// <returns>posicaoBonus removida</returns>
        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            posicaoBonusAppServico.Remover(id);
            return NoContent();
        }

        /// <summary>
        /// Obtém uma posicaoBonus pelo ID
        /// </summary>
        /// <param name="id">ID da posicaoBonus</param>
        /// <returns>Dados da posicaoBonus</returns>
        [HttpGet("{id}")]
        public ActionResult<PosicaoBonusResponse> ObterPorId(int id)
        {
            var posicaoBonus = posicaoBonusAppServico.ObterPorId(id);
            return Ok(posicaoBonus);
        }
    }
}