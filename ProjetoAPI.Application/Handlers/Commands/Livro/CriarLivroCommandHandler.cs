using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Application.Commands.Livros;
using ProjetoAPI.Infrastructure;
using LivroEntity = ProjetoAPI.Domain.Entities.Livro;

namespace ProjetoAPI.Application.Handlers.Commands.Livro
{

    public class CriarLivroCommandHandler : IRequestHandler<CriarLivroCommand, Guid>
    {
        private readonly ApplicationDbContext _context;

        public CriarLivroCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CriarLivroCommand request, CancellationToken cancellationToken)
        {
            var livro = new LivroEntity
            {
                Titulo = request.LivroDto.Titulo,
                Editora = request.LivroDto.Editora,
                Edicao = request.LivroDto.Edicao,
                AnoPublicao = request.LivroDto.AnoPublicao,
            };

            // Buscar e associar os Autores
            livro.Autores = await _context.Autor
                .Where(a => request.LivroDto.AutorIds.Contains(a.Id))
                .ToListAsync(cancellationToken);

            // Buscar e associar os Assuntos
            livro.Assuntos = await _context.Assunto
                .Where(s => request.LivroDto.AssuntoIds.Contains(s.Id))
                .ToListAsync(cancellationToken);

            _context.Livro.Add(livro);
            await _context.SaveChangesAsync(cancellationToken);
            return livro.Id;
        }
    }
}
