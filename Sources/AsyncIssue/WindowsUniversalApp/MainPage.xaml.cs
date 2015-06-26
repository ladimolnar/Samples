using System;
using System.Diagnostics;
using Common;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace WindowsUniversalApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly MyWorker myWorker;

        public MainPage()
        {
            myWorker = new MyWorker();

            this.InitializeComponent();
        }

        private void OnStartWorkerClick(object sender, RoutedEventArgs e)
        {
            myWorker.Start();
        }

        private void OnJoltWorkerClick(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("OnJoltWorkerClick is about to call myWorker.Jolt(). Thread ID: {0}", Environment.CurrentManagedThreadId);
            myWorker.Jolt();
        }

        private async void OnStopWorkerClick(object sender, RoutedEventArgs e)
        {
            await myWorker.StopAsync();
        }
    }
}
