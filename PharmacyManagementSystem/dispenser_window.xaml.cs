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
    /// Interaction logic for dispenser_window.xaml
    /// </summary>
    public partial class dispenser_window : Window
    {
        public dispenser_window()
        {
            InitializeComponent();
        }

        private void grid2_MouseDown(object sender, MouseButtonEventArgs e)
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

        private void keyChangePwd_Click(object sender, RoutedEventArgs e)
        {
            change_password chg = new change_password();

            chg.Show();
            
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

        private void txtSearch_TextInput(object sender, TextCompositionEventArgs e)
        {

        }

       
        private void dgProductList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void txtTPNo_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void txtTPNo_TextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void txtPaid_TextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
