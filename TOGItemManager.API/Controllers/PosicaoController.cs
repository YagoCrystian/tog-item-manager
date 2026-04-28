using Microsoft.AspNetCore.Mvc;
using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Application.DTOs.Posicoes.Requests;
using TOGItemManager.Application.DTOs.Posicoes.Responses;
using TOGItemManager.Application.Services.Posicoes.Interfaces;

namespace TOGItemManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PosicaoController : ControllerBase
    {
        private readonly IPosicaoAppServico posicaoAppServico;

        public PosicaoController(IPosicaoAppServico posicaoAppServico)
        {
            this.posicaoAppServico = posicaoAppServico;
        }

        /// <summary>
        /// Cria uma nova posicao
        /// </summary>
        /// <param name="request">Dados da posicao</param>
        /// <returns>Raridade criada com sucesso</returns>
        [HttpPost]
        public IActionResult Criar([FromBody] PosicaoInserirRequest request)
        {
            posicaoAppServico.Inserir(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Atualiza uma posicao existente
        /// </summary>
        /// <param name="request">Dados atualizados da posicao</param>
        /// <returns>posicao atualizada</returns>
        [HttpPut]
        public IActionResult Atualizar([FromBody] PosicaoUpdateRequest request)
        {
            posicaoAppServico.Atualizar(request);
            return Ok();
        }

        /// <summary>
        /// Remove uma posicao pelo ID
        /// </summary>
        /// <param name="id">ID da posicao</param>
        /// <returns>posicao removida</returns>
        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            posicaoAppServico.Remover(id);
            return NoContent();
        }

        /// <summary>
        /// Obtém uma posicao pelo ID
        /// </summary>
        /// <param name="id">ID da posicao</param>
        /// <returns>Dados da posicao</returns>
        [HttpGet("{id}")]
        public ActionResult<PosicaoResponse> ObterPorId(int id)
        {
            var posicao = posicaoAppServico.ObterEValidar(id);
            return Ok(posicao);
        }

        /// <summary>
        /// Lista todas as posicaos
        /// </summary>
        /// <returns>Lista de posicaos</returns>
        [HttpGet]
        public ActionResult<PaginacaoResponse<PosicaoResponse>> Query([FromQuery] PosicaoFiltrarRequest filtro)
        {
            var resultado = posicaoAppServico.Query(filtro);
            return Ok(resultado);
        }
    }
}