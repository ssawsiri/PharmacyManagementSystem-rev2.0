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
    /// Interaction logic for admin_window.xaml
    /// </summary>
    public partial class admin_window : Window
    {
        bool MenuClosed = true;
        Database_Connect obj = new Database_Connect();
        

        public admin_window()
        {
            InitializeComponent();
            Storyboard opencontest = (Storyboard)this.FindResource("OpenContest");
            opencontest.Begin();
            DataContext = new admin_view_model();
            

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

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
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

        private void keyLogOut_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxResult.Yes == MessageBox.Show("Do You Want to LogOut ?", "Information", MessageBoxButton.YesNo, MessageBoxImage.Information))
            {
                login_window logwin = new login_window();
                this.Close();
                logwin.Show();
            }
          
        }

        private void btnadminProfile_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new admin_view_model();
            Storyboard opencontest = (Storyboard)btnAdminProfile.FindResource("OpenContest");
            opencontest.Begin();
        }

        private void btnEventList_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLoginHistory_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new LoginHistory_view_models();
            Storyboard opencontest = (Storyboard)btnLoginHistory.FindResource("OpenContest");
            opencontest.Begin();
        }

        private void keyChangePwd_Click(object sender, RoutedEventArgs e)
        {
            change_password chg = new change_password();

            chg.Show();
            this.Close();

        }

        private void btnCreateProfile_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new create_profile_model();
            Storyboard opencontest = (Storyboard)btnCreateProfile.FindResource("OpenContest");
            opencontest.Begin();
        }

        private void btnEditProfile_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new edit_profile_model();
            Storyboard opencontest = (Storyboard)btnCreateProfile.FindResource("OpenContest");
            opencontest.Begin();
        }
    }
}
