using FluentValidation.TestHelper;
using IceGestor.Application.Authentication;
using FluentAssertions;
using IceGestor.Application.Services.User.CreateUser;
using IceGestor.Core.RepositoriesInterfaces;
using IceGestor.CrossCutting.InputModels.User;
using IceGestor.CrossCutting.ViewModels.User;
using IceGestor.Infra.Persistence;
using Moq;

namespace IceGestor.UnitTests.User;

public class CreateUserServiceTests
{
    [Fact]
    public async Task Execute_ValidInput_ReturnsUserCreatedViewModel()
    {
        // Arrange
        var unityOfWorkMock = new Mock<IUnityOfWork>();
        var authServiceMock = new Mock<IAuthService>();

        var createUserInputModel = new CreateUserInputModel
        {
            Username = "testuser",
            Email = "test@example.com",
            Password = "password"
        };

        var createUserService = new CreateUserService(unityOfWorkMock.Object, authServiceMock.Object);

        // Act
        var result = await createUserService.Execute(createUserInputModel);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<UserCreatedViewModel>();
        result.Username.Should().Be(createUserInputModel.Username);
        result.Email.Should().Be(createUserInputModel.Email);
        result.Token.Should().NotBeNullOrWhiteSpace();

        unityOfWorkMock.Verify(uow => uow.BeginTransactionAsync(), Times.Once);
        unityOfWorkMock.Verify(uow => uow.Users.AddAsync(It.IsAny<Core.Entities.User>()), Times.Once);
        unityOfWorkMock.Verify(uow => uow.CompleteAsync(), Times.Once);
        unityOfWorkMock.Verify(uow => uow.CommitAsync(), Times.Once);
        authServiceMock.Verify(authService => authService.GenerateJwtToken(createUserInputModel.Email, createUserInputModel.Username), Times.Once);
    }
}