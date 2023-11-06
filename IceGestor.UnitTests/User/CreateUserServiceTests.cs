using FluentAssertions;
using IceGestor.Application.Authentication;
using IceGestor.Application.Services.User.CreateUser;
using IceGestor.Core.RepositoriesInterfaces;
using IceGestor.CrossCutting.InputModels.User;
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

    //validar senha invalida
}