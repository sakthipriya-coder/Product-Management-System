using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AttributePage : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
                LoadAttributes();
            }
        }

        private void LoadCategories()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT cat_id, cat_name FROM Category", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlCategory.DataSource = dt;
                ddlCategory.DataTextField = "cat_name";
                ddlCategory.DataValueField = "cat_id";
                ddlCategory.DataBind();
            }
        }

        private void LoadAttributes()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(@"
                    SELECT a.att_id, a.att_name, c.cat_name 
                    FROM Attribute a 
                    INNER JOIN Category c ON a.cat_id = c.cat_id", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                gvAttributes.DataSource = dt;
                gvAttributes.DataBind();
            }
        }

        protected void btnAddAttribute_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "INSERT INTO Attribute (att_name, cat_id) VALUES (@Name, @CatID)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", txtAttributeName.Text);
                cmd.Parameters.AddWithValue("@CatID", ddlCategory.SelectedValue);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            txtAttributeName.Text = "";
            LoadAttributes();
        }

        protected void gvAttributes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAttributes.EditIndex = e.NewEditIndex;
            LoadAttributes();
        }

        protected void gvAttributes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAttributes.EditIndex = -1;
            LoadAttributes();
        }

        protected void gvAttributes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int attId = Convert.ToInt32(gvAttributes.DataKeys[e.RowIndex].Value);
            string attName = ((TextBox)gvAttributes.Rows[e.RowIndex].Cells[1].Controls[0]).Text;

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "UPDATE Attribute SET att_name=@Name WHERE att_id=@ID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", attName);
                cmd.Parameters.AddWithValue("@ID", attId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            gvAttributes.EditIndex = -1;
            LoadAttributes();
        }

        protected void gvAttributes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvAttributes.DataKeys[e.RowIndex].Value);

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "DELETE FROM Attribute WHERE att_id=@ID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadAttributes();
        }
    }
}
