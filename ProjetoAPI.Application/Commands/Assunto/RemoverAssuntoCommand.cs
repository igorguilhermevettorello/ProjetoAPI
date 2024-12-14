using MediatR;

namespace ProjetoAPI.Application.Commands.Assunto
{
    public class RemoverAssuntoCommand : IRequest<Unit>
    {
        public Guid Id { get; }

        public RemoverAssuntoCommand(Guid id)
        {
            Id = id;
        }
    }
}
