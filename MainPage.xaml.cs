using Windows.UI.Xaml.Controls;
using Windows.Devices.Input.Preview;
using System.Drawing;
using System.Text;
using Microsoft.Toolkit.Uwp.Input.GazeInteraction.GazeHidParsers;
using Windows.Graphics.Display;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace GazeAndBodyTrack
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class MainPage : Page
    {
        ScreenDetails _screenDetails;
        EyeTracker _tracker = new EyeTracker();

        public MainPage()
        {
            this.InitializeComponent();

            _screenDetails = new ScreenDetails(this);
            _tracker.GazeMoved += Tracker_GazeMoved;
            _tracker.GazeExited += Tracker_GazeExited;
            _tracker.Blink += _tracker_Blink;
        }

        private void _tracker_Blink(BlinkType blinkType)
        {
            txtStatus.Text += blinkType.ToString() + ";"; 
        }

        private void Tracker_GazeExited()
        {
            //txtStatus.Text = "exit" + _tracker.LeftEyePosition.HasValue.ToString();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e) { }

        private void Tracker_GazeMoved()
        {
            //imgFatBird.Visibility = (_tracker.GazePosition.HasValue) ? Visibility.Visible : Visibility.Collapsed;
            Canvas.SetLeft(imgFatBird, _tracker.GazePosition.X);
            Canvas.SetTop(imgFatBird, _tracker.GazePosition.Y);

            //txtStatus.Text = _tracker.HeadPosition.Z + " , " + _tracker.HeadRotatePosition.Z;

            if (_tracker.LeftEyePosition.Z > 300000 && _tracker.LeftEyePosition.Z < 900000)
            {
                LeftEyePositionEllipse.Visibility = Visibility.Visible;

                Canvas.SetLeft(LeftEyePositionEllipse, _tracker.LeftEyePosition.X * _screenDetails.ScreenWidthMicrometersScaleFactor);
                Canvas.SetTop(LeftEyePositionEllipse, _tracker.LeftEyePosition.Y * _screenDetails.ScreenHeightMicrometersScaleFactor);

                decimal scaleFactor = (decimal)_tracker.LeftEyePosition.Z / (decimal)600000;
                LeftEyePositionEllipse.Width = (double)((_tracker.LeftEyePosition.Z / 3000) * scaleFactor);
                LeftEyePositionEllipse.Height = (double)((_tracker.LeftEyePosition.Z / 3000) * scaleFactor);
            }
            else
            {
                LeftEyePositionEllipse.Visibility = Visibility.Collapsed;
            }

            if (_tracker.RightEyePosition.Z > 300000 && _tracker.RightEyePosition.Z < 900000)
            {
                RightEyePositionEllipse.Visibility = Visibility.Visible;

                Canvas.SetLeft(RightEyePositionEllipse, _tracker.RightEyePosition.X * _screenDetails.ScreenWidthMicrometersScaleFactor);
                Canvas.SetTop(RightEyePositionEllipse, _tracker.RightEyePosition.Y * _screenDetails.ScreenHeightMicrometersScaleFactor);

                decimal scaleFactor2 = (decimal)_tracker.RightEyePosition.Z / (decimal)600000;
                RightEyePositionEllipse.Width = (double)((_tracker.RightEyePosition.Z / 3000) * scaleFactor2);
                RightEyePositionEllipse.Height = (double)((_tracker.RightEyePosition.Z / 3000) * scaleFactor2);
            }
            else
            {
                RightEyePositionEllipse.Visibility = Visibility.Collapsed;
            }
        }
    }
}
