
using System.Text;
using Windows.ApplicationModel.DataTransfer;
using Cirrious.MvvmCross.ViewModels;
using WeakEvents.Services;

namespace WeakEvents.ViewModels
{
    public class LoggerViewerViewModel : NotifyPropertyChangedBase
    {
        public LoggerService Logger { get; private set; }
        public MvxCommand CopyCommand { get; private set; }
        public MvxCommand ClearCommand { get; private set; }

        public LoggerViewerViewModel(LoggerService logger)
        {
            Logger = logger;

            CopyCommand = new MvxCommand(ExecuteCopyCommand);
            ClearCommand = new MvxCommand(ExecuteClearCommand);
        }

        private void ExecuteCopyCommand()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string logEntry in Logger.LogMessages)
            {
                sb.Append(logEntry);
                sb.Append("\r\n");
            }

            DataPackage dataPackage = new DataPackage();
            dataPackage.SetText(sb.ToString());

            Clipboard.SetContent(dataPackage);
        }

        private void ExecuteClearCommand()
        {
            Logger.Clear();
        }
    }
}
