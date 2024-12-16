using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Application.Commands.Assunto;
using ProjetoAPI.Infrastructure;

namespace ProjetoAPI.Application.Handlers.Commands.Assunto
{
    public class RemoverAssuntoCommandHander : IRequestHandler<RemoverAssuntoCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public RemoverAssuntoCommandHander(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoverAssuntoCommand request, CancellationToken cancellationToken)
        {
            var assunto = await _context.Assunto.FindAsync(request.Id);
            
            var livros = await _context.Livro.Where(l => l.Assuntos.Any(la => la.Id == request.Id)).ToListAsync();
            if (livros.Any())
                throw new Exception("Usuário não pode ser excluído.");

            _context.Assunto.Remove(assunto);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
