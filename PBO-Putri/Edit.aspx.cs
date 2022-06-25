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
    public partial class Edit : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            getDataByID(id);
            //Response.Redirect("~/");
        }

        protected void getDataByID(string id)
        {

            try /* Select After Validations*/
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["databasepgsql"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = $"Select * from barang where id={id} ";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);


                    String namabarang = dt.Rows[0]["namabarang"].ToString();
                    int harga = int.Parse(dt.Rows[0]["harga"].ToString());
                    int stok = int.Parse(dt.Rows[0]["stok"].ToString());

                    cmd.Dispose();
                    connection.Close();

                }
            }
            catch (Exception ex)
            {

            }

        }
        protected void updateData(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            try /* Updation After Validations*/
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["databasepgsql"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = $"Select * from barang where id={id} ";
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    string namabarang = dt.Rows[0]["harga"].ToString();
                    int harga = int.Parse(dt.Rows[0]["harga"].ToString());
                    int stok = int.Parse(dt.Rows[0]["stok"].ToString());

                    string namabarangData, hargaData, stokData;

                    if (namaInput.Text == "")
                    {
                        namabarangData = namabarang;
                    }
                    else
                    {
                        namabarangData = namaInput.Text;
                    }
                    if (hargaInput.Text == "")
                    {
                        hargaData = harga.ToString();
                    }
                    else
                    {
                        hargaData = hargaInput.Text;
                    }
                    if (stokInput.Text == "")
                    {
                        stokData = stok.ToString();
                    }
                    else
                    {
                        stokData = stokInput.Text;
                    }
                    cmd.CommandText = $"update barang set namabarang='{namabarangData}', harga={hargaData},stok='{stokData}' where id={id}";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();
                    //warning.Text = statusInput.SelectedValue + " ======= " + dlInput.Text + " =========== " + taskInput.Text;

                    Response.Redirect("~/");
                }
            }
            catch (Exception ex)
            {
            }
        }

    }
}