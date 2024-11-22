using Global.Application.Dtos;
using Global.Domain.Interfaces;
using Global.Domain.Interfaces.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Global.Controllers
{
    [Route("api/medidor")]
    [ApiController]
    public class MedidorController : ControllerBase
    {
        private readonly IMedidorApplicationService _medidorApplicationService;

        public MedidorController(IMedidorApplicationService medidorApplicationService)
        {
            _medidorApplicationService = medidorApplicationService;
        }

        // Lista todos os medidores
        [HttpGet]
        public IActionResult ListarMedidores()
        {
            var medidores = _medidorApplicationService.ListarMedidores();
            return Ok(medidores);
        }

        // Busca um medidor específico pelo ID
        [HttpGet("{id}")]
        public IActionResult ObterMedidor(int id)
        {
            var medidor = _medidorApplicationService.ObterMedidor(id);
            if (medidor == null)
            {
                return NotFound(new { Message = $"Medidor com ID {id} não encontrado." });
            }
            return Ok(medidor);
        }

        // Insere um novo medidor
        [HttpPost]
        public IActionResult InserirMedidor([FromBody] MedidorDto medidorDto)
        {
            medidorDto.Validator(); // Valida os dados recebidos

            var medidorInserido = _medidorApplicationService.InserirMedidor(medidorDto);
            if (medidorInserido == null)
            {
                return BadRequest(new { Message = "Não foi possível inserir o medidor." });
            }

            return CreatedAtAction(nameof(ObterMedidor), new { id = medidorInserido.id }, medidorInserido);
        }

        // Edita um medidor existente
        [HttpPut("{id}")]
        public IActionResult EditarMedidor(int id, [FromBody] MedidorDto medidorDto)
        {
            medidorDto.Validator(); // Valida os dados recebidos

            var medidorEditado = _medidorApplicationService.EditarMedidor(id, medidorDto);
            if (medidorEditado == null)
            {
                return NotFound(new { Message = $"Medidor com ID {id} não encontrado." });
            }

            return Ok(medidorEditado);
        }


        // Deleta um medidor pelo ID
        [HttpDelete("{id}")]
        public IActionResult DeletarMedidor(int id)
        {
            var medidorDeletado = _medidorApplicationService.DeletarMedidor(id);
            if (medidorDeletado == null)
            {
                return NotFound(new { Message = $"Medidor com ID {id} não encontrado para exclusão." });
            }
            return Ok(new { Message = $"Medidor com ID {id} foi deletado com sucesso." });
        }
    }
}
