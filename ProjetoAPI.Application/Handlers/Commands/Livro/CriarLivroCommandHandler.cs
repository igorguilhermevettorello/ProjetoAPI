using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Application.Commands.Livros;
using ProjetoAPI.Application.DTOs.Livro;
using ProjetoAPI.Domain.Interfaces.Livro;
using ProjetoAPI.Infrastructure;
using LivroEntity = ProjetoAPI.Domain.Entities.Livro;

namespace ProjetoAPI.Application.Handlers.Commands.Livro
{

    public class CriarLivroCommandHandler : IRequestHandler<CriarLivroCommand, RetornoCriarLivroDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILivroService _livroService;
        public CriarLivroCommandHandler(ApplicationDbContext context, ILivroService livroService)
        {
            _context = context;
            _livroService = livroService;
        }

        public async Task<RetornoCriarLivroDto> Handle(CriarLivroCommand request, CancellationToken cancellationToken)
        {

            var verifAssunto = await _livroService.ValidarAssuntos(request.LivroDto.AssuntoIds);
            if (!verifAssunto) 
            {
                return new RetornoCriarLivroDto
                {
                    Status = false,
                    Mensagem = "Existe(m) assunto(s) não cadastrado(s) no sistema"
                };
            }
            var verifAutor = await _livroService.ValidarAutores(request.LivroDto.AutorIds);
            if (!verifAutor)
            {
                return new RetornoCriarLivroDto
                {
                    Status = false,
                    Mensagem = "Existe(m) autor(es) não cadastrado(s) no sistema"
                };
            }

            var livro = new LivroEntity
            {
                Titulo = request.LivroDto.Titulo,
                Editora = request.LivroDto.Editora,
                Edicao = request.LivroDto.Edicao,
                AnoPublicacao = request.LivroDto.AnoPublicacao,
                Valor = request.LivroDto.Valor
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
            return new RetornoCriarLivroDto
            {
                Status = true,
                Id = livro.Id
            };
        }
    }
}
