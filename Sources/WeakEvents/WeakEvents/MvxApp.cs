using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using WeakEvents.Services;
using WeakEvents.ViewModels;

namespace WeakEvents
{
    public class MvxApp: MvxApplication
    {
        public override void Initialize()
        {
            RegisterServices();

            // Setup the starting view model
            RegisterAppStart<MainViewModel>();
        }

        private void RegisterServices()
        {
            Mvx.ConstructAndRegisterSingleton<LoggerService, LoggerService>();
            Mvx.ConstructAndRegisterSingleton<TimerService, TimerService>();
        }
    }
}
