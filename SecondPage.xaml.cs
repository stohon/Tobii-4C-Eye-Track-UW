using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GazeAndBodyTrack
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SecondPage : Page
    {
        public SecondPage()
        {
            this.InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            
            btnImage.Source  = new BitmapImage(new Uri("file:///D:/Code/Pictures/bot.png", UriKind.Absolute));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string PicLib = @"D:\Code\";
            string env = Environment.CurrentDirectory;
            var path = Path.Combine(env, "Assets", txtFileName.Text);
            Uri u = new Uri(path, UriKind.Absolute);
            btnImage.Source = new BitmapImage(u);
            //btnBot.Content = path;
            //btnBot.Content = new Image
            //{
            //    Source = new BitmapImage(new Uri(@"file:\\D:\Code\Repos\stohon\Tobii-4C-Eye-Track-UW\Assets\bot.jpg", UriKind.Absolute)),
            //    VerticalAlignment = VerticalAlignment.Center
            //};
        }
    }
}
