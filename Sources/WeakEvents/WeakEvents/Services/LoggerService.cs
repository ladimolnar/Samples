using System.Collections.ObjectModel;
using System.Diagnostics;

namespace WeakEvents.Services
{
    public class LoggerService
    {
        private readonly ObservableCollection<string> logMessages;
        public ReadOnlyObservableCollection<string> LogMessages { get; private set; }

        public LoggerService()
        {
            logMessages = new ObservableCollection<string>();
            LogMessages = new ReadOnlyObservableCollection<string>(logMessages);
        }

        public void LogInfo(string message, params object[] args)
        {
            string loggedMessage = string.Format(message, args);
            logMessages.Add(loggedMessage);
            Debug.WriteLine(loggedMessage);
        }

        public void Clear()
        {
            logMessages.Clear();
        }
    }
}
