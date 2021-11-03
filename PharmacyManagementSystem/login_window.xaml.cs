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
using System.Data.SqlClient;
using System.Data;


namespace PharmacyManagementSystem
{
    
    /// <summary>
    /// Interaction logic for login_window.xaml
    /// </summary>
    public partial class login_window : Window

    {
        logincheckclass obj = new logincheckclass();
        
        
        public login_window()
        {
            InitializeComponent();
        }

             
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUser.Text))
                    MessageBox.Show("User Name Cannot be Blanked", "Error", MessageBoxButton.OK);
                else if (string.IsNullOrEmpty(pwdUser.Password))
                    MessageBox.Show("Password Cannot be Blanked", "Error", MessageBoxButton.OK);
                else
                    {
                    obj.login_check(txtUser.Text, pwdUser.Password);
                    this.Hide();   
                    }
            }
            catch (Exception)
            {
                MessageBox.Show("Please check again your entries", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBoxResult.Yes == MessageBox.Show("Are You Sure Want to Exit ?", "Information", MessageBoxButton.YesNo, MessageBoxImage.Information))
            Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
