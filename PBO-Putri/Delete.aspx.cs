using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PBO_Putri
{
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            deleteData(id);
            Response.Redirect("~/");

        }
        protected void deleteData(string id)
        {
            try /* Deletion After Validations*/
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["databasepgsql"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = $"Delete from barang where id={id}";
                    cmd.CommandType = CommandType.Text;
                    //cmd.Parameters.Add(new NpgsqlParameter("@ID", Convert.ToInt32(txtEmployeeID.Text)));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();
                    //txtEmployeeID.Text = "";
                    //warning.Text = "Data Has been Deleted";
                }
            }
            catch (Exception ex)
            {
                //warning.Text = "gagal";
            }
        }
    }
}