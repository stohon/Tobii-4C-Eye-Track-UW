using Microsoft.Toolkit.Uwp.Input.GazeInteraction.GazeHidParsers;
using Windows.Devices.Input.Preview;

namespace GaveAndBodyTrack
{
    public delegate void EyeTracker_GazeMoved();

    public class EyeTracker
    {
        public event EyeTracker_GazeMoved GazeMoved;

        private GazeInputSourcePreview _gazeInputSourcePreview;
        private GazeHidPositionsParser _gazeHidPositionsParser;

        private GazePosition _gazePosition = new GazePosition();
        private EyeHeadPosition _leftEyePosition = new EyeHeadPosition();
        private EyeHeadPosition _rightEyePosition = new EyeHeadPosition();
        private EyeHeadPosition _headPosition = new EyeHeadPosition();
        private EyeHeadPosition _headRotatePosition = new EyeHeadPosition();

        public GazePosition GazePosition { get { return _gazePosition; } }
        public EyeHeadPosition LeftEyePosition { get { return _leftEyePosition; } }
        public EyeHeadPosition RightEyePosition { get { return _rightEyePosition; } }
        public EyeHeadPosition HeadPosition { get { return _headPosition; } }
        public EyeHeadPosition HeadRotatePosition { get { return _headRotatePosition; } }

        public EyeTracker()
        {
            _gazeInputSourcePreview = GazeInputSourcePreview.GetForCurrentView();
            _gazeInputSourcePreview.GazeMoved += GazeInputSourcePreview_GazeMoved;
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

            GazeMoved?.Invoke();
        }
    }
}
