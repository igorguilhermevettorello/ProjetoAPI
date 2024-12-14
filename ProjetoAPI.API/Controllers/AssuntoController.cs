using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoAPI.Application.Commands.Assunto;
using ProjetoAPI.Application.Commands.Autor;
using ProjetoAPI.Application.DTOs.Assunto;
using ProjetoAPI.Application.DTOs.Autor;
using ProjetoAPI.Application.Queries.Assunto;
using ProjetoAPI.Application.Queries.Autor;

namespace ProjetoAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssuntoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AssuntoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new BuscarAssuntosQuery();
            var assuntos = await _mediator.Send(query);
            return Ok(assuntos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new BuscarAssuntoPorIdQuery(id);
            var assunto = await _mediator.Send(query);
            if (assunto == null) return NotFound();
            return Ok(assunto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] CriarAssuntoDto assuntoDto)
        {
            var command = new CriarAssuntoCommand(assuntoDto);
            var id = await _mediator.Send(command);
            return Ok(new { id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] AlterarAssuntoDto assuntoDto)
        {
            if (id != assuntoDto.Id) return BadRequest();
            var command = new AlterarAssuntoCommand(assuntoDto);
            await _mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var query = new BuscarAssuntoPorIdQuery(id);
            var assunto = await _mediator.Send(query);
            if (assunto == null) return NotFound();
            var command = new RemoverAssuntoCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
