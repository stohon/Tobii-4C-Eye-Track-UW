using Windows.UI.Xaml.Controls;
using Windows.Devices.Input.Preview;
using System.Drawing;
using System.Text;
using Microsoft.Toolkit.Uwp.Input.GazeInteraction.GazeHidParsers;
using Windows.Graphics.Display;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using System;
using System.Windows;
using Windows.UI.Xaml.Media.Imaging;

namespace GazeAndBodyTrack
{
    public sealed partial class MainPage : Page
    {
        ScreenDetails _screenDetails;
        EyeTracker _tracker = new EyeTracker();

        public MainPage()
        {
            this.InitializeComponent();
            _screenDetails = new ScreenDetails(this);
            _tracker.GazeMoved += Tracker_GazeMoved;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e) {
            BitmapImage bitmap = new BitmapImage(new Uri(@"D:\Code\Pictures\bot.jpg", UriKind.Absolute));
        }

        private void Tracker_GazeMoved()
        {
            Canvas.SetLeft(TopGazePointer, _tracker.GazePosition.X);
            Canvas.SetTop(TopGazePointer, 0);
            Canvas.SetLeft(LeftGazePointer, 0);
            Canvas.SetTop(LeftGazePointer, _tracker.GazePosition.Y);
            PictureGrid.Width = _screenDetails.ScreenSize.Width - 100;
        }

        private void Canvas_LayoutUpdated(object sender, object e)
        {
            
        }
    }
}


