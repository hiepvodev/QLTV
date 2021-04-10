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
        string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='E:\School\KT TMDT ASP.Net\project\QLTV\QLTV\QLTV\App_Data\QLTV.mdf';Integrated Security=True";
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
                SqlDataAdapter da = new SqlDataAdapter(q, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.DataList1.DataSource = dt;
                this.DataList1.DataBind();
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}