using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TOGItemManager.Application.DTOs.Comuns.Responses;
using TOGItemManager.Application.DTOs.Usuarios.Requests;
using TOGItemManager.Application.DTOs.Usuarios.Responses;
using TOGItemManager.Application.Services.Usuarios.Interfaces;

namespace TOGItemManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppServico usuarioAppServico;

        public UsuarioController(IUsuarioAppServico usuarioAppServico)
        {
            this.usuarioAppServico = usuarioAppServico;
        }

        /// <summary>
        /// Cria um novo usuario
        /// </summary>
        [Authorize]
        [HttpPost]
        public IActionResult Criar([FromBody] UsuarioInserirRequest request)
        {
            usuarioAppServico.Inserir(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Atualiza um usuario existente
        /// </summary>
        [HttpPatch]
        public IActionResult Atualizar([FromBody] UsuarioUpdateRequest request)
        {
            usuarioAppServico.Atualizar(request);
            return Ok();
        }

        /// <summary>
        /// Altera o status de um usuario ID
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult AlterarStatus(int id)
        {
            usuarioAppServico.AlterarStatus(id);
            return Ok();
        }

        /// <summary>
        /// Lista todos os usuarios do sistema.
        /// </summary>
        [HttpGet]
        public ActionResult<PaginacaoResponse<UsuarioResponse>> Query([FromQuery] UsuarioFiltrarRequest filtro)
        {
            var itens = usuarioAppServico.Query(filtro);
            return Ok(itens);
        }

    }
}