﻿using MediatR;
using ProjetoAPI.Application.Commands.Assunto;
using ProjetoAPI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssuntoEntity = ProjetoAPI.Domain.Entities.Assunto;

namespace ProjetoAPI.Application.Handlers.Commands.Assunto
{
    public class RemoverAssuntoCommandHander : IRequestHandler<RemoverAssuntoCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public RemoverAssuntoCommandHander(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoverAssuntoCommand request, CancellationToken cancellationToken)
        {
            var assunto = await _context.Assunto.FindAsync(request.Id);
            _context.Assunto.Remove(assunto);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
