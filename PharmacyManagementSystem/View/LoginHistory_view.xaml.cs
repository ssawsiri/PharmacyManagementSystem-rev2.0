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
using System.Data;

namespace PharmacyManagementSystem.View
{
    /// <summary>
    /// Interaction logic for LoginHistory_view.xaml
    /// </summary>
    public partial class LoginHistory_view : UserControl
    {
        Database_Connect obj = new Database_Connect();
        public LoginHistory_view()
        {
            InitializeComponent();
            dtgridLogin.ItemsSource = (obj.view_data("Select * from LoginHistory")).DefaultView;
            DataTable dt = new DataTable();
            dt = obj.view_data("Select Count(*) from LoginHistory");
            txtblockTLogins.Text = dt.Rows[0][0].ToString();

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            dtgridLogin.ItemsSource = (obj.view_data("Select * from LoginHistory where LoginDate >='" + dtpStartDate.SelectedDate + "' and LoginDate <='" + dtbEndDate.SelectedDate + "'")).DefaultView;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            dtgridLogin.ItemsSource = (obj.view_data("Select * from LoginHistory")).DefaultView;
            dtbEndDate.Text = "";
            dtpStartDate.Text = "";
        }
    }
}
