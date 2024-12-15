using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Application.Commands.Livros;
using ProjetoAPI.Application.DTOs.Livro;
using ProjetoAPI.Domain.Entities;
using ProjetoAPI.Infrastructure;

namespace ProjetoAPI.Application.Handlers.Commands.Autor
{
    public class RemoverLivroCommandHandler : IRequestHandler<RemoverLivroCommand, RetornoRemoverLivroDto>
    {
        private readonly ApplicationDbContext _context;

        public RemoverLivroCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RetornoRemoverLivroDto> Handle(RemoverLivroCommand request, CancellationToken cancellationToken)
        {
            var livro = await _context.Livro
                .Include(l => l.Autores)
                .Include(l => l.Assuntos)
                .FirstOrDefaultAsync(l => l.Id == request.Id);

            if (livro == null)
            {
                return new RetornoRemoverLivroDto
                {
                    Status = false,
                    Mensagem = "Livro não encontrado."
                };
            }

            livro.Autores.Clear();
            livro.Assuntos.Clear();
            _context.Livro.Remove(livro);
            await _context.SaveChangesAsync(cancellationToken);

            return new RetornoRemoverLivroDto
            {
                Status = true,
            };
        }
    }
}

