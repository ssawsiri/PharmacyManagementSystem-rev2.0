using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //ADO.Net class library
using System.Data;
using System.IO;
using System.Windows.Media;
using System.Media;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Drawing;






namespace PharmacyManagementSystem
{
    class Database_Connect
    {
        SqlConnection con; //Initiating pipeline
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;

        public Database_Connect() //Default Constructor (Special Method) If you create a object of the class default constructer will run automatically
=> con = new SqlConnection("Data Source=DESKTOP-621M5FP;Initial Catalog=PharmacyManagementSystem;Integrated Security=True"); //Create the pipeline 

        public int save_update_delete(string query)
        {

            con.Open();
            cmd = new SqlCommand(query, con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            
            return i;

        }

        public DataTable view_data(string query)
        {
            con.Open();
            da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            return dt;
        }

        public DataSet view_image(string query)

        {   
            con.Open();
            da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();

            return ds;


        }

       

        public int insert_image(string id, byte[] byteArray)
        {
            
            con.Open();
            cmd = new SqlCommand("Insert into tblpicture(id,img) values (@id,@image) ", con);
            cmd.Parameters.Add(new SqlParameter("image", byteArray));
            cmd.Parameters.Add(new SqlParameter("id", id));
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;

        }

        public int update_image(string id, byte[] byteArray)
        {

            con.Open();
            cmd = new SqlCommand("Update tblPicture set img=@image where id=@id", con);
            cmd.Parameters.Add(new SqlParameter("image", byteArray));
            cmd.Parameters.Add(new SqlParameter("id", id));
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;

        }

        public int delete_image(string id)
        {

            con.Open();
            cmd = new SqlCommand("delete tblPicture where id=@id", con);
                     cmd.Parameters.Add(new SqlParameter("id", id));
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;

        }


        public DataTable editProfile (string query)
        {
            con.Open();
            da = new SqlDataAdapter(query, con);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            DataTable dt = ds.Tables[0];
            return dt;
        }
    }

}

