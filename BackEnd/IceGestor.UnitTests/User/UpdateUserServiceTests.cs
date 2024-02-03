using IceGestor.Application.Authentication;
using IceGestor.Application.Models.InputModels.User;
using IceGestor.Application.Services.User.UpdateUser;
using IceGestor.Core.RepositoriesInterfaces;
using IceGestor.Infra.Persistence;
using Moq;

namespace IceGestor.UnitTests.User;
public class UpdateUserServiceTests
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        var unityOfWork = new Mock<IUnityOfWork>();
        var authService = new Mock<IAuthService>();
        var userRepository = new Mock<IUserRepository>();

        var user = new Core.Entities.User("test", "TestPass@321", "testUser@example.com");

        unityOfWork.SetupGet(uow => uow.Users).Returns(userRepository.Object);

        unityOfWork.Setup(x => x.Users.GetUserById(It.IsAny<int>()).Result).Returns(user);

        unityOfWork.Setup(x => x.Users.Update(It.IsAny<Core.Entities.User>())).Verifiable();

        authService.Setup(x => x.ComputeSha256Hash(It.IsAny<string>())).Returns("hashedPassword");


        var request = new UpdateUserInputModel()
        {
            Id = 1,
            Email = "test@example.com",
            Password = "TestPass@123"
        };

        var service = new UpdateUserService(unityOfWork.Object, authService.Object);


        await service.Execute(request);

        unityOfWork.Verify(uow => uow.Users.Update(It.IsAny<Core.Entities.User>()), Times.Once);

    }
}
