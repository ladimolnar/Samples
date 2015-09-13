using Windows.UI.Xaml;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.WindowsCommon.Views;
using WeakEvents.Services;

namespace WeakEvents.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainView : MvxWindowsPage
    {
        private readonly LoggerService logger;

        public MainView()
        {
            this.InitializeComponent();

            this.Loaded += OnMainViewLoaded;
            this.Unloaded += OnMainViewUnloaded;

            logger = Mvx.Resolve<LoggerService>();
        }

        void OnMainViewLoaded(object sender, RoutedEventArgs e)
        {
            logger.LogInfo("MainView: OnMainViewLoaded.");
        }

        void OnMainViewUnloaded(object sender, RoutedEventArgs e)
        {
            logger.LogInfo("MainView: OnMainViewUnloaded.");
        }
    }
}
