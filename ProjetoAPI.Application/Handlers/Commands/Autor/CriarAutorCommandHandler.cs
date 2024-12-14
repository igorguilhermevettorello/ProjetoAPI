using MediatR;
using ProjetoAPI.Application.Commands.Autor;
using ProjetoAPI.Infrastructure;
using AutorEntity = ProjetoAPI.Domain.Entities.Autor;

namespace ProjetoAPI.Application.Handlers.Commands.Autor
{
    public class CriarAutorCommandHandler : IRequestHandler<CriarAutorCommand, Guid>
    {
        private readonly ApplicationDbContext _context;

        public CriarAutorCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CriarAutorCommand request, CancellationToken cancellationToken)
        {
            var autor = new AutorEntity
            {
                Nome = request.AuthorDto.Nome
            };

            _context.Autor.Add(autor);
            await _context.SaveChangesAsync();
            return autor.Id;
        }
    }
}
