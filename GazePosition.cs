using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaveAndBodyTrack
{
    public class GazePosition
    {
        public GazePosition ()
        {
            this.HasValue = false;
            this.X = 0;
            this.Y = 0;
        }

        public void SetPosition(Windows.Foundation.Point? gazePosition)
        {
            this.HasValue = gazePosition.HasValue;
            if (this.HasValue)
            {
                this.X = gazePosition.Value.X;
                this.Y = gazePosition.Value.Y;
            }
            else
            {
                this.X = 0;
                this.Y = 0;
            }
        }

        public bool HasValue { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }
}
