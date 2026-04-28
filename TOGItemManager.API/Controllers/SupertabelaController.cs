using Microsoft.AspNetCore.Mvc;
using TOGItemManager.Application.DTOs.Supertabelas.Requests;
using TOGItemManager.Application.DTOs.Supertabelas.Responses;
using TOGItemManager.Application.Services.Supertabelas.Interfaces;

namespace TOGItemManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupertabelaController : ControllerBase
    {
        private readonly ISupertabelaAppServico supertabelaAppServico;

        public SupertabelaController(ISupertabelaAppServico supertabelaAppServico)
        {
            this.supertabelaAppServico = supertabelaAppServico;
        }

        /// <summary>
        /// Cria uma nova supertabela
        /// </summary>
        /// <param name="request">Dados da supertabela</param>
        /// <returns>Raridade criada com sucesso</returns>
        [HttpPost]
        public IActionResult Criar([FromBody] SupertabelaInserirRequest request)
        {
            supertabelaAppServico.Inserir(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Atualiza uma supertabela existente
        /// </summary>
        /// <param name="request">Dados atualizados da supertabela</param>
        /// <returns>supertabela atualizada</returns>
        [HttpPut]
        public IActionResult Atualizar([FromBody] SupertabelaUpdateRequest request)
        {
            supertabelaAppServico.Atualizar(request);
            return Ok();
        }

        /// <summary>
        /// Remove uma supertabela pelo ID
        /// </summary>
        /// <param name="id">ID da supertabela</param>
        /// <returns>supertabela removida</returns>
        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            supertabelaAppServico.Remover(id);
            return NoContent();
        }

        /// <summary>
        /// Obtém uma supertabela pelo ID
        /// </summary>
        /// <param name="id">ID da supertabela</param>
        /// <returns>Dados da supertabela</returns>
        [HttpGet("{id}")]
        public ActionResult<SupertabelaResponse> ObterPorId(int id)
        {
            var supertabela = supertabelaAppServico.ObterEValidar(id);
            return Ok(supertabela);
        }
    }
}