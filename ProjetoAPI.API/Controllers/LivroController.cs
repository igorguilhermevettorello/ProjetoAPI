using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoAPI.Application.Commands.Livros;
using ProjetoAPI.Application.DTOs.Livro;

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

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] CriarLivroDto livroDto)
        {
            var command = new CriarLivroCommand(livroDto);
            var id = await _mediator.Send(command);
            return Ok(new { id });
        }
    }
}
