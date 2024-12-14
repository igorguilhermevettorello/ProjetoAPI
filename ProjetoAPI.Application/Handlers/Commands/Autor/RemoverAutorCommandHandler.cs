using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Application.Commands.Autor;
using ProjetoAPI.Application.Queries.Autor;
using ProjetoAPI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _context.Autor.Remove(autor);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
