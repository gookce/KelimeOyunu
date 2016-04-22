using KelimeOyunu.Database;
using KelimeOyunu.Menu;
using KelimeOyunu.Son;
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

namespace KelimeOyunu.Levels
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Level5 : Page
    {
        public static MobileServiceClient MobileService = new MobileServiceClient("https://turkcekelimeler.azure-mobile.net/", "RTjmGpCuviaAvIQOOZXVbnEuCRoziS61");
        public static IMobileServiceTable<TurkishWords> tableClient = MobileService.GetTable<TurkishWords>();
        public static ObservableCollection<string> kelimeler = new ObservableCollection<string>();
        public static ObservableCollection<string> oldwords = new ObservableCollection<string>();
        public static Random defword = new Random();
        public static int bonus = 0;
        public static int wordpoint = 0;
        public static string[] defaultword = { "kalp", "rastgele", "yol", "yıldız", "akıl", "asker", "köpek", "kelebek", "su", "bal", "arı", "aşk", "şart", "şemsiye", "kart", "tango", "pantolon", "soğan", "otobüs", "toka" };
        public static DispatcherTimer timer = new DispatcherTimer();
        public static int gametime = 60;

        public Level5()
        {
            this.InitializeComponent();
            Loaded += Level5_Loaded;
            wordpoint = 0;
        }

        private void Level5_Loaded(object sender, RoutedEventArgs e)
        {
            tableClient = MobileService.GetTable<TurkishWords>();
            int secm = defword.Next(0, 19);
            txtdefault.Text = defaultword[secm].ToUpper();
            gametime = AppDataManager.GetInt("Time", Settings.time);
            txttime.Text = gametime.ToString();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        public void timer_Tick(object sender, object e)
        {
            txttime.Text = (gametime--).ToString();
            if (txttime.Text == "0")
            {
                Control();
                timer.Stop();
            }
        }

        public static bool StartWith(string oldword, string newword)
        {
            char[] x = oldword.ToLower().ToCharArray();
            char son = x[oldword.Length - 1];
            char[] y = newword.ToLower().ToCharArray();
            char bas = y[0];
            if (son == bas)
                return true;
            else
                return false;
        }

        private async void btnok_Click(object sender, RoutedEventArgs e)
        {
            string getword = txtnew.Text;
            int wordleng = getword.Length;
            oldwords.Add(txtdefault.Text);
            await LoadData(getword);
            if (txtnew.Text != "")
            {
                if (StartWith(txtdefault.Text, getword))
                {
                    if (kelimeler.Count != 0 && wordleng >= 6)
                    {
                        if (!HasArray(getword))
                        {
                            wordpoint = wordpoint + 1;
                            bonus = MakeBonus(wordleng);
                            txtpoint.Text = (wordpoint + bonus).ToString();
                            txtdefault.Text = getword;
                            txtnew.Text = string.Empty;
                            gametime = gametime + 3;
                        }
                        else
                        {
                            wordpoint--;
                            txtpoint.Text = (wordpoint).ToString();
                            txtdefault.Text = getword;
                            txtnew.Text = string.Empty;
                        }
                    }
                    else
                    {
                        wordpoint--;
                        txtpoint.Text = (wordpoint).ToString();
                        txtdefault.Text = getword;
                        txtnew.Text = string.Empty;
                    }
                }
                else
                {
                    int secm = defword.Next(0, 19);
                    txtdefault.Text = defaultword[secm].ToUpper();
                    txtnew.Text = string.Empty;
                }
            }
            else
            {
                int secm = defword.Next(0, 19);
                txtdefault.Text = defaultword[secm].ToUpper();
                txtnew.Text = string.Empty;
            }
        }

        public async Task LoadData(string getword)
        {
            kelimeler.Clear();
            var quersonuc = await tableClient.Where(x => x.abaci == getword).ToEnumerableAsync();
            if (quersonuc != null)
            {
                foreach (var item in quersonuc)
                {
                    kelimeler.Add(item.ToString());
                }
            }
        }

        public static bool HasArray(string kelime)
        {
            bool result = false;
            if (oldwords != null)
            {
                for (int i = 0; i < oldwords.Count; i++)
                {
                    if (oldwords[i] == kelime)
                        result = true;
                    else
                        result = false;
                }
            }
            return result;
        }

        public int MakeBonus(int wordlength)
        {
            if (wordlength <= 5 || wordlength > 0)
                bonus = 1;
            else if (wordlength > 5 || wordlength < 10)
            {
                bonus = wordlength - 4;
            }
            else
            {
                bonus = wordlength;
            }
            return bonus;
        }

        public void Control()
        {
            if (Settings.time == 60)
            {
                if (wordpoint >= 3)
                {
                    Frame.Navigate(typeof(Level2));
                }
                else
                {
                    Frame.Navigate(typeof(Exit));
                }
            }
            else if (Settings.time == 120)
            {
                if (wordpoint >= 13)
                {
                    Frame.Navigate(typeof(Level2));
                }
                else
                {
                    Frame.Navigate(typeof(Exit));
                }
            }
            else if (Settings.time == 180)
            {
                if (wordpoint >= 23)
                {
                    Frame.Navigate(typeof(Level2));
                }
                else
                {
                    Frame.Navigate(typeof(Exit));
                }
            }
            else if (Settings.time == 240)
            {
                if (wordpoint >= 33)
                {
                    Frame.Navigate(typeof(Level2));
                }
                else
                {
                    Frame.Navigate(typeof(Exit));
                }
            }
            else if (Settings.time == 300)
            {
                if (wordpoint >= 43)
                {
                    Frame.Navigate(typeof(Level2));
                }
                else
                {
                    Frame.Navigate(typeof(Exit));
                }
            }
        }

        private void appbtnhome_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void txtnew_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtdefault_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
