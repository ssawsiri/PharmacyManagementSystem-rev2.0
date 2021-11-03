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
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace PharmacyManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            media.Source = new Uri(Environment.CurrentDirectory + @"/7RwF.gif");
            loading();
        }

        DispatcherTimer timer = new DispatcherTimer();

        public void timer_ticker(object sender, EventArgs e)
        {
            login_window obj = new login_window();
            
            if (gridloading.Opacity > 0.0)
                gridloading.Opacity -= 0.0025;
            else
            {
                timer.Stop();
                Hide();
                obj.Show();
                this.Close();
            }
        }
        
        public void loading()
        {
            timer.Tick += timer_ticker;
        }

        private void media_MediaEnded(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }
    }
}
