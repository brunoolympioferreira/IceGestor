namespace IceGestor.Core.Entities;
public class User : BaseEntity
{
    public User(int username, string password, string email)
    {
        Username = username;
        Password = password;
        Email = email;
    }

    public int Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
