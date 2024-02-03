using FluentAssertions;
using IceGestor.Application.Authentication;
using IceGestor.Application.Models.InputModels.User;
using IceGestor.Application.Services.User.CreateUser;
using IceGestor.Core.RepositoriesInterfaces;
using IceGestor.CrossCutting.Exceptions;
using IceGestor.CrossCutting.Nlog;
using IceGestor.Infra.Persistence;
using Moq;

namespace IceGestor.UnitTests.User;

public class CreateUserServiceTests
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        //Arrange
        var unityOfWork = new Mock<IUnityOfWork>();
        var authService = new Mock<IAuthService>();
        var userRepository = new Mock<IUserRepository>();

        unityOfWork.SetupGet(uow => uow.Users).Returns(userRepository.Object);
        var request = new CreateUserInputModel()
        {
            Username = "testUser",
            Email = "test@example.com",
            Password = "TestPass@123"
        };

        var service = new CreateUserService(unityOfWork.Object, authService.Object);

        var response = await service.Execute(request);
        response.Token = "token-test";

        response.Should().NotBeNull();
        response.Token.Should().NotBeNullOrWhiteSpace();
        response.Username.Should().NotBeNullOrWhiteSpace();
        response.Email.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task Validar_Senha_Invalida()
    {
        //Arrange
        var unityOfWork = new Mock<IUnityOfWork>();
        var authService = new Mock<IAuthService>();
        var userRepository = new Mock<IUserRepository>();
        var logger = new Mock<IloggerManager>();

        unityOfWork.SetupGet(uow => uow.Users).Returns(userRepository.Object);
        var request = new CreateUserInputModel()
        {
            Username = "testUser",
            Email = "test@example.com",
            Password = "password"
        };

        var service = new CreateUserService(unityOfWork.Object, authService.Object);

        Func<Task> acao = async () => { await service.Execute(request); };

        await acao.Should().ThrowAsync<ValidationErrorsException>()
            .Where(ex => ex.ErrorMessages.Count == 1 &&
                ex.ErrorMessages.Contains("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma minúscula, e um caractere especial"));
                
    }

}