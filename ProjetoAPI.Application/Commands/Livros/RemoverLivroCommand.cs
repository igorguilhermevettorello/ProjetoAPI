﻿using MediatR;
using ProjetoAPI.Application.DTOs.Livro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Application.Commands.Livros
{
    public class RemoverLivroCommand : IRequest<RetornoRemoverLivroDto>
    {
        public Guid Id { get; }

        public RemoverLivroCommand(Guid id)
        {
            Id = id;
        }
    }
}
