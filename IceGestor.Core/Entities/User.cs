namespace IceGestor.Core.Entities;
public class User : BaseEntity
{
    public User(int username, string password, string email, DateTime createdAt, DateTime updatedAt)
    {
        Username = username;
        Password = password;
        Email = email;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public int Username { get; private set; }
    public string Password { get; private set; }
    public string Email { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
}
