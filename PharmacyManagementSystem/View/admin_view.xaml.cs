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
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Microsoft.Win32;
using PharmacyManagementSystem.ViewModels;
using System.Drawing;


namespace PharmacyManagementSystem.View
{
    /// <summary>
    /// Interaction logic for admin_view.xaml
    /// </summary>
    
    
    public partial class admin_view : UserControl
    {
        Database_Connect obj = new Database_Connect();
       


        public admin_view()
        {
            InitializeComponent();
            dtgridprofile.ItemsSource = (obj.view_data("Select UserName,UserPrevilage, EmployeeName, NICNo, EmpAddress, EmpContactNo from UserList")).DefaultView;
            DataTable dt = new DataTable();
            dt = obj.view_data("Select Count(*) from UserList");
            txtblockTProfiles.Text = dt.Rows[0][0].ToString();
            DataTable loginhistory = new DataTable();
            loginhistory = obj.view_data("Select UserName, UserPrevilage from LoginHistory where HistoryID=(select max(HistoryID) from LoginHistory)");
            txtblockuser.Text = loginhistory.Rows[0][0].ToString();
            txtblocktype.Text = loginhistory.Rows[0][1].ToString();

            DataSet ds = obj.view_image("Select img from tblpicture where id='" + txtblockuser.Text + "'");
            DataTable img = ds.Tables[0];
           foreach (DataRow row in img.Rows)
            { byte[] blob = (byte[])row[0];
            MemoryStream stream = new MemoryStream();
            stream.Write(blob, 0, blob.Length);
            stream.Position = 0;

            System.Drawing.Image PImg = System.Drawing.Image.FromStream(stream);
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();

            MemoryStream ms = new MemoryStream();
            PImg.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            ms.Seek(0, SeekOrigin.Begin);
            bi.StreamSource = ms;
            bi.EndInit();
            profileImage.Source = bi;

            }
               
        }

        
       

    }
}
