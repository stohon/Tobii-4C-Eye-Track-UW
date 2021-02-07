using Microsoft.Toolkit.Uwp.Input.GazeInteraction.GazeHidParsers;
using Windows.Devices.Input.Preview;

namespace GazeAndBodyTrack
{
    public delegate void EyeTracker_GazeMoved();
    public delegate void EyeTracker_Blink(BlinkType blinkType);

    public class EyeTracker
    {
        public event EyeTracker_GazeMoved GazeEntered;
        public event EyeTracker_GazeMoved GazeMoved;
        public event EyeTracker_GazeMoved GazeExited;
        public event EyeTracker_Blink Blink;

        private GazeInputSourcePreview _gazeInputSourcePreview;
        private GazeHidPositionsParser _gazeHidPositionsParser;

        private GazePosition _gazePosition = new GazePosition();
        private EyePosition _leftEyePosition = new EyePosition();
        private EyePosition _rightEyePosition = new EyePosition();
        private HeadPosition _headPosition = new HeadPosition();
        private HeadPosition _headRotatePosition = new HeadPosition();

        public GazePosition GazePosition { get { return _gazePosition; } }
        public EyePosition LeftEyePosition { get { return _leftEyePosition; } }
        public EyePosition RightEyePosition { get { return _rightEyePosition; } }
        public HeadPosition HeadPosition { get { return _headPosition; } }
        public HeadPosition HeadRotatePosition { get { return _headRotatePosition; } }

        public EyeTracker()
        {
            _gazeInputSourcePreview = GazeInputSourcePreview.GetForCurrentView();
            _gazeInputSourcePreview.GazeEntered += GazeInputSourcePreview_GazeEntered;
            _gazeInputSourcePreview.GazeMoved += GazeInputSourcePreview_GazeMoved;
            _gazeInputSourcePreview.GazeExited += GazeInputSourcePreview_GazeExited;
        }

        private void GazeInputSourcePreview_GazeEntered(GazeInputSourcePreview sender, GazeEnteredPreviewEventArgs args)
        {
            GazeEntered?.Invoke();
        }

        private void GazeInputSourcePreview_GazeMoved(GazeInputSourcePreview sender, GazeMovedPreviewEventArgs args)
        {
            _gazePosition.SetPosition(args.CurrentPoint.EyeGazePosition);

            if (_gazeHidPositionsParser == null) _gazeHidPositionsParser = new GazeHidPositionsParser(args.CurrentPoint.SourceDevice);
            var positions = _gazeHidPositionsParser.GetGazeHidPositions(args.CurrentPoint.HidInputReport);
            
            _leftEyePosition.SetPosition(positions.LeftEyePosition);
            _rightEyePosition.SetPosition(positions.RightEyePosition);
            _headPosition.SetPosition(positions.HeadPosition);
            _headRotatePosition.SetPosition(positions.HeadRotation);

            if (_leftEyePosition.Z == 0 && _rightEyePosition.Z == 0)
            {
                Blink?.Invoke(BlinkType.Both);
            }
            else
            {
                if (_leftEyePosition.Z == 0 ) Blink?.Invoke(BlinkType.Left);
                if (_rightEyePosition.Z == 0) Blink?.Invoke(BlinkType.Right);
            }

            GazeMoved?.Invoke();
        }

        private void GazeInputSourcePreview_GazeExited(GazeInputSourcePreview sender, GazeExitedPreviewEventArgs args)
        {
            _leftEyePosition.Clear();
            _rightEyePosition.Clear();
            _headPosition.Clear();
            _headRotatePosition.Clear();
            GazeExited?.Invoke();
        }
    }
}
