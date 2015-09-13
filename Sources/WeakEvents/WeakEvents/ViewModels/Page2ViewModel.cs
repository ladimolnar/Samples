using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using WeakEvents.Services;

namespace WeakEvents.ViewModels
{
    public class Page2ViewModel : MvxViewModel
    {
        public MvxCommand GoBackCommand { get; private set; }

        public Page2ViewModel()
        {
            GoBackCommand = new MvxCommand(ExecuteGoBackCommand);
        }

        private void ExecuteGoBackCommand()
        {
            Close(this);
        }
    }
}
