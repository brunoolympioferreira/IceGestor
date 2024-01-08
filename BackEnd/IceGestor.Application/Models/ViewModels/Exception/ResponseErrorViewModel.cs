namespace IceGestor.Application.Models.ViewModels.Exception;
public class ResponseErrorViewModel
{
    public List<string> Messages { get; set; }
    public ResponseErrorViewModel(List<string> messages)
    {
        Messages = messages;
    }
    public ResponseErrorViewModel(string message)
    {
        Messages = new List<string> { message };
    }
}
