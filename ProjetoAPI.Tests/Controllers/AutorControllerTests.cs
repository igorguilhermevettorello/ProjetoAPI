using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjetoAPI.API.Controllers;
using ProjetoAPI.Application.Commands.Autor;
using ProjetoAPI.Application.DTOs.Autor;
using ProjetoAPI.Application.Queries.Autor;
using AutorEntity = ProjetoAPI.Domain.Entities.Autor;

namespace ProjetoAPI.Tests.Controllers
{
    public class AutorControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly AutorController _controller;

        public AutorControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new AutorController(_mediatorMock.Object);
        }

        [Fact]
        public async Task GetAll_DeveRetornarOkComListaDeAutores()
        {
            // Arrange
            var autores = new List<AutorEntity>
            {
                new AutorEntity { Id = Guid.NewGuid(), Nome = "Autor 1" },
                new AutorEntity { Id = Guid.NewGuid(), Nome = "Autor 2" }
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<BuscarAutoresQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(autores);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().BeEquivalentTo(autores);
        }

        [Fact]
        public async Task GetById_DeveRetornarOkQuandoAutorExiste()
        {
            // Arrange
            var autorId = Guid.NewGuid();
            var autor = new AutorEntity { Id = autorId, Nome = "Autor Teste" };

            _mediatorMock.Setup(m => m.Send(It.Is<BuscarAutorPorIdQuery>(q => q.id == autorId), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(autor);

            // Act
            var result = await _controller.GetById(autorId);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().BeEquivalentTo(autor);
        }

        [Fact]
        public async Task GetById_DeveRetornarNotFoundQuandoAutorNaoExiste()
        {
            // Arrange
            var autorId = Guid.NewGuid();

            _mediatorMock.Setup(m => m.Send(It.Is<BuscarAutorPorIdQuery>(q => q.id == autorId), It.IsAny<CancellationToken>()))
                         .ReturnsAsync((AutorEntity)null);

            // Act
            var result = await _controller.GetById(autorId);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task CreateAuthor_DeveRetornarOkComId()
        {
            // Arrange
            var autorDto = new CriarAutorDto { Nome = "Novo Autor" };
            var autorId = Guid.NewGuid();

            _mediatorMock.Setup(m => m.Send(It.IsAny<CriarAutorCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(autorId);

            // Act
            var result = await _controller.CreateAuthor(autorDto);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().BeEquivalentTo(new { id = autorId });
        }

        //[Fact]
        //public async Task Update_DeveRetornarNoContent()
        //{
        //    Arrange
        //   var autorId = Guid.NewGuid();
        //    var alterarAutorDto = new AlterarAutorDto { Id = autorId, Nome = "Autor Atualizado" };

        //    _mediatorMock.Setup(m => m.Send(It.IsAny<AlterarAutorCommand>(), It.IsAny<CancellationToken>()))
        //                 .Returns((Task<Unit>)Task.CompletedTask);

        //    Act
        //   var result = await _controller.Update(autorId, alterarAutorDto);

        //    Assert
        //    result.Should().BeOfType<NoContentResult>();
        //}

        [Fact]
        public async Task Update_DeveRetornarBadRequestSeIdsNaoConcordam()
        {
            // Arrange
            var autorId = Guid.NewGuid();
            var alterarAutorDto = new AlterarAutorDto { Id = Guid.NewGuid(), Nome = "Outro Id" };

            // Act
            var result = await _controller.Update(autorId, alterarAutorDto);

            // Assert
            result.Should().BeOfType<BadRequestResult>();
        }

        //[Fact]
        //public async Task Delete_DeveRetornarNoContentQuandoAutorExiste()
        //{
        //    Arrange
        //   var autorId = Guid.NewGuid();
        //    var autorDto = new AutorEntity { Id = autorId, Nome = "Autor Para Deletar" };

        //    _mediatorMock.Setup(m => m.Send(It.Is<BuscarAutorPorIdQuery>(q => q.id == autorId), It.IsAny<CancellationToken>()))
        //                 .ReturnsAsync(autorDto);

        //    _mediatorMock.Setup(m => m.Send(It.IsAny<RemoverAutorCommand>(), It.IsAny<CancellationToken>()))
        //                 .Returns((Task<Unit>)Task.CompletedTask);

        //    Act
        //   var result = await _controller.Delete(autorId);

        //    Assert
        //    result.Should().BeOfType<NoContentResult>();
        //}

        [Fact]
        public async Task Delete_DeveRetornarNotFoundSeAutorNaoExiste()
        {
            // Arrange
            var autorId = Guid.NewGuid();

            _mediatorMock.Setup(m => m.Send(It.Is<BuscarAutorPorIdQuery>(q => q.id == autorId), It.IsAny<CancellationToken>()))
                         .ReturnsAsync((AutorEntity)null);

            // Act
            var result = await _controller.Delete(autorId);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }
    }
}
