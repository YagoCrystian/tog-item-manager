using Microsoft.AspNetCore.Mvc;
using TOGItemManager.Application.DTOs.Backgrounds.Requests;
using TOGItemManager.Application.DTOs.Backgrounds.Responses;
using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Application.Services.Backgrounds.Interfaces;

namespace TOGItemManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BackgroundController : ControllerBase
    {
        private readonly IBackgroundAppServico backgroundAppServico;

        public BackgroundController(IBackgroundAppServico backgroundAppServico)
        {
            this.backgroundAppServico = backgroundAppServico;
        }

        /// <summary>
        /// Cria uma nova background
        /// </summary>
        /// <param name="request">Dados da background</param>
        /// <returns>Raridade criada com sucesso</returns>
        [HttpPost]
        public IActionResult Criar([FromBody] BackgroundInserirRequest request)
        {
            backgroundAppServico.Inserir(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Atualiza uma background existente
        /// </summary>
        /// <param name="request">Dados atualizados da background</param>
        /// <returns>background atualizada</returns>
        [HttpPut]
        public IActionResult Atualizar([FromBody] BackgroundUpdateRequest request)
        {
            backgroundAppServico.Atualizar(request);
            return Ok();
        }

        /// <summary>
        /// Remove uma background pelo ID
        /// </summary>
        /// <param name="id">ID da background</param>
        /// <returns>background removida</returns>
        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            backgroundAppServico.Remover(id);
            return NoContent();
        }

        /// <summary>
        /// Obtém uma background pelo ID
        /// </summary>
        /// <param name="id">ID da background</param>
        /// <returns>Dados da background</returns>
        [HttpGet("{id}")]
        public ActionResult<BackgroundResponse> ObterPorId(int id)
        {
            var background = backgroundAppServico.ObterEValidar(id);
            return Ok(background);
        }

        /// <summary>
        /// Lista todas as backgrounds
        /// </summary>
        /// <returns>Lista de backgrounds</returns>
        [HttpGet]
        public ActionResult<PaginacaoResponse<BackgroundResponse>> Query([FromQuery] BackgroundFiltrarRequest filtro)
        {
            var resultado = backgroundAppServico.Query(filtro);
            return Ok(resultado);
        }
    }
}