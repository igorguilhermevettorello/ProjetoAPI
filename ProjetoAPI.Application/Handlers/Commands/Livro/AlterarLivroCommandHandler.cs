using MediatR;
using ProjetoAPI.Application.Commands.Livros;
using ProjetoAPI.Infrastructure;

namespace ProjetoAPI.Application.Handlers.Commands.Livro
{
    public class AlterarLivroCommandHandler : IRequestHandler<AlterarLivroCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public AlterarLivroCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AlterarLivroCommand request, CancellationToken cancellationToken)
        {
            //var autor = new AutorEntity
            //{
            //    Id = request.AuthorDto.Id,
            //    Nome = request.AuthorDto.Nome
            //};

            //_context.Entry(autor).State = EntityState.Modified;
            //await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
