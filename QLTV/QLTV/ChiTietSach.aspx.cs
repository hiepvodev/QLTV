using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace QLTV
{
    public partial class ChiTietSach1 : System.Web.UI.Page
    {
        ketnoi kn = new ketnoi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            string q;
            if (Context.Items["ms"] == null)
            {
                q = "select * from Sach";
            }
            else
            {
                string masach = Context.Items["ms"].ToString();
                q = "select * from Sach where masach='" + masach + "'";
            }

            try
            {
                DataTable dt = kn.laydata(q);
                this.DataList1.DataSource = dt;
                this.DataList1.DataBind();
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button muon = (Button)sender;
            string mahang = muon.CommandArgument.ToString();
            DataListItem item = (DataListItem)muon.Parent;
            string soluong = ((TextBox)item.FindControl("TextBox1")).Text;

            SqlConnection con = new SqlConnection(conn);
            con.Open();

            string query = "select * from donhang where tendangnhap = '" + ten + "' and mahang= '" + mahang + "'";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                reader.Close();
                command = new SqlCommand("update donhang set soluong = soluong +" + soluong + " where tendangnhap='" +
                    ten + "' and mahang ='" + mahang + "'", con);
            }
            else
            {
                reader.Close();
                command = new SqlCommand("insert into donhang values ('" + ten + "', '" + mahang + "','" + soluong + "')", con);
            }
            command.ExecuteNonQuery();
            con.Close();
        }
    }
}