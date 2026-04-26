using Microsoft.AspNetCore.Mvc;
using TOGItemManager.Application.DTOs.Perfis.Requests;
using TOGItemManager.Application.DTOs.Perfis.Responses;
using TOGItemManager.Application.Services.Perfis.Interfaces;
using TOGItemManager.Domain.Entidades.Perfis;

namespace TOGItemManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilAppServico perfilAppServico;

        public PerfilController(IPerfilAppServico perfilAppServico)
        {
            this.perfilAppServico = perfilAppServico;
        }

        /// <title>Cria um novo perfil</title>
        /// <summary>
        /// Cria um novo perfil
        /// </summary>
        [HttpPost]
        public IActionResult Criar([FromBody] PerfilInserirRequest request)
        {
            perfilAppServico.Inserir(request);
            return StatusCode(StatusCodes.Status201Created);
        }


        /// <summary>
        /// Atualiza um perfil existente
        /// </summary>
        [HttpPut]
        public IActionResult Atualizar([FromBody] PerfilUpdateRequest request)
        {
            perfilAppServico.Atualizar(request);
            return Ok();
        }

        /// <summary>
        /// Remove um perfil pelo ID
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            perfilAppServico.Remover(id);
            return NoContent();
        }

        /// <summary>
        /// Obtém um perfil pelo ID
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<PerfilResponse> ObterPorId(int id)
        {
            Perfil perfil = perfilAppServico.ObterEValidar(id);
            return Ok(perfil);
        }
    }
}