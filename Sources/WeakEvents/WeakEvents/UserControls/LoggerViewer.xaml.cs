using Cirrious.CrossCore;
using WeakEvents.Services;
using Windows.ApplicationModel;
using Windows.UI.Xaml.Controls;
using WeakEvents.ViewModels;

namespace WeakEvents.UserControls
{
    public sealed partial class LoggerViewerControl : UserControl
    {
        public LoggerViewerControl()
        {
            this.InitializeComponent();

            if (DesignMode.DesignModeEnabled == false)
            {
                this.DataContext = new LoggerViewerViewModel(Mvx.Resolve<LoggerService>());
            }
        }
    }
}
