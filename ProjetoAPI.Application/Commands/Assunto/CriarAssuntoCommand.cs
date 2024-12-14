using MediatR;
using ProjetoAPI.Application.DTOs.Assunto;

namespace ProjetoAPI.Application.Commands.Assunto
{
    public class CriarAssuntoCommand : IRequest<Guid>
    {
        public CriarAssuntoDto AssuntoDto { get; }

        public CriarAssuntoCommand(CriarAssuntoDto assuntoDto)
        {
            AssuntoDto = assuntoDto;
        }
    }
}
