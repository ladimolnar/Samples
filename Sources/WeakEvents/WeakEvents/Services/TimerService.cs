using System;
using Windows.UI.Xaml;
using Cirrious.MvvmCross.Plugins.Messenger;

namespace WeakEvents.Services
{
    public class TimerService
    {
        private readonly IMvxMessenger messenger;
        private DispatcherTimer timer;
        private int timerId;

        public TimerService(IMvxMessenger messenger)
        {
            this.messenger = messenger;
            timerId = 0;

            StartTimer();
        }

        private void StartTimer()
        {
            timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(3)};
            timer.Tick += (s, e) => OnRefreshTimerTick();
            timer.Start();
        }

        private void OnRefreshTimerTick()
        {
            messenger.Publish(new TimerMessage(this, timerId++));
        }
    }
}
