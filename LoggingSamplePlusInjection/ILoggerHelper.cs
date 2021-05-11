namespace LoggingSamplePlusInjection
{
    public interface ILoggerHelper
    {
        void LogStart();
        void LogEnd();
         void Log(string Messsage);
    }
}