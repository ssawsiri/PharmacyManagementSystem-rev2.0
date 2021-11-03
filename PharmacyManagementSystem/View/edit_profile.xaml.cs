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
using System.IO;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace PharmacyManagementSystem.View
{
    /// <summary>
    /// Interaction logic for edit_profile.xaml
    /// </summary>
    public partial class edit_profile : UserControl
    {
        Database_Connect obj = new Database_Connect();
        string strName, imageName;

        public edit_profile()
        {
            InitializeComponent();
            DataTable dt = obj.editProfile("Select UserName from UserList");
            cmbUser.Items.Clear();

            foreach (DataRow dr in dt.Rows)
                cmbUser.Items.Add(dr["UserName"].ToString());
            cmbUser.SelectedIndex = 0;
            DataTable loginhistory = obj.view_data("Select UserName, UserPrevilage from LoginHistory where HistoryID=(select max(HistoryID) from LoginHistory)");
            txtLoggedUser.Text = loginhistory.Rows[0][0].ToString();
            txtLoggedPrevi.Text = loginhistory.Rows[0][1].ToString();

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbUser.SelectedItem.ToString() == "")
                {
                        MessageBox.Show("Please Select an User Profile", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                   
                else
                {
                    if (cmbUser.SelectedItem.ToString() == txtLoggedUser.Text)
                    MessageBox.Show("Delete Function Restricted for Logged User", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                     else if (MessageBoxResult.Yes == MessageBox.Show("Do you want to Delete Selected User", "Information", MessageBoxButton.YesNo, MessageBoxImage.Information))
                     {
                            int i = obj.save_update_delete("delete from UserList where UserName='" + cmbUser.SelectedItem.ToString() + "'");

                            obj.delete_image(cmbUser.SelectedItem.ToString());
                            if (i == 1)
                            {
                                     MessageBox.Show("User Successfully Deleted", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                                     DataTable dt = obj.editProfile("Select UserName from UserList");
                                    cmbUser.Items.Clear();

                                    foreach (DataRow dr in dt.Rows)
                                    cmbUser.Items.Add(dr["UserName"].ToString());

                            }
                            else
                                MessageBox.Show("Error Occured Please Check Again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                     }
               
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            

        }

       

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
                fldlg.ShowDialog();
                {
                    strName = fldlg.SafeFileName;
                    imageName = fldlg.FileName;
                    ImageSourceConverter isc = new ImageSourceConverter();
                    imgProfile.SetValue(Image.SourceProperty, isc.ConvertFromString(imageName));
                }
                fldlg = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Please Browse Valid Picture", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFullName.Text))
                    txtblockError.Text = "* Full Name cannot be blanked";
                else if (!Regex.IsMatch(txtNIC.Text, @"^[0-9]{9}[vVxX]$") && !Regex.IsMatch(txtNIC.Text, @"^[0-9]{7}[0][0-9]{4}$"))
                    txtblockError.Text = "Invalid NIC No Entered";
                else if (string.IsNullOrEmpty(txtAddress.Text))
                    txtblockError.Text = "* Address cannot be blanked";
                else if (!Regex.IsMatch(txtContact.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
                    txtblockError.Text = "Telephone No not Valid";
                else if (string.IsNullOrEmpty(cmbGender.Text))
                    txtblockError.Text = "* Gender cannot be blanked";
                else if (string.IsNullOrEmpty(dtpDOB.Text))
                    txtblockError.Text = "* Date of Birth Cannot be Blanked";
                else if (imgProfile.Source == null)
                    txtblockError.Text = "* Profile Image Cannot be blanked";
                else

                {
                    txtblockError.Text = "";
                    string gender;

                    if (cmbGender.SelectedIndex == 0)
                        gender = "Male";
                    else
                        gender = "Female";


                    FileStream fs = new FileStream(imageName, FileMode.Open, FileAccess.Read);

                    //Initialize a byte array with size of stream
                    byte[] imgByteArr = new byte[fs.Length];

                    //Read data from the file stream and put into the byte array
                    fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));

                    //Close a file stream
                    fs.Close();

                    string username = cmbUser.SelectedItem.ToString();


                    int i = obj.save_update_delete("Update UserList set EmployeeName='" + txtFullName.Text + "', NICNo='" + txtNIC.Text + "', EmpAddress='" + txtAddress.Text + "', EmpContactNo='" + txtContact.Text + "', Gender='" + gender + "', BOD='" + dtpDOB.SelectedDate + "' where UserName='"+username+"'");
                    obj.update_image(username, imgByteArr);

                    if (i == 1)
                    {
                        MessageBox.Show("User Successfully Saved", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                        MessageBox.Show("Error Occured Please Check Again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

    

        private void cmbUser_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {


                DataTable dt = obj.editProfile("Select * from UserList where UserName='" + cmbUser.SelectedItem.ToString() + "'");

                txtFullName.Text = dt.Rows[0][3].ToString();
                txtNIC.Text = dt.Rows[0][4].ToString();
                txtAddress.Text = dt.Rows[0][5].ToString();
                txtContact.Text = dt.Rows[0][6].ToString();

                if (dt.Rows[0][7].ToString() == "Male")
                    cmbGender.SelectedIndex = 0;
                dtpDOB.Text = dt.Rows[0][8].ToString();

                DataSet ds = obj.view_image("Select img from tblpicture where id='" + cmbUser.SelectedItem.ToString() + "'");
                DataTable img = ds.Tables[0];

                foreach (DataRow row in img.Rows)
                {
                    byte[] blob = (byte[])row[0];
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
                    imgProfile.Source = bi;

                }





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
