namespace IceGestor.Application.Authentication;
public interface IAuthService
{
    string GenerateJwtToken(string email, string userName);
    string ComputeSha256Hash(string password);
}
