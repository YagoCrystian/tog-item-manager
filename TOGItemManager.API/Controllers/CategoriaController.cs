using Microsoft.AspNetCore.Mvc;
using TOGItemManager.Application.DTOs.Categorias.Requests;
using TOGItemManager.Application.DTOs.Categorias.Responses;
using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Application.Services.Categorias.Interfaces;

namespace TOGItemManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaAppServico categoriaAppServico;

        public CategoriaController(ICategoriaAppServico categoriaAppServico)
        {
            this.categoriaAppServico = categoriaAppServico;
        }


        /// <summary>
        /// Cria uma nova raridade
        /// </summary>
        /// <param name="request">Dados da raridade</param>
        /// <returns>Raridade criada com sucesso</returns>
        [HttpPost]
        public IActionResult Criar([FromBody] CategoriaInserirRequest request)
        {
            categoriaAppServico.Inserir(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Atualiza uma categoria existente
        /// </summary>
        /// <param name="request">Dados atualizados da categoria</param>
        /// <returns>categoria atualizada</returns>
        [HttpPut]
        public IActionResult Atualizar([FromBody] CategoriaAtualizarRequest request)
        {
            categoriaAppServico.Atualizar(request);
            return Ok();
        }

        /// <summary>
        /// Remove uma categoria pelo ID
        /// </summary>
        /// <param name="id">ID da categoria</param>
        /// <returns>categoria removida</returns>
        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            categoriaAppServico.Remover(id);
            return NoContent();
        }

        /// <summary>
        /// Obtém uma categoria pelo ID
        /// </summary>
        /// <param name="id">ID da categoria</param>
        /// <returns>Dados da categoria</returns>
        [HttpGet("{id}")]
        public ActionResult<CategoriaResponse> ObterPorId(int id)
        {
            var categoria = categoriaAppServico.ObterPorId(id);
            return Ok(categoria);
        }

        /// <summary>
        /// Lista todas as categorias
        /// </summary>
        /// <returns>Lista de categorias</returns>
        [HttpGet]
        public ActionResult<PaginacaoResponse<CategoriaResponse>> Query([FromQuery] CategoriaFiltrarRequest filtro)
        {
            var resultado = categoriaAppServico.Query(filtro);
            return Ok(resultado);
        }
    }
}