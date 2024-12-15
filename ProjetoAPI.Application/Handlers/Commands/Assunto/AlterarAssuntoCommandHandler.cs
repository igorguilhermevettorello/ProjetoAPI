using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Application.Commands.Assunto;
using ProjetoAPI.Application.Commands.Autor;
using ProjetoAPI.Infrastructure;
using AssuntoEntity = ProjetoAPI.Domain.Entities.Assunto;

namespace ProjetoAPI.Application.Handlers.Commands.Assunto
{
    public class AlterarAssuntoCommandHandler : IRequestHandler<AlterarAssuntoCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public AlterarAssuntoCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AlterarAssuntoCommand request, CancellationToken cancellationToken)
        {
            var assunto = new AssuntoEntity
            {
                Id = request.AssuntoDto.Id,
                Descricao = request.AssuntoDto.Descricao
            };

            //_context.Entry(assunto).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
            _context.Assunto.Update(assunto);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
