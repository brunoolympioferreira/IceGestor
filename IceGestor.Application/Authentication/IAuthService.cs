namespace IceGestor.Application.Authentication;
internal interface IAuthService
{
    string GenerateJwtToken(string email, string userName);
    string ComputeSha256Hash(string password);
}
