using FluentAssertions;
using IceGestor.Application.Authentication;
using IceGestor.Application.Services.User.Login;
using IceGestor.Core.Entities;
using IceGestor.Core.RepositoriesInterfaces;
using IceGestor.CrossCutting.Exceptions;
using IceGestor.CrossCutting.InputModels.User;
using IceGestor.Infra.Persistence;
using Moq;

namespace IceGestor.UnitTests.User;
public class UserLoginServiceTests
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        var unityOfWork = new Mock<IUnityOfWork>();
        var authService = new Mock<IAuthService>();
        var userRepository = new Mock<IUserRepository>();

        var request = new LoginUserInputModel
        {
            Email = "test@example.com",
            Password = "TestPass@123"
        };

        var user = new Core.Entities.User("userTest", "TestPass@123", "test@example.com");
        unityOfWork.SetupGet(uow => uow.Users).Returns(userRepository.Object);
        authService.Setup(x => x.ComputeSha256Hash(It.IsAny<string>())).Returns("hashedPassword");
        unityOfWork.Setup(x => x.Users.GetUserByEmailAndPasswordAsync(It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(user);
        authService.Setup(x => x.GenerateJwtToken(It.IsAny<string>(), It.IsAny<string>())).Returns("token");

        var service = new UserLoginService(authService.Object, unityOfWork.Object);

        var response = await service.Login(request);

        response.Should().NotBeNull();
        response.Email.Should().Be(user.Email);
        response.Token.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task Validar_Login_Invalido()
    {
        var unityOfWork = new Mock<IUnityOfWork>();
        var authService = new Mock<IAuthService>();
        var userRepository = new Mock<IUserRepository>();

        var service = new UserLoginService(authService.Object, unityOfWork.Object);

        var request = new LoginUserInputModel
        {
            Email = "test@example.com",
            Password = "TestPass@123"
        };

        authService.Setup(x => x.ComputeSha256Hash(It.IsAny<string>())).Returns("hashedPassword");
        unityOfWork.Setup(x => x.Users.GetUserByEmailAndPasswordAsync(It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync((Core.Entities.User)null);

        await Assert.ThrowsAsync<IceGestorException>(() => service.Login(request));
    }
}
