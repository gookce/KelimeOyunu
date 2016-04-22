using KelimeOyunu.Database;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace KelimeOyunu.Menu
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Settings : Page
    {
        public Settings()
        {
            this.InitializeComponent();
        }

        public static int time = 60; //default versiyon

        private void appbtnhome_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void chk1_Checked(object sender, RoutedEventArgs e)
        {
            time = 60;
            AppDataManager.SaveInt("Time", time);
        }

        private void chk2_Checked(object sender, RoutedEventArgs e)
        {
            time = 120;
            AppDataManager.SaveInt("Time", time);
        }

        private void chk3_Checked(object sender, RoutedEventArgs e)
        {
            time = 180;
            AppDataManager.SaveInt("Time", time);
        }

        private void chk4_Checked(object sender, RoutedEventArgs e)
        {
            time = 240;
            AppDataManager.SaveInt("Time", time);
        }

        private void chk5_Checked(object sender, RoutedEventArgs e)
        {
            time = 300;
            AppDataManager.SaveInt("Time", time);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game));
        }
    }
}
