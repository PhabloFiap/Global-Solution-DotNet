using Global.Domain.Entities;
using Global.Domain.Interfaces;
using Global.Domain.Interfaces.Dto;
using Global.Infrastructure.Data.AppData;
using Global.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Tests
{
    public class MoradorApplicationServiceTests
    {
        private readonly Mock<IMoradorRepository> _repositoryMock;

        private readonly MoradorApplicationService _moradorService;

        public MoradorApplicationServiceTests()
        {
            _repositoryMock = new Mock<IMoradorRepository>();
            _moradorService = new MoradorApplicationService(_repositoryMock.Object); // Inicialização do serviço
        }

        [Fact]
        public void GetMorador_ReturnsMorador_WhenMoradorExists()
        {
            // Arrange
            var moradorId = 1;
            var expectedMorador = new MoradorEntity { id = moradorId, nome = "Morador Teste", cpf = "12341111111" };

            _repositoryMock.Setup(repo => repo.ObterMorador(moradorId))
                           .Returns(expectedMorador);

            // Act
            var actualMorador = _moradorService.ObterMorador(moradorId);

            // Assert
            Assert.Equal(expectedMorador, actualMorador);
            _repositoryMock.Verify(repo => repo.ObterMorador(moradorId), Times.Once);
        }

        [Fact]
        public void GetMorador_ReturnsNull_WhenMoradorDoesNotExist()
        {
            // Arrange
            var moradorId = 1;

            _repositoryMock.Setup(repo => repo.ObterMorador(moradorId))
                           .Returns((MoradorEntity)null);

            // Act
            var actualMorador = _moradorService.ObterMorador(moradorId);

            // Assert
            Assert.Null(actualMorador);
            _repositoryMock.Verify(repo => repo.ObterMorador(moradorId), Times.Once);
        }

        [Fact]
        public void InserirMorador_CreatesMorador_WhenDtoIsValid()
        {
            // Arrange
            var novoMoradorDto = new Mock<IMoradorDto>();
            novoMoradorDto.SetupGet(m => m.nome).Returns("João");
            novoMoradorDto.SetupGet(m => m.cpf).Returns("12345678901");

            var novaEntidadeEsperada = new MoradorEntity
            {
                nome = "João",
                cpf = "12345678901"
            };

            _repositoryMock.Setup(repo => repo.InserirMorador(It.IsAny<MoradorEntity>()))
                           .Callback<MoradorEntity>(m =>
                           {
                               m.id = 1; // Simula a atribuição de ID pelo banco
                           })
                           .Returns(novaEntidadeEsperada);

            // Act
            var resultado = _moradorService.InserirMorador(novoMoradorDto.Object);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal("João", resultado.nome);
            Assert.Equal("12345678901", resultado.cpf);
            _repositoryMock.Verify(repo => repo.InserirMorador(It.IsAny<MoradorEntity>()), Times.Once);
        }

        [Fact]
        public void DeleteMorador_DeletesMorador_WhenMoradorExists()
        {
            // Arrange
            var moradorId = 1;
            var existingMorador = new MoradorEntity { id = moradorId, nome = "Morador Existente" };

            // Configura o mock para retornar o morador existente
            _repositoryMock.Setup(repo => repo.ObterMorador(moradorId))
                           .Returns(existingMorador);

            // Configura o mock para simular a exclusão
            _repositoryMock.Setup(repo => repo.DeletarMorador(moradorId))
                           .Verifiable();

            // Act
            var result = _moradorService.DeletarMorador(moradorId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(existingMorador, result);
            _repositoryMock.Verify(repo => repo.ObterMorador(moradorId), Times.Once);
            _repositoryMock.Verify(repo => repo.DeletarMorador(moradorId), Times.Once);
        }

        [Fact]
        public void DeleteMorador_ReturnsNull_WhenMoradorDoesNotExist()
        {
            // Arrange
            var moradorId = 1;

            // Configura o mock para retornar null quando o morador não é encontrado
            _repositoryMock.Setup(repo => repo.ObterMorador(moradorId))
                           .Returns((MoradorEntity)null);

            // Act
            var result = _moradorService.DeletarMorador(moradorId);

            // Assert
            Assert.Null(result);
            _repositoryMock.Verify(repo => repo.ObterMorador(moradorId), Times.Once);
            _repositoryMock.Verify(repo => repo.DeletarMorador(It.IsAny<int>()), Times.Never);
        }
    }
}