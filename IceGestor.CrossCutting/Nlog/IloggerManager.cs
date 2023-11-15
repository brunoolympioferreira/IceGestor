using IceGestor.CrossCutting.Exceptions;

namespace IceGestor.CrossCutting.Nlog;
public interface IloggerManager
{
    void LogInfo(string message);
    void LogError(string message, IceGestorException ex);
}
