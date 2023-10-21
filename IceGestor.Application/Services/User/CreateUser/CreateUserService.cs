using IceGestor.Application.Authentication;
using IceGestor.CrossCutting.InputModels.User;
using IceGestor.CrossCutting.ViewModels.User;
using IceGestor.Infra.Persistence;

namespace IceGestor.Application.Services.User.CreateUser;
public class CreateUserService : ICreateUserService
{
    private readonly IceGestorDbContext _dbContext;
    private readonly IAuthService _authService;
    public CreateUserService(IceGestorDbContext dbContext, IAuthService authService)
    {
        _dbContext = dbContext;
        _authService = authService;
    }
    public async Task<UserCreatedViewModel> Execute(CreateUserInputModel request)
    {
        var passwordHash = _authService.ComputeSha256Hash(request.Password);

        DateTime createdAt = DateTime.Now;

        Core.Entities.User user = new(request.Username, passwordHash, request.Email, createdAt, default);

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        var token = _authService.GenerateJwtToken(user.Email, user.Username);

        return new UserCreatedViewModel
        {
            Username = user.Username,
            Email = user.Email,
            Token = token
        };
    }
}
