using KelimeOyunu.Database;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class Bests : Page
    {
        public static MobileServiceClient MobileService = new MobileServiceClient("https://turkcekelimeler.azure-mobile.net/", "RTjmGpCuviaAvIQOOZXVbnEuCRoziS61");
        public static IMobileServiceTable<BestRecords> tabClient = MobileService.GetTable<BestRecords>();
        public static ObservableCollection<string> eniyiler = new ObservableCollection<string>();
        public static ObservableCollection<BestRecords> tamveri = new ObservableCollection<BestRecords>();
        public static ObservableCollection<BestRecords> veriler = new ObservableCollection<BestRecords>();
        public static int counter = 0;

        public Bests()
        {
            this.InitializeComponent();
            ComboboxItemAdd();
        }

        public async void Givedata()
        {
            if (cmbchoose.SelectedIndex == 0)
            {
                await ReadDataFromAzure(60);
            }
            else if (cmbchoose.SelectedIndex == 1)
            {
                await ReadDataFromAzure(120);
            }
            else if (cmbchoose.SelectedIndex == 2)
            {
                await ReadDataFromAzure(180);
            }
            else if (cmbchoose.SelectedIndex == 3)
            {
                await ReadDataFromAzure(240);
            }
            else if (cmbchoose.SelectedIndex == 4)
            {
                await ReadDataFromAzure(300);
            }
        }

        public void ComboboxItemAdd()
        {
            for (int i = 0; i < 5; i++)
            {
                cmbchoose.Items.Add((i + 1) + " Dakika");
            }
        }

        public void ReadList()
        {
            if (counter == 0)
            {

            }
            else if (counter <=3)
            {
                listData.ItemsSource = veriler;
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    tamveri.Add(veriler[i]);
                }
                listData.ItemsSource = tamveri;
            }
        }


        public async Task ReadDataFromAzure(int whichtime)
        {
            veriler.Clear();
            counter = 0;
            var sorgu = await tabClient.Where(x => x.recordtime == whichtime).OrderByDescending(x => x.recordvalue).ToEnumerableAsync();
            foreach (var item in sorgu)
            {
                veriler.Add(item);
                counter++;
            }
            ReadList();
        }

        public async void AddDataToAzure()
        {
            var max = new BestRecords()
            {
                recordvalue = Game.wordpoint,
                recordtime = AppDataManager.GetInt("Time", Settings.time),
                user = AppDataManager.GetString("Gamer", txtuser.Text)
            };

            await tabClient.InsertAsync(max);
            eniyiler.Add(max.ToString());
        }

        private void appbtnhome_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void btnok_Click(object sender, RoutedEventArgs e)
        {
            AppDataManager.SaveString("Gamer", txtuser.Text);
            AddDataToAzure();
            txtuser.Text = string.Empty;
        }

        private void cmbchoose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Givedata();
        }
    }
}
