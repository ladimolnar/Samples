using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.WindowsCommon.Views;
using WeakEvents.Services;

namespace WeakEvents.Views
{
    public sealed partial class Page2View : MvxWindowsPage
    {
        private readonly IMvxMessenger messenger;
        private readonly LoggerService logger;

        public Page2View()
        {
            this.InitializeComponent();

            messenger = Mvx.Resolve<IMvxMessenger>();
            logger = Mvx.Resolve<LoggerService>();

            this.Loaded += OnPage2ViewLoaded;
            this.Unloaded += OnPage2ViewUnloaded;

            logger.LogInfo("Page2View: Ctor.");
        }

        void OnPage2ViewLoaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            logger.LogInfo("Page2View: OnPage2ViewLoaded.");
            messenger.SubscribeOnMainThread<TimerMessage>(OnTimerMessage);
        }

        void OnPage2ViewUnloaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            logger.LogInfo("Page2View: OnPage2ViewUnloaded.");
        }

        private void OnTimerMessage(TimerMessage timerMessage)
        {
            logger.LogInfo("Page2View: OnTimerMessage: {0}.", timerMessage);
        }
    }
}
