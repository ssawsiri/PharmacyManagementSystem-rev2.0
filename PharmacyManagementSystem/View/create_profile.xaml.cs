using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.IO;
using Microsoft.Win32;
using System.Data.SqlClient;

namespace PharmacyManagementSystem.View
{
    /// <summary>
    /// Interaction logic for create_profile.xaml
    /// </summary>
    public partial class create_profile : UserControl
    {

        Database_Connect obj = new Database_Connect();
        string strName, imageName;
        public create_profile()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text))
                txtblockError.Text = "* User Name Cannot be Blank";
            else if (string.IsNullOrEmpty(pwdPassword.Password))
                txtblockError.Text = "* Password Cannot be Blank";
            else if (!Regex.IsMatch(pwdPassword.Password, @"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$"))
                txtblockError.Text = "Please see the password requirement";
            else if (pwdPassword.Password != pwdConfirm.Password)
                txtblockError.Text = "* Password dismatched, Please Check again";
            else if (string.IsNullOrEmpty(cmbPrevilage.Text))
                txtblockError.Text = "* User Previlage cannot be blanked";
            else if (string.IsNullOrEmpty(txtFullName.Text))
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
                string previlage, gender;
                if (cmbPrevilage.SelectedIndex == 0)
                    previlage = "Dispenser";
                else if (cmbPrevilage.SelectedIndex == 1)
                    previlage = "Supervisor";
                else
                    previlage = "Administrator";
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

                string username = txtUser.Text;
                
                
                int i = obj.save_update_delete("Insert into UserList (UserName, UserPassword, UserPrevilage, EmployeeName, NICNo, EmpAddress, EmpContactNo, Gender, BOD) values('" + txtUser.Text + "','" + pwdConfirm.Password + "', '" + previlage + "', '" + txtFullName.Text + "', '" + txtNIC.Text + "', '" + txtAddress.Text + "', '" + txtContact.Text + "', '" + gender + "', '" + dtpDOB.SelectedDate + "')");
                obj.insert_image(username, imgByteArr);

                if (i == 1)
                {
                    MessageBox.Show("User Successfully Saved", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtUser.Clear();
                    txtNIC.Clear();
                    txtFullName.Clear();
                    txtContact.Clear();
                    txtAddress.Clear();
                    pwdPassword.Clear();
                    pwdConfirm.Clear();
                    imgProfile.Source = null;
                }
                else
                    MessageBox.Show("Error Occured Please Check Again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);



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
    }
}
