using Microsoft.AspNetCore.Mvc;
using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Application.DTOs.Items.Requests;
using TOGItemManager.Application.DTOs.Items.Responses;
using TOGItemManager.Application.Services.Items.Interfaces;

namespace TOGItemManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemAppServico itemAppServico;

        public ItemController(IItemAppServico itemAppServico)
        {
            this.itemAppServico = itemAppServico;
        }

        /// <summary>
        /// Cria um novo item
        /// </summary>
        [HttpPost]
        public IActionResult Criar([FromBody] ItemInserirRequest request)
        {
            itemAppServico.Inserir(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Atualiza um item existente
        /// </summary>
        [HttpPut]
        public IActionResult Atualizar([FromBody] ItemUpdateRequest request)
        {
            itemAppServico.Atualizar(request);
            return Ok();
        }

        [HttpPatch]
        public IActionResult AtualizarParcial([FromBody] ItemPatchRequest request)
        {
            itemAppServico.AtualizarParcial(request);
            return Ok();
        }

        /// <summary>
        /// Remove um item pelo ID
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            itemAppServico.Remover(id);
            return NoContent();
        }

        /// <summary>
        /// Obtém um item pelo ID
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<ItemResponse> ObterPorId(int id)
        {
            var item = itemAppServico.ObterPorId(id);
            return Ok(item);
        }

        /// <summary>
        /// Lista todos os itens
        /// </summary>
        [HttpGet]
        public ActionResult<PaginacaoResponse<ItemResponse>> Query([FromQuery] ItemFiltrarRequest filtro)
        {
            var itens = itemAppServico.Query(filtro);
            return Ok(itens);
        }

        [HttpPost("{itemId}/andares/{andarId}")]
        public IActionResult AdicionarItemAoAndar(int itemId, int andarId)
        {
            itemAppServico.AdicionarItemAoAndar(itemId, andarId);

            return Ok();
        }
    }
}