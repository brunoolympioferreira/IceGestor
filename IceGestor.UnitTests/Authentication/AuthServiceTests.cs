using IceGestor.Application.Authentication;
using Microsoft.Extensions.Configuration;
using Moq;
using System.IdentityModel.Tokens.Jwt;

namespace IceGestor.UnitTests.Authentication;
public class AuthServiceTests
{
    [Fact]
    public void GenerateJwtToken_ReturnsValidToken()
    {
        // Arrange
        var configurationMock = new Mock<IConfiguration>();
        configurationMock.Setup(x => x["Jwt:Issuer"]).Returns("IceGestor");
        configurationMock.Setup(x => x["Jwt:Audience"]).Returns("IceGestorUI");
        configurationMock.Setup(x => x["Jwt:Key"]).Returns("Minha Super Senha Secreta Para Proteger Meus Tokens!");

        var authService = new AuthService(configurationMock.Object);
        string email = "test@example.com";
        string userName = "testuser";

        // Act
        string token = authService.GenerateJwtToken(email, userName);

        // Assert
        Assert.NotNull(token);
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

        Assert.NotNull(securityToken);
        Assert.Equal("IceGestor", securityToken.Issuer);
        Assert.Equal("IceGestorUI", securityToken.Audiences.First().ToString());
        Assert.Equal(userName, securityToken.Claims.First(claim => claim.Type == "userName").Value);
        Assert.Equal(email, securityToken.Claims.First(claim => claim.Type == "email").Value);
    }

    [Fact]
    public void ComputeSha256Hash_ComputesCorrectHash()
    {
        // Arrange
        var configurationMock = new Mock<IConfiguration>();
        var authService = new AuthService(configurationMock.Object);
        string password = "testpassword";
        string expectedHash = "9f735e0df9a1ddc702bf0a1a7b83033f9f7153a00c29de82cedadc9957289b05";

        // Act
        string computedHash = authService.ComputeSha256Hash(password);

        // Assert
        Assert.Equal(expectedHash, computedHash);
    }
}
