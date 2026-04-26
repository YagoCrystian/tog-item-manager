using Microsoft.AspNetCore.Mvc;
using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Application.DTOs.Conjuntos.Requests;
using TOGItemManager.Application.DTOs.Conjuntos.Responses;
using TOGItemManager.Application.Services.Conjuntos.Interfaces;

namespace TOGItemManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConjuntoController : ControllerBase
    {
        private readonly IConjuntoAppServico conjuntoAppServico;

        public ConjuntoController(IConjuntoAppServico conjuntoAppServico)
        {
            this.conjuntoAppServico = conjuntoAppServico;
        }

        /// <summary>
        /// Cria um novo conjunto
        /// </summary>
        /// <param name="request">Dados do conjunto</param>
        /// <returns>Conjunto criado com sucesso</returns>
        [HttpPost]
        public IActionResult Criar([FromBody] ConjuntoInserirRequest request)
        {
            conjuntoAppServico.Inserir(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Atualiza um conjunto existente
        /// </summary>
        /// <param name="request">Dados atualizados do conjunto</param>
        /// <returns>Conjunto atualizado</returns>
        [HttpPut]
        public IActionResult Atualizar([FromBody] ConjuntoUpdateRequest request)
        {
            conjuntoAppServico.Atualizar(request);
            return Ok();
        }

        /// <summary>
        /// Remove um conjunto pelo ID
        /// </summary>
        /// <param name="id">ID do conjunto</param>
        /// <returns>Conjunto removido</returns>
        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            conjuntoAppServico.Remover(id);
            return NoContent();
        }

        /// <summary>
        /// Obtém um conjunto pelo ID
        /// </summary>
        /// <param name="id">ID do conjunto</param>
        /// <returns>Dados do conjunto</returns>
        [HttpGet("{id}")]
        public ActionResult<ConjuntoResponse> ObterPorId(int id)
        {
            var conjunto = conjuntoAppServico.ObterPorId(id);
            return Ok(conjunto);
        }

        /// <summary>
        /// Lista todos os conjuntos
        /// </summary>
        /// <returns>Lista de conjuntos</returns>
        [HttpGet]
        public ActionResult<PaginacaoResponse<ConjuntoResponse>> Query([FromQuery] ConjuntoFiltrarRequest filtro)
        {
            var resultado = conjuntoAppServico.Query(filtro);
            return Ok(resultado);
        }
    }

}