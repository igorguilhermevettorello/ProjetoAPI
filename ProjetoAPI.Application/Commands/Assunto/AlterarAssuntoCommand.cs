using MediatR;
using ProjetoAPI.Application.DTOs.Assunto;

namespace ProjetoAPI.Application.Commands.Assunto
{
    public class AlterarAssuntoCommand : IRequest<Unit>
    {
        public AlterarAssuntoDto AssuntoDto { get; }

        public AlterarAssuntoCommand(AlterarAssuntoDto assuntoDto)
        {
            AssuntoDto = assuntoDto;
        }
    }
}
