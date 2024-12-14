using MediatR;
using ProjetoAPI.Application.Commands.Assunto;
using ProjetoAPI.Infrastructure;
using AssuntoEntity = ProjetoAPI.Domain.Entities.Assunto;

namespace ProjetoAPI.Application.Handlers.Commands.Assunto
{
    public class CriarAssuntoCommandHandler : IRequestHandler<CriarAssuntoCommand, Guid>
    {
        private readonly ApplicationDbContext _context;

        public CriarAssuntoCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CriarAssuntoCommand request, CancellationToken cancellationToken)
        {
            var assunto = new AssuntoEntity
            {
                Descricao = request.AssuntoDto.Descricao
            };

            _context.Assunto.Add(assunto);
            await _context.SaveChangesAsync();
            return assunto.Id;
        }
    }
}
