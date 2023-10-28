using FluentValidation.TestHelper;
using IceGestor.Application.Authentication;
using IceGestor.Application.Services.User.CreateUser;
using IceGestor.Core.RepositoriesInterfaces;
using IceGestor.CrossCutting.InputModels.User;
using IceGestor.CrossCutting.ViewModels.User;
using Moq;

namespace IceGestor.UnitTests.User;

public class CreateUserServiceTests
{
    [Fact]
    public async Task InputDataIsOk_Executed_ReturnViewModel()
    {
        // Arrange
        var userRepositoryMock = new Mock<IUserRepository>();
        var authServiceMock = new Mock<IAuthService>();

        var service = new CreateUserService(userRepositoryMock.Object, authServiceMock.Object);

        CreateUserInputModel request = new()
        {
            Username = "bruno_ferreira",
            Password = "senha@123Bruno",
            Email = "bruno@email.com"
        };

        string expectedToken = "test-token";

        // Setup mocks
        authServiceMock.Setup(x => x.ComputeSha256Hash(request.Password))
                       .Returns("hashed-password");

        authServiceMock.Setup(x => x.GenerateJwtToken(request.Email, request.Username))
                       .Returns(expectedToken);

        // Act
        UserCreatedViewModel result = await service.Execute(request);

        // Assert
        userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Core.Entities.User>()), Times.Once);
        authServiceMock.Verify(x => x.ComputeSha256Hash(request.Password), Times.Once);
        authServiceMock.Verify(x => x.GenerateJwtToken(request.Email, request.Username), Times.Once);

        Assert.NotNull(result);
        Assert.Equal(request.Username, result.Username);
        Assert.Equal(request.Email, result.Email);
        Assert.Equal(expectedToken, result.Token);
    }
}