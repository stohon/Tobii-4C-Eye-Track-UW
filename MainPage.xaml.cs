using Windows.UI.Xaml.Controls;
using Windows.Devices.Input.Preview;
using System.Drawing;
using System.Text;
using Microsoft.Toolkit.Uwp.Input.GazeInteraction.GazeHidParsers;
using Windows.Graphics.Display;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace GaveAndBodyTrack
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class MainPage : Page
    {
        EyeTracker _tracker = new EyeTracker();

        private DisplayInformation displayInformation;
        Size screenSize;
        float screenSizeInchesWidth;
        float screenSizeInchesHeight;

        float screenSizeMicrometersWidth;
        float screenSizeMicrometersHeight;

        public MainPage()
        {
            this.InitializeComponent();

            displayInformation = DisplayInformation.GetForCurrentView();
            screenSize = new Size((int)displayInformation.ScreenWidthInRawPixels,
                                                   (int)displayInformation.ScreenHeightInRawPixels);
            screenSizeInchesWidth = screenSize.Width / displayInformation.RawDpiX;
            screenSizeInchesHeight = screenSize.Height / displayInformation.RawDpiY;

            screenSizeMicrometersWidth = screenSizeInchesWidth * 25400;
            screenSizeMicrometersHeight = screenSizeInchesHeight * 25400;

            _tracker.GazeMoved += Tracker_GazeMoved;
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //var conversionFactorX = (displayInformation.RawDpiX / displayInformation.RawPixelsPerViewPixel) / 25.4;
            //var conversionFactorY = (displayInformation.RawDpiY / displayInformation.RawPixelsPerViewPixel) / 25.4;
        }

        private void Tracker_GazeMoved()
        {
            txtStatus.Text = _tracker.GazePosition.X + " , " + _tracker.GazePosition.Y;

            Canvas.SetLeft(imgFatBird, _tracker.GazePosition.X);
            Canvas.SetTop(imgFatBird, _tracker.GazePosition.Y);

            //var newX = MapRange(0, screenSizeMicrometersWidth, 0, ActualWidth, _tracker.GazePosition.X);
            //var newY = MapRange(0, screenSizeMicrometersHeight, 0, ActualHeight, _tracker.GazePosition.Y);

            //Canvas.SetLeft(GazePositionEllipse, newX);
            //Canvas.SetTop(GazePositionEllipse, newY);

        }

        private static double MapRange(double oldStart, double oldEnd, double newStart, double newEnd, double valueToMap)
        {
            double scalingFactor = (newEnd - newStart) / (oldEnd - oldStart);
            return newStart + ((valueToMap - oldStart) * scalingFactor);
        }
    }
}
