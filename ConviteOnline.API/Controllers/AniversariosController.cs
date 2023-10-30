using ConviteOnline.Application.DTOs;
using ConviteOnline.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConviteOnline.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AniversariosController : ControllerBase
    {
        private readonly IAniversarioService _aniversarioService;
        public AniversariosController(IAniversarioService aniversarioService)
        {
            _aniversarioService = aniversarioService;
        }

        [HttpGet("GetPorId", Name = "GetPorId")]
        public async Task<ActionResult<AniversarioDTO>> GetPorId(string id, CancellationToken cancellation)
        {
            var aniversario = await _aniversarioService.ObterPorIdAsync(id, cancellation);
            if (aniversario == null)
                return NotFound("Aniversario não encontrada");

            return Ok(aniversario);
        }

        [HttpGet("GetAniversarioPorSlug", Name = "GetAniversarioPorSlug")]
        public async Task<ActionResult<AniversarioDTO>> GetAniversarioPorSlug(string slug, CancellationToken cancellation)
        {
            var aniversarios = await _aniversarioService.ObterPorSlugAsync(slug, cancellation);

            return Ok(aniversarios);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AniversarioCriarDTO aniversarioCriarDto, CancellationToken cancellation)
        {
            if (aniversarioCriarDto == null)
                return BadRequest("Invalid Data");

            var result = await _aniversarioService.CriarAsync(aniversarioCriarDto, cancellation);

            return new CreatedAtRouteResult("GetPorId", new { id = result.Id },
                result);
        }

        [HttpPost("AdicionarFotoDestaque")]
        public async Task<ActionResult> AdicionarFotoDestaque([FromForm] FotoCriarDTO fotoDestaque, [FromForm] IFormFile arquivo, CancellationToken cancellation)
        {
            if (fotoDestaque == null)
                return BadRequest("Invalid Data");

            await using var memoryStream = new MemoryStream();
            await arquivo.CopyToAsync(memoryStream, cancellation);
            UploadFileDTO file = new(arquivo.FileName, memoryStream);

            var result = await _aniversarioService.AdicionarFotoDestaqueAsync(fotoDestaque, file, cancellation);

            return new CreatedAtRouteResult("GetPorId", new { id = result.AniversarioId },
                result);
        }

        [HttpPost("AdicionarFotoCarrossel")]
        public async Task<ActionResult> AdicionarFotoCarrossel([FromForm] FotoCriarDTO fotoCarrossel, [FromForm] IFormFile arquivo, CancellationToken cancellation)
        {
            if (fotoCarrossel == null)
                return BadRequest("Invalid Data");

            await using var memoryStream = new MemoryStream();
            await arquivo.CopyToAsync(memoryStream, cancellation);
            UploadFileDTO file = new(arquivo.FileName, memoryStream);

            var result = await _aniversarioService.AdicionarFotoCarrosselAsync(fotoCarrossel, file, cancellation);

            return new CreatedAtRouteResult("GetPorId", new { id = result.AniversarioId },
                result);
        }

        [HttpPut]
        public async Task<ActionResult> Put(string id, [FromBody] AniversarioAlterarDTO aniversarioAlterarDto, CancellationToken cancellation)
        {
            if (id != aniversarioAlterarDto.Id)
                return BadRequest();

            if (aniversarioAlterarDto == null)
                return BadRequest();

            var dto = await _aniversarioService.AlterarAsync(aniversarioAlterarDto, cancellation);

            return Ok(dto);
        }

        [HttpDelete]
        public async Task<ActionResult<AniversarioDTO>> Delete(string id, CancellationToken cancellation)
        {
            var aniversario = await _aniversarioService.ObterPorIdAsync(id, cancellation);
            if (aniversario == null)
                return NotFound("Aniversario não encontrada");

            await _aniversarioService.DeletaAsync(id, cancellation);

            return Ok(aniversario);
        }

        [HttpDelete("RemoverFotoDestaque")]
        public async Task<ActionResult<AniversarioDTO>> RemoverFotoDestaque(string id, string aniversarioId, CancellationToken cancellation)
        {
            var aniversario = await _aniversarioService.ObterPorIdAsync(aniversarioId, cancellation);
            if (aniversario == null)
                return NotFound("Aniversario não encontrada");

            await _aniversarioService.RemoverFotoDestaqueAsync(id, aniversarioId, cancellation);

            return Ok(aniversario);
        }

        [HttpDelete("RemoverFotoCarrossel")]
        public async Task<ActionResult<AniversarioDTO>> RemoverFotoCarrossel(string id, string aniversarioId, CancellationToken cancellation)
        {
            var aniversario = await _aniversarioService.ObterPorIdAsync(aniversarioId, cancellation);
            if (aniversario == null)
                return NotFound("Aniversario não encontrada");

            await _aniversarioService.RemoverFotoCarrosselAsync(id, aniversarioId, cancellation);

            return Ok(aniversario);
        }

        [HttpPost("AlterarImagemConvite")]
        public async Task<ActionResult> AlterarImagemConvite(string aniversarioId, [FromForm] IFormFile arquivo, CancellationToken cancellation)
        {
            if (string.IsNullOrEmpty(aniversarioId))
                return BadRequest("Invalid Data");

            await using var memoryStream = new MemoryStream();
            await arquivo.CopyToAsync(memoryStream, cancellation);
            UploadFileDTO file = new(arquivo.FileName, memoryStream);

            var result = await _aniversarioService.AlterarImagemConviteAsync(aniversarioId, file, cancellation);

            return new CreatedAtRouteResult("GetPorId", new { id = aniversarioId },
                result);
        }

        [HttpDelete("RemoverImagemConvite")]
        public async Task<ActionResult<AniversarioDTO>> RemoverImagemConvite(string aniversarioId, CancellationToken cancellation)
        {
            var aniversario = await _aniversarioService.ObterPorIdAsync(aniversarioId, cancellation);
            if (aniversario == null)
                return NotFound("Aniversario não encontrada");

            var result = await _aniversarioService.RemoverImagemConviteAsync(aniversarioId, cancellation);

            return Ok(result);
        }
    }
}
