using Microsoft.Toolkit.Uwp.Input.GazeInteraction.GazeHidParsers;
using Windows.Devices.Input.Preview;

namespace GazeAndBodyTrack
{
    public class HeadPosition
    {
        public HeadPosition()
        {
            this.Clear();
        }

        public void Clear()
        {
            this.HasValue = false;
            this.X = 0;
            this.Y = 0;
            this.Z = 0;
        }

        public void SetPosition(GazeHidPosition hidPosition)
        {
            this.HasValue = (hidPosition != null);
            if (this.HasValue)
            {
                this.X = hidPosition.X;
                this.Y = hidPosition.Y;
                this.Z = hidPosition.Z;
            }
            else
            {
                this.X = 0;
                this.Y = 0;
                this.Z = 0;
            }
        }

        public bool HasValue { get; set; }
        public long X { get; set; }
        public long Y { get; set; }
        public long Z { get; set; }
    }
}
