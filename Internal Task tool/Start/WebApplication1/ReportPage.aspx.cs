using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public partial class ReportPage : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadReport();
            }
        }

        private void LoadReport()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = @"
                SELECT p.prod_id, p.prod_name, p.price, c.cat_name,
                       STUFF((
                            SELECT ', ' + a.att_name
                            FROM ProductAttributeValue pa
                            INNER JOIN Attribute a ON pa.att_id = a.att_id
                            WHERE pa.prod_id = p.prod_id
                            FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') as attributes
                FROM Product p
                INNER JOIN Category c ON p.cat_id = c.cat_id";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                
                gvReport.DataSource = dt;
                gvReport.DataBind();
            }
        }
    }
}
