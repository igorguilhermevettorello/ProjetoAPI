using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Application.Commands.Autor;
using ProjetoAPI.Infrastructure;
using AutorEntity = ProjetoAPI.Domain.Entities.Autor;

namespace ProjetoAPI.Application.Handlers.Commands.Autor
{
    public class AlterarAutorCommandHandler : IRequestHandler<AlterarAutorCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public AlterarAutorCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AlterarAutorCommand request, CancellationToken cancellationToken)
        {
            var autor = new AutorEntity
            {
                Id = request.AuthorDto.Id,
                Nome = request.AuthorDto.Nome
            };

            _context.Entry(autor).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
