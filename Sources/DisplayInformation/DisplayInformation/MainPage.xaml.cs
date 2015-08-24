using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Display = Windows.Graphics.Display;

namespace DisplayInformation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Display.DisplayInformation _displayInformation;

        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += (s, e) => RefreshDisplayInformation();
            this.SizeChanged += (s, e) => RefreshDisplayInformation();

            this._displayInformation = Display.DisplayInformation.GetForCurrentView();

            Display.DisplayInformation.DisplayContentsInvalidated += (s, e) => RefreshDisplayInformation();
            this._displayInformation.ColorProfileChanged += (s, e) => RefreshDisplayInformation();
            this._displayInformation.DpiChanged += (s, e) => RefreshDisplayInformation();
            this._displayInformation.OrientationChanged += (s, e) => RefreshDisplayInformation();
            this._displayInformation.StereoEnabledChanged += (s, e) => RefreshDisplayInformation();
        }

        private void RefreshDisplayInformation()
        {
            Rect visibleBounds = ApplicationView.GetForCurrentView().VisibleBounds;

            this.windowPhysicalSizeX.Text= ((int)(this.ActualWidth * _displayInformation.RawPixelsPerViewPixel + 0.5)).ToString();
            this.windowPhysicalSizeY.Text = ((int)(this.ActualHeight* _displayInformation.RawPixelsPerViewPixel + 0.5)).ToString();

            this.WindowSizeX.Text = this.ActualWidth.ToString();
            this.WindowSizeY.Text = this.ActualHeight.ToString();

            autoRotationPreferences.Text = Display.DisplayInformation.AutoRotationPreferences.ToString();
            currentOrientation.Text = _displayInformation.CurrentOrientation.ToString();
            nativeOrientation.Text = _displayInformation.NativeOrientation.ToString();
            logicalDpi.Text = _displayInformation.LogicalDpi.ToString();
            rawDpiX.Text = _displayInformation.RawDpiX.ToString();
            rawDpiY.Text = _displayInformation.RawDpiY.ToString();
            rawPixelsPerViewPixel.Text = _displayInformation.RawPixelsPerViewPixel.ToString();
            resolutionScale.Text = _displayInformation.ResolutionScale.ToString();
            stereoEnabled.Text = _displayInformation.StereoEnabled.ToString();
        }
    }
}
