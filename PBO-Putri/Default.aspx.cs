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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Pencatatan> pencatatanList = getPencatatan(null, null);
            int index = 1;
            foreach (Pencatatan pencatatan in pencatatanList)
            {
                body.InnerHtml +=
                    $"<tr><td>{index}</td>" +
                    $"<td>{pencatatan.namabarang}</td>" +
                    $"<td>{pencatatan.stok}</td>" +
                    $"<td>{pencatatan.harga}</td>" +
                    $"<td><a class=\"btn btn-primary mr-2 \" href=\"Edit.aspx/?id={pencatatan.id}\">Edit</a>" +
                    $"<a class=\"btn btn-danger mr-2 \" href=\"Delete.aspx/?id={pencatatan.id}\">Delete</a></td></tr>";
                index++;
            }
        }

        protected List<Pencatatan> getPencatatan(object sender, EventArgs e)
        {
            List<Pencatatan> pencatatanList = new List<Pencatatan>();

            try /* Select After Validations*/
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["databasepgsql"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from barang";
                    cmd.CommandType = CommandType.Text;

                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        String id = dt.Rows[i]["id"].ToString();
                        String namabarang = dt.Rows[i]["namabarang"].ToString();
                        int harga= int.Parse(dt.Rows[i]["harga"].ToString());
                        int stok = int.Parse(dt.Rows[i]["stok"].ToString());
                        Pencatatan pencatatan = new Pencatatan(id, namabarang, harga, stok);
                        pencatatanList.Add(pencatatan);
                    }

                    cmd.Dispose();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return pencatatanList;

        }


    }
}