using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Application.Queries.Autor;
using ProjetoAPI.Infrastructure;
using LivroEntity = ProjetoAPI.Domain.Entities.Livro;

namespace ProjetoAPI.Application.Handlers.Queries.Autor
{
    public class BuscarLivrosQueryHandler : IRequestHandler<BuscarLivrosQuery, IEnumerable<LivroEntity>>
    {
        private readonly ApplicationDbContext _context;

        public BuscarLivrosQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LivroEntity>> Handle(BuscarLivrosQuery request, CancellationToken cancellationToken)
        {
            //var query = from livro in _context.Livro
            //            join autor in _context.Autor
            //                on livro.Id equals autor.Livros.First().Id
            //            join assunto in _context.Assunto
            //                on livro.Id equals assunto.Livros.First().Id
            //            select new
            //            {
            //                LivroTitulo = livro.Titulo,
            //                AutorNome = autor.Nome,
            //                AssuntoDescricao = assunto.Descricao
            //            };
            //var resultado = await query.ToListAsync();

            //return resultado;
            return await _context.Livro
                .Include(l => l.Autores)
                .Include(l => l.Assuntos)
                .ToListAsync();
        }
    }
}

