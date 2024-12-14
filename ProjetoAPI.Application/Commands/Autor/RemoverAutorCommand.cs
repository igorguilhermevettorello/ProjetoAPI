using MediatR;

namespace ProjetoAPI.Application.Commands.Autor
{
    public class RemoverAutorCommand : IRequest<Unit>
    {
        public Guid Id { get; }

        public RemoverAutorCommand(Guid id)
        {
            Id = id;
        }
    }
}
