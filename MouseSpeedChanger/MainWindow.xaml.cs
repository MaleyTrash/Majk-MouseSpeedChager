using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace MouseSpeedChanger
{

    public partial class MainWindow : Window
    {
        public const UInt32 SPI_SETMOUSESPEED = 0x0071;
        [DllImport("User32.dll")]
        static extern Boolean SystemParametersInfo(
            UInt32 uiAction,
            UInt32 uiParam,
            UInt32 pvParam,
            UInt32 fWinIni);
        public MainWindow()
        {
            InitializeComponent();
            
        }
        public static void SetMouseSpeed(int intSpeed)
        {
            uint ptr = Convert.ToUInt32(intSpeed);
            SystemParametersInfo(SPI_SETMOUSESPEED, 0, ptr, 0);
        }
        private void SlowMouseSpeed(object sender, RoutedEventArgs e)
        {
            SetMouseSpeed(5);
        }

        private void DefaultMouseSpeed(object sender, RoutedEventArgs e)
        {
            SetMouseSpeed(1);
        }

        private void FastMouseSpeed(object sender, RoutedEventArgs e)
        {
            SetMouseSpeed(15);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SetMouseSpeed((int)SliderMouseSpeed.Value);
            SliderValueLabel.Content = Math.Round(SliderMouseSpeed.Value).ToString();
        }
    }
}
