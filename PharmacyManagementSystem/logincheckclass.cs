using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Data.SqlClient;



namespace PharmacyManagementSystem
{
   
   class logincheckclass
    {
              
        admin_window adwin = new admin_window();
        Database_Connect obj = new Database_Connect();
        
        
        public void login_check(string username, string password)
        {
                  
            DataTable dt = obj.view_data("SELECT COUNT(*) FROM UserList WHERE UserName='"+ @username +"' AND UserPassword='"+ @password +"' AND UserPrevilage='Administrator'");
            DataTable dtsuper = obj.view_data("SELECT COUNT(*) FROM UserList WHERE UserName='" + @username + "' AND UserPassword='" + @password + "' AND UserPrevilage='Supervisor'");
            DataTable dtdispense = obj.view_data("SELECT COUNT(*) FROM UserList WHERE UserName='" + @username + "' AND UserPassword='" + @password + "' AND UserPrevilage='Dispenser'");


            if (dt.Rows[0][0].ToString() == "1")
            {
                obj.save_update_delete("Insert into LoginHistory (UserName, UserPrevilage) Values ('" + username + "', 'Administrator')");
                adwin.Show();
                                               
            }
            else if(dtsuper.Rows[0][0].ToString() == "1")
            {
                obj.save_update_delete("Insert into LoginHistory (UserName, UserPrevilage) Values ('" + username + "', 'Supervisor')");
                supervisor_window supwin = new supervisor_window();
                supwin.Show();
            }
            else if (dtdispense.Rows[0][0].ToString() == "1")
            {
                obj.save_update_delete("Insert into LoginHistory (UserName, UserPrevilage) Values ('" + username + "', 'Dispenser')");
                dispenser_window diswin = new dispenser_window();
                diswin.Show();
            }
            else
            {
                MessageBox.Show("Please Enter Valid User Details", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                login_window logwin = new login_window();
                logwin.Show();

            }
                
            
               
        }
    }
}
