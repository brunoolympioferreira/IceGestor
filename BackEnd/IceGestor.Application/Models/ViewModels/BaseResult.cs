namespace IceGestor.Application.Models.ViewModels;
public class BaseResult
{
    public BaseResult(bool success = true, string message = "")
    {
        Success = success;
        Message = message;
    }

    public bool Success { get; private set; }
    public string Message { get; private set; }
}
