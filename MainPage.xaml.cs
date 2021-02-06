using Windows.UI.Xaml.Controls;
using Windows.Devices.Input.Preview;
using System.Text;
using Microsoft.Toolkit.Uwp.Input.GazeInteraction.GazeHidParsers;

namespace GaveAndBodyTrack
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class MainPage : Page
    {
        EyeTracker _tracker = new EyeTracker();

        public MainPage()
        {
            this.InitializeComponent();

            _tracker.GazeMoved += Tracker_GazeMoved;
        }

        private void Tracker_GazeMoved()
        {
            txtStatus.Text = _tracker.GazePosition.X + " , " + _tracker.GazePosition.Y;
        }
    }
}
