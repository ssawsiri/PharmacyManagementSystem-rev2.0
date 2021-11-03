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
using System.Data;
using System.Text.RegularExpressions;

namespace PharmacyManagementSystem
{
    /// <summary>
    /// Interaction logic for change_password.xaml
    /// </summary>
    public partial class change_password : Window
    {
        Database_Connect obj = new Database_Connect();
       
        login_window logwin = new login_window();

        DataTable loginhistory = new DataTable();
        DataTable dt = new DataTable();

        public change_password()
        {
            InitializeComponent();
            
            loginhistory = obj.view_data("Select UserName from LoginHistory where HistoryID=(select max(HistoryID) from LoginHistory)");
            txtblockuser.Text = loginhistory.Rows[0][0].ToString();
            dt = obj.view_data("select UserPassword from UserList where UserName='" + txtblockuser.Text + "'");
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtOldPwd.Text))
                    txtblocError.Text = "* Password Cannot be Blank";
                else if (txtOldPwd.Text == dt.Rows[0][0].ToString())
                    txtblocError.Text = "* Incorrect Password Entered";
                else if (!Regex.IsMatch(txtNewPwd.Password, @"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$"))
                    txtblocError.Text = "Please see the password requirement";
                else if (txtNewPwd.Password != txtConfirmPwd.Password)
                    txtblocError.Text = "* Password Not Matched";
                else
                {
                    int i = obj.save_update_delete("Update UserList set UserPassword='" + txtConfirmPwd.Password + "' where UserName ='" + txtblockuser.Text + "'");
                    if (i == 1)
                        MessageBox.Show("Password Change Has Been Completed", "User Profile", MessageBoxButton.OK, MessageBoxImage.Information);

                    this.Close();
                    logwin.Show();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            logwin.Show();
        }
    }
}
