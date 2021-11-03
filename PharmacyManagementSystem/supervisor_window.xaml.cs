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
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Win32;
using PharmacyManagementSystem.ViewModels;

namespace PharmacyManagementSystem
{
    /// <summary>
    /// Interaction logic for supervisor_window.xaml
    /// </summary>
    public partial class supervisor_window : Window
    {
        bool MenuClosed = true;
        

        public supervisor_window()
        {
            InitializeComponent();
            Storyboard opencontest = (Storyboard)this.FindResource("OpenContest");
            opencontest.Begin();
            DataContext = new dashboard_view_model();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            if (MenuClosed)
            {
                Storyboard OpenMenu = (Storyboard)btnMenu.FindResource("OpenMenu");
                OpenMenu.Begin();
            }
            else
            {
                Storyboard CloseMenu = (Storyboard)btnMenu.FindResource("CloseMenu");
                CloseMenu.Begin();
            }

            MenuClosed = !MenuClosed;
        }

        private void btnDashBoard_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new dashboard_view_model();
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSales_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExpire_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnStckLow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCompany_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPurchasing_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnMaximized_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void keyChangePwd_Click(object sender, RoutedEventArgs e)
        {
            change_password chg = new change_password();

            chg.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void keyLogOut_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxResult.Yes == MessageBox.Show("Do You Want to LogOut ?", "Information", MessageBoxButton.YesNo, MessageBoxImage.Information))
            {
                login_window logwin = new login_window();
                this.Close();
                logwin.Show();
            }
        }
    }
}
