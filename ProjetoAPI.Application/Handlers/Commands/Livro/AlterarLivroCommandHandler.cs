using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Application.Commands.Livros;
using ProjetoAPI.Application.DTOs.Livro;
using ProjetoAPI.Domain.Interfaces.Livro;
using ProjetoAPI.Infrastructure;

namespace ProjetoAPI.Application.Handlers.Commands.Livro
{
    public class AlterarLivroCommandHandler : IRequestHandler<AlterarLivroCommand, RetornoAlterarLivroDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILivroService _livroService;
        public AlterarLivroCommandHandler(ApplicationDbContext context, ILivroService livroService)
        {
            _context = context;
            _livroService = livroService;
        }

        public async Task<RetornoAlterarLivroDto> Handle(AlterarLivroCommand request, CancellationToken cancellationToken)
        {
            var verifAssunto = await _livroService.ValidarAssuntos(request.LivroDto.AssuntoIds);
            if (!verifAssunto)
            {
                return new RetornoAlterarLivroDto
                {
                    Status = false,
                    Mensagem = "Existe(m) assunto(s) não cadastrado(s) no sistema"
                };
            }
            var verifAutor = await _livroService.ValidarAutores(request.LivroDto.AutorIds);
            if (!verifAutor)
            {
                return new RetornoAlterarLivroDto
                {
                    Status = false,
                    Mensagem = "Existe(m) autor(es) não cadastrado(s) no sistema"
                };
            }

            var livro = await _context.Livro
                .Include(l => l.Autores)
                .Include(l => l.Assuntos)
                .FirstOrDefaultAsync(l => l.Id == request.LivroDto.Id);

            if (livro == null)
            {
                return new RetornoAlterarLivroDto
                {
                    Status = false,
                    Mensagem = "Livro não encontrado."
                };
            }

            livro.Autores.Clear();
            livro.Assuntos.Clear();

            livro.Titulo = request.LivroDto.Titulo;
            livro.Editora = request.LivroDto.Editora;
            livro.Edicao = request.LivroDto.Edicao;
            livro.AnoPublicacao = request.LivroDto.AnoPublicacao;
            livro.Valor = request.LivroDto.Valor;

            // Buscar e associar os Autores
            livro.Autores = await _context.Autor
                .Where(a => request.LivroDto.AutorIds.Contains(a.Id))
                .ToListAsync(cancellationToken);

            // Buscar e associar os Assuntos
            livro.Assuntos = await _context.Assunto
                .Where(s => request.LivroDto.AssuntoIds.Contains(s.Id))
                .ToListAsync(cancellationToken);

            _context.Livro.Update(livro);
            await _context.SaveChangesAsync(cancellationToken);
            return new RetornoAlterarLivroDto
            {
                Status = true
            };
        }
    }
}
