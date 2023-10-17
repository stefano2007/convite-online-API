using ConviteOnline.Application.DTOs;
using ConviteOnline.Application.Interfaces;
using ConviteOnline.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ConviteOnline.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FotosController : ControllerBase
    {
        private readonly IFotoService _fotoService;

        public FotosController(IFotoService fotoService)
        {
            _fotoService = fotoService;
        }

        [HttpGet("GetFotoPorAniversarioId", Name = "GetFotoPorAniversarioId")]
        public async Task<ActionResult<IEnumerable<FotoDTO>>> GetFotoPorAniversarioId(string aniversarioId, CancellationToken cancellation)
        {
            var fotos = await _fotoService.ObterPorAniversarioIdAsync(aniversarioId, cancellation);
            
            return Ok(fotos);
        }

        [HttpGet("GetFotoPorId", Name = "GetFotoPorId")]
        public async Task<ActionResult<IEnumerable<FotoDTO>>> GetFotoPorId(string id, CancellationToken cancellation)
        {
            var foto = await _fotoService.ObterPorIdAsync(id, cancellation);
            if (foto == null)
            {
                return NotFound("Foto não encontrada");
            }
            return Ok(foto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FotoCriarDTO fotoCriarDto, CancellationToken cancellation)
        {
            if (fotoCriarDto == null)
                return BadRequest("Invalid Data");

            var result = await _fotoService.CriarAsync(fotoCriarDto, cancellation);

            return new CreatedAtRouteResult("GetFotoPorId", new { id = result.Id },
                result);
        }

        [HttpPut]
        public async Task<ActionResult> Put(string id, [FromBody] FotoAlterarDTO userAlterarDto, CancellationToken cancellation)
        {
            if (id != userAlterarDto.Id)
                return BadRequest();

            if (userAlterarDto == null)
                return BadRequest();

            await _fotoService.AlterarAsync(userAlterarDto, cancellation);

            return Ok(userAlterarDto);
        }

        [HttpDelete]
        public async Task<ActionResult<FotoDTO>> Delete(string id, CancellationToken cancellation)
        {
            var user = await _fotoService.ObterPorIdAsync(id, cancellation);
            if (user == null)
            {
                return NotFound("User not found");
            }

            await _fotoService.DeletaAsync(id, cancellation);

            return Ok(user);
        }
    }
}
