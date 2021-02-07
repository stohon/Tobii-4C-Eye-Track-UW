using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Display;
using System.Drawing;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace GaveAndBodyTrack
{
    public class ScreenDetails
    {
        Page _currentPage;
        private DisplayInformation _displayInformation;
        Size _screenSize;
        float _screenSizeInchesWidth;
        float _screenSizeInchesHeight;
        float _screenSizeMicrometersWidth;
        float _screenSizeMicrometersHeight;

        public ScreenDetails(Page currentPage)
        {
            _currentPage = currentPage;
            _displayInformation = DisplayInformation.GetForCurrentView();
            _screenSize = new Size((int)_displayInformation.ScreenWidthInRawPixels,
                                  (int)_displayInformation.ScreenHeightInRawPixels);

            _screenSizeInchesWidth = _screenSize.Width / _displayInformation.RawDpiX;
            _screenSizeInchesHeight = _screenSize.Height / _displayInformation.RawDpiY;

            _screenSizeMicrometersWidth = _screenSizeInchesWidth * 25400;
            _screenSizeMicrometersHeight = _screenSizeInchesHeight * 25400;
        }

        public Size ScreenSize { get { return _screenSize;  } } 
        public float ScreenWidthInches { get { return _screenSizeInchesWidth; } }
        public float ScreenHeightInches { get { return _screenSizeInchesHeight; } }
        public float ScreenWidthMicrometers { get { return _screenSizeMicrometersWidth; } }
        public float ScreenHeightMicrometers { get { return _screenSizeMicrometersHeight; } }
        public float ScreenWidthMicrometersScaleFactor { get { return (float)_currentPage.ActualWidth / _screenSizeMicrometersWidth; } }
        public float ScreenHeightMicrometersScaleFactor { get { return (float)_currentPage.ActualHeight / _screenSizeMicrometersHeight; } }
    }
}
