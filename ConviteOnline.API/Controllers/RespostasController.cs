using ConviteOnline.Application.DTOs;
using ConviteOnline.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConviteOnline.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RespostasController : ControllerBase
    {
        private readonly IRespostaService _respostaService;

        public RespostasController(IRespostaService respostaService)
        {
            _respostaService = respostaService;
        }

        [HttpGet("GetRespostaPorAniversarioId", Name = "GetRespostaPorAniversarioId")]
        public async Task<ActionResult<IEnumerable<RespostaDTO>>> GetRespostaPorAniversarioId(string aniversarioId, CancellationToken cancellation)
        {
            var respostas = await _respostaService.ObterPorAniversarioIdAsync(aniversarioId, cancellation);

            return Ok(respostas);
        }

        [HttpGet("GetRespostaPorId", Name = "GetRespostaPorId")]
        public async Task<ActionResult<IEnumerable<RespostaDTO>>> GetRespostaPorId(string id, CancellationToken cancellation)
        {
            var resposta = await _respostaService.ObterPorIdAsync(id, cancellation);
            if (resposta == null)
                return NotFound("Resposta não encontrada");

            return Ok(resposta);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RespostaCriarDTO respostaCriarDto, CancellationToken cancellation)
        {
            if (respostaCriarDto == null)
                return BadRequest("Invalid Data");

            var result = await _respostaService.CriarAsync(respostaCriarDto, cancellation);

            return new CreatedAtRouteResult("GetRespostaPorId", new { id = result.Id },
                result);
        }

        [HttpPut]
        public async Task<ActionResult> Put(string id, [FromBody] RespostaAlterarDTO userAlterarDto, CancellationToken cancellation)
        {
            if (id != userAlterarDto.Id)
                return BadRequest();

            if (userAlterarDto == null)
                return BadRequest();

            await _respostaService.AlterarAsync(userAlterarDto, cancellation);

            return Ok(userAlterarDto);
        }

        [HttpDelete]
        public async Task<ActionResult<RespostaDTO>> Delete(string id, CancellationToken cancellation)
        {
            var user = await _respostaService.ObterPorIdAsync(id, cancellation);
            if (user == null)
            return NotFound("Resposta não encontrada");
            
            await _respostaService.DeletaAsync(id, cancellation);

            return Ok(user);
        }
    }
}
