namespace IceGestor.Core.Entities;
public class Log
{
    public int Id { get; set; }
    public string LogLevel { get; set; }
    public string Message { get; set; }
    public string Exception { get; set; }
    public DateTime CreatedAt { get; set; }
}
