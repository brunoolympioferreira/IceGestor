using IceGestor.CrossCutting.Exceptions;
using NLog;

namespace IceGestor.CrossCutting.Nlog;
public class LoggerManager : IloggerManager
{
    private static ILogger logger = LogManager.GetCurrentClassLogger();
    public void LogError(string message, IceGestorException ex)
    {
        logger.Info(message, ex);
    }

    public void LogInfo(string message)
    {
        logger.Error(message);
    }
}
