namespace IceGestor.Core.Entities;
public class User : BaseEntity
{
    public User(string username, string password, string email)
    {
        Username = username;
        Password = password;
        Email = email;

        CreatedAt = DateTime.Now;
    }

    public string Username { get; private set; }
    public string Password { get; private set; }
    public string Email { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public void UpdateUser(string password, string email)
    {
        Password = password;
        Email = email;

        UpdatedAt = DateTime.Now;
    }
}
