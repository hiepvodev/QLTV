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
    public partial class Sach1 : System.Web.UI.Page
    {
        string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='E:\School\KT TMDT ASP.Net\project\QLTV\QLTV\QLTV\App_Data\QLTV.mdf';Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            string q;
            if (Context.Items["ml"] == null)
            {
                q = "select * from sach";
            }
            else
            {
                string maloai = Context.Items["ml"].ToString();
                q = "select * from sach where maloai='" + maloai + "'";
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


        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string masach = ((LinkButton)sender).CommandArgument;
            Context.Items["ms"] = masach;
            Response.Redirect("ChiTietSach.aspx");
            Server.Transfer("ChiTietSach.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string masach = ((LinkButton)sender).CommandArgument;
            Context.Items["ms"] = masach;
            Response.Redirect("ChiTietSach.aspx");
            Server.Transfer("ChiTietSach.aspx");
        }
    }
}