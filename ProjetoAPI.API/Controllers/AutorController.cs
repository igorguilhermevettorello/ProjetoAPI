using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoAPI.Application.Commands.Autor;
using ProjetoAPI.Application.DTOs.Autor;
using ProjetoAPI.Application.Queries.Autor;

namespace ProjetoAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {

        private readonly IMediator _mediator;

        public AutorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var query = new BuscarAutoresQuery();
            var authors = await _mediator.Send(query);
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new BuscarAutorPorIdQuery(id);
            var autor = await _mediator.Send(query);
            if (autor == null)
                return NotFound();

            return Ok(autor);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] CriarAutorDto dto)
        {
            var command = new CriarAutorCommand(dto);
            var id = await _mediator.Send(command);
            return Ok(new { id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] AlterarAutorDto autorDto)
        {
            if (id != autorDto.Id) return BadRequest();
            var command = new AlterarAutorCommand(autorDto);
            await _mediator.Send(command);
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var query = new BuscarAutorPorIdQuery(id);
            var autor = await _mediator.Send(query);
            if (autor == null) return NotFound();
            var command = new RemoverAutorCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
