using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Application.Commands.Livros
{
    public class RemoverLivroCommand : IRequest<Unit>
    {
        public Guid Id { get; }

        public RemoverLivroCommand(Guid id)
        {
            Id = id;
        }
    }
}
