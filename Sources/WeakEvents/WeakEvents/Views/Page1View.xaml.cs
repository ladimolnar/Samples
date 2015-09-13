using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.WindowsCommon.Views;
using WeakEvents.Services;
using WeakEvents.ViewModels;

namespace WeakEvents.Views
{
    public sealed partial class Page1View : MvxWindowsPage
    {
        private readonly IMvxMessenger messenger;
        private readonly LoggerService logger;

        private MvxSubscriptionToken timerMessageToken;

        public Page1View()
        {
            this.InitializeComponent();

            messenger = Mvx.Resolve<IMvxMessenger>();
            logger = Mvx.Resolve<LoggerService>();

            this.Loaded += OnPage1ViewLoaded;
            this.Unloaded += OnPage1ViewUnloaded;

            logger.LogInfo("Page1View: Ctor.");
        }

        void OnPage1ViewLoaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            logger.LogInfo("Page1View: OnPage1ViewLoaded.");
            timerMessageToken = messenger.SubscribeOnMainThread<TimerMessage>(OnTimerMessage);
        }

        void OnPage1ViewUnloaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            logger.LogInfo("Page1View: OnPage1ViewUnloaded.");
            messenger.Unsubscribe<TimerMessage>(timerMessageToken);
        }

        private void OnTimerMessage(TimerMessage timerMessage)
        {
            logger.LogInfo("Page1View: OnTimerMessage: {0}.", timerMessage);
        }
    }
}
