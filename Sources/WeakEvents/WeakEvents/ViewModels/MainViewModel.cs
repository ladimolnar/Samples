using System;
using Cirrious.MvvmCross.ViewModels;
using WeakEvents.Services;

namespace WeakEvents.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private LoggerService logger;

        public MvxCommand GoToPage1Command { get; private set; }
        public MvxCommand GoToPage2Command { get; private set; }
        public MvxCommand ForceGarbageCollectionCommand { get; private set; }

        public MainViewModel(LoggerService logger)
        {
            this.logger = logger;

            GoToPage1Command = new MvxCommand(ExecuteGoToPage1Command);
            GoToPage2Command = new MvxCommand(ExecuteGoToPage2Command);
            ForceGarbageCollectionCommand = new MvxCommand(ExecuteForceGarbageCollectionCommand);
        }

        private void ExecuteGoToPage1Command()
        {
            ShowViewModel<Page1ViewModel>();
        }

        private void ExecuteGoToPage2Command()
        {
            ShowViewModel<Page2ViewModel>();
        }

        private void ExecuteForceGarbageCollectionCommand()
        {
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
            GC.WaitForPendingFinalizers();

            // Call GC.Collect again in case the finalization code used references that are now eligible for collection.
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);

            this.logger.LogInfo("Garbage collection was executed.");
        }
    }
}
