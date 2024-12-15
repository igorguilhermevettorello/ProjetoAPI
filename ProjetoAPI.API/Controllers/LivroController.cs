using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoAPI.Application.Commands.Autor;
using ProjetoAPI.Application.Commands.Livros;
using ProjetoAPI.Application.DTOs.Livro;
using ProjetoAPI.Application.Queries.Autor;

namespace ProjetoAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LivroController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new BuscarLivrosQuery();
            var livros = await _mediator.Send(query);
            return Ok(livros);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new BuscarLivroPorIdQuery(id);
            var livro = await _mediator.Send(query);
            if (livro == null) return NotFound();
            return Ok(livro);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] CriarLivroDto livroDto)
        {
            var command = new CriarLivroCommand(livroDto);
            var id = await _mediator.Send(command);
            return Ok(new { id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] AlterarLivroDto livroDto)
        {
            if (id != livroDto.Id) return BadRequest();
            var command = new AlterarLivroCommand(livroDto);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var query = new BuscarLivroPorIdQuery(id);
            var autor = await _mediator.Send(query);
            if (autor == null) return NotFound();
            var command = new RemoverLivroCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
