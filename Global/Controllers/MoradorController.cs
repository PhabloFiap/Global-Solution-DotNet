using Global.Aplication.Dtos;
using Global.Domain.Interfaces;
using Global.Domain.Interfaces.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Global.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoradorController : ControllerBase
    {
        private readonly IMoradorApplicationService _moradorApplicationService;

        public MoradorController(IMoradorApplicationService moradorApplicationService)
        {
            _moradorApplicationService = moradorApplicationService;
        }

        // Rota para listar todos os moradores
        [HttpGet]
        public IActionResult ListarMoradores()
        {
            return Ok(_moradorApplicationService.ListarMoradores());
        }

        // Rota para obter um morador específico por ID
        [HttpGet("{id}")]
        public IActionResult ObterMorador(int id)
        {
            var morador = _moradorApplicationService.ObterMorador(id);
            if (morador == null)
            {
                return NotFound();
            }
            return Ok(morador);
        }

        // Inserir um novo morador
        [HttpPost]
        public IActionResult InserirMorador([FromBody] MoradorDto morador)
        {
            morador.Validator();
            var moradorInserido = _moradorApplicationService.InserirMorador(morador);
            if (moradorInserido == null)
            {
                return BadRequest();
            }
            return Ok(moradorInserido);
        }

        // Editar um morador existente
        [HttpPut("{id}")]
        public IActionResult EditarMorador(int id, [FromBody] MoradorDto morador)
        {
            morador.Validator();
            var moradorEditado = _moradorApplicationService.EditarMorador(id, morador);
            if (moradorEditado == null)
            {
                return NotFound();
            }
            return Ok(moradorEditado);
        }

        // Deletar um morador existente
        [HttpDelete("{id}")]
        public IActionResult DeletarMorador(int id)
        {
            var moradorDeletado = _moradorApplicationService.DeletarMorador(id);
            if (moradorDeletado == null)
            {
                return NotFound();
            }
            return Ok(moradorDeletado);
        }
    }
}
