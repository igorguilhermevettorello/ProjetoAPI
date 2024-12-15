using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Application.Commands.Assunto;
using ProjetoAPI.Application.DTOs.Assunto;
using ProjetoAPI.Application.Handlers.Commands.Assunto;
using ProjetoAPI.Infrastructure;
using AssuntoEntity = ProjetoAPI.Domain.Entities.Assunto;

namespace ProjetoAPI.Tests.Handlers.Commands.Assunto
{
    public class AlterarAssuntoCommandHandlerTests
    {
        private readonly ApplicationDbContext _context;
        private readonly AlterarAssuntoCommandHandler _handler;

        public AlterarAssuntoCommandHandlerTests()
        {
            // Configuração do InMemoryDatabase
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationDbContext(options);

            _handler = new AlterarAssuntoCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_DeveAtualizarAssuntoComSucesso()
        {
            var assunto = new AssuntoEntity
            {
                Id = Guid.NewGuid(),
                Descricao = "Descrição Antiga"
            };

            // Adiciona um registro inicial no banco InMemory
            await _context.Assunto.AddAsync(assunto);
            await _context.SaveChangesAsync();
            _context.Entry(assunto).State = EntityState.Detached;

            var command = new AlterarAssuntoCommand(new AlterarAssuntoDto
            {
                Id = assunto.Id,
                Descricao = "Descrição Atualizada"
            });

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            var assuntoAtualizado = await _context.Assunto.FindAsync(assunto.Id);

            assuntoAtualizado.Should().NotBeNull();
            assuntoAtualizado.Descricao.Should().Be("Descrição Atualizada");

            result.Should().Be(Unit.Value);
        }

        [Fact]
        public async Task Handle_DeveLancarExcecaoSeSaveChangesFalhar()
        {
            // Arrange
            var assuntoDto = new AlterarAssuntoDto
            {
                Id = Guid.NewGuid(),
                Descricao = "Assunto Falhou"
            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("FailingDatabase")
                .Options;

            await using var context = new FailingDbContext(options);
            var handler = new AlterarAssuntoCommandHandler(context);

            var command = new AlterarAssuntoCommand(new AlterarAssuntoDto
            {
                Id = Guid.NewGuid(),
                Descricao = "Descrição Atualizada"
            });

            // Act
            Func<Task> act = async () => await handler.Handle(command, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<Exception>()
                     .WithMessage("Simulando falha no SaveChangesAsync");
        }
    }

    public class FailingDbContext : ApplicationDbContext
    {
        public FailingDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new Exception("Simulando falha no SaveChangesAsync");
        }
    }
}
