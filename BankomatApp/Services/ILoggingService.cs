namespace BankomatApp.Services;

public interface ILoggingService
{
    void LogInfo(string message);
    void LogError(string  message);
}
