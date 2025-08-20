using System;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStats();
            }
        }

        private void LoadStats()
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                // Category Count
                SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) FROM Category", con);
                lblCategoryCount.Text = cmd1.ExecuteScalar().ToString();

                // Product Count
                SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM Product", con);
                lblProductCount.Text = cmd2.ExecuteScalar().ToString();

                // Attribute Count
                SqlCommand cmd3 = new SqlCommand("SELECT COUNT(*) FROM Attribute", con);
                lblAttributeCount.Text = cmd3.ExecuteScalar().ToString();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx"); // back to login page
        }
    }
}
