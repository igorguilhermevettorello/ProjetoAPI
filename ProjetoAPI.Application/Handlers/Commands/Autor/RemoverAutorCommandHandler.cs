using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Application.Commands.Autor;
using ProjetoAPI.Domain.Entities;
using ProjetoAPI.Infrastructure;

namespace ProjetoAPI.Application.Handlers.Commands.Autor
{
    public class RemoverAutorCommandHandler : IRequestHandler<RemoverAutorCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public RemoverAutorCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoverAutorCommand request, CancellationToken cancellationToken)
        {
            var autor = await _context.Autor.FindAsync(request.Id);

            var livros = await _context.Livro.Where(l => l.Autores.Any(la => la.Id == request.Id)).ToListAsync();
            if (livros.Any())
                throw new Exception("Usuário não pode ser excluído.");
            
            _context.Autor.Remove(autor);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
