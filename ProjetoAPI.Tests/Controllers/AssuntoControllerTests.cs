using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjetoAPI.API.Controllers;
using ProjetoAPI.Application.Commands.Assunto;
using ProjetoAPI.Application.DTOs.Assunto;
using ProjetoAPI.Application.Queries.Assunto;
using AssuntoEntity = ProjetoAPI.Domain.Entities.Assunto;

namespace ProjetoAPI.Tests.Controllers
{
    public class AssuntoControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly AssuntoController _controller;

        public AssuntoControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new AssuntoController(_mediatorMock.Object);
        }

        [Fact]
        public async Task GetAll_DeveRetornarOkComListaDeAssuntos()
        {
            // Arrange
            var assuntos = new List<AssuntoEntity>
            {
                new AssuntoEntity { Id = Guid.NewGuid(), Descricao = "Assunto 1" },
                new AssuntoEntity { Id = Guid.NewGuid(), Descricao = "Assunto 2" }
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<BuscarAssuntosQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(assuntos);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().BeEquivalentTo(assuntos);
        }

        [Fact]
        public async Task GetById_DeveRetornarOkQuandoAssuntoExiste()
        {
            // Arrange
            var assuntoId = Guid.NewGuid();
            var assunto = new AssuntoEntity { Id = assuntoId, Descricao = "Assunto Teste" };

            _mediatorMock.Setup(m => m.Send(It.Is<BuscarAssuntoPorIdQuery>(q => q.id == assuntoId), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(assunto);

            // Act
            var result = await _controller.GetById(assuntoId);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().BeEquivalentTo(assunto);
        }

        [Fact]
        public async Task GetById_DeveRetornarNotFoundQuandoAssuntoNaoExiste()
        {
            // Arrange
            var assuntoId = Guid.NewGuid();

            _mediatorMock.Setup(m => m.Send(It.Is<BuscarAssuntoPorIdQuery>(q => q.id == assuntoId), It.IsAny<CancellationToken>()))
                         .ReturnsAsync((AssuntoEntity)null);

            // Act
            var result = await _controller.GetById(assuntoId);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task CreateAuthor_DeveRetornarOkComId()
        {
            // Arrange
            var assuntoDto = new CriarAssuntoDto { Descricao = "Novo Assunto" };
            var assuntoId = Guid.NewGuid();

            _mediatorMock.Setup(m => m.Send(It.IsAny<CriarAssuntoCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(assuntoId);

            // Act
            var result = await _controller.CreateAuthor(assuntoDto);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().BeEquivalentTo(new { id = assuntoId });
        }

        //[Fact]
        //public async Task Update_DeveRetornarNoContent()
        //{
        //    // Arrange
        //    var assuntoId = Guid.NewGuid();
        //    var alterarAssuntoDto = new AlterarAssuntoDto { Id = assuntoId, Descricao = "Assunto Atualizado" };

        //    _mediatorMock.Setup(m => m.Send(It.IsAny<AlterarAssuntoCommand>(), It.IsAny<CancellationToken>()))
        //                 .Returns((Task<Unit>)Task.CompletedTask);

        //    // Act
        //    var result = await _controller.Update(assuntoId, alterarAssuntoDto);

        //    // Assert
        //    result.Should().BeOfType<NoContentResult>();
        //}

        [Fact]
        public async Task Update_DeveRetornarBadRequestSeIdsNaoConcordam()
        {
            // Arrange
            var assuntoId = Guid.NewGuid();
            var alterarAssuntoDto = new AlterarAssuntoDto { Id = Guid.NewGuid(), Descricao = "Outro Id" };

            // Act
            var result = await _controller.Update(assuntoId, alterarAssuntoDto);

            // Assert
            result.Should().BeOfType<BadRequestResult>();
        }

        //[Fact]
        //public async Task Delete_DeveRetornarNoContentQuandoAssuntoExiste()
        //{
        //    // Arrange
        //    var assuntoId = Guid.NewGuid();
        //    var assuntoDto = new AssuntoEntity { Id = assuntoId, Descricao = "Assunto Para Deletar" };

        //    _mediatorMock.Setup(m => m.Send(It.Is<BuscarAssuntoPorIdQuery>(q => q.id == assuntoId), It.IsAny<CancellationToken>()))
        //                 .ReturnsAsync(assuntoDto);

        //    _mediatorMock.Setup(m => m.Send(It.IsAny<RemoverAssuntoCommand>(), It.IsAny<CancellationToken>()))
        //                 .Returns((Task<Unit>)Task.CompletedTask);

        //    // Act
        //    var result = await _controller.Delete(assuntoId);

        //    // Assert
        //    result.Should().BeOfType<NoContentResult>();
        //}

        [Fact]
        public async Task Delete_DeveRetornarNotFoundSeAssuntoNaoExiste()
        {
            // Arrange
            var assuntoId = Guid.NewGuid();

            _mediatorMock.Setup(m => m.Send(It.Is<BuscarAssuntoPorIdQuery>(q => q.id == assuntoId), It.IsAny<CancellationToken>()))
                         .ReturnsAsync((AssuntoEntity)null);

            // Act
            var result = await _controller.Delete(assuntoId);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }
    }
}
