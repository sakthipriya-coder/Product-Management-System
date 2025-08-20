using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public partial class ProductAttributeValue : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
                LoadAttributes();
                LoadProductAttributes();
            }
        }

        private void LoadProducts()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT prod_id, prod_name FROM Product", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlProduct.DataSource = dt;
                ddlProduct.DataTextField = "prod_name";
                ddlProduct.DataValueField = "prod_id";
                ddlProduct.DataBind();
            }
        }

        private void LoadAttributes()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT att_id, att_name FROM Attribute", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlAttribute.DataSource = dt;
                ddlAttribute.DataTextField = "att_name";
                ddlAttribute.DataValueField = "att_id";
                ddlAttribute.DataBind();
            }
        }

        private void LoadProductAttributes()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(@"
                    SELECT pav.pro_att_id, p.prod_name, a.att_name, pav.att_value
                    FROM ProductAttributeValue pav
                    INNER JOIN Product p ON pav.prod_id = p.prod_id
                    INNER JOIN Attribute a ON pav.att_id = a.att_id", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                gvProductAttributes.DataSource = dt;
                gvProductAttributes.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "INSERT INTO ProductAttributeValue (prod_id, att_id, att_value) VALUES (@prod_id, @att_id, @att_value)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@prod_id", ddlProduct.SelectedValue);
                cmd.Parameters.AddWithValue("@att_id", ddlAttribute.SelectedValue);
                cmd.Parameters.AddWithValue("@att_value", txtValue.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            txtValue.Text = "";
            LoadProductAttributes();
        }

        // ✅ DELETE
        protected void gvProductAttributes_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvProductAttributes.DataKeys[e.RowIndex].Value);

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "DELETE FROM ProductAttributeValue WHERE pro_att_id=@ID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadProductAttributes();
        }

        // ✅ EDIT MODE
        protected void gvProductAttributes_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvProductAttributes.EditIndex = e.NewEditIndex;
            LoadProductAttributes();
        }

        // ✅ CANCEL EDIT
        protected void gvProductAttributes_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvProductAttributes.EditIndex = -1;
            LoadProductAttributes();
        }

        // ✅ UPDATE VALUE
        protected void gvProductAttributes_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvProductAttributes.DataKeys[e.RowIndex].Value);
            string value = ((System.Web.UI.WebControls.TextBox)gvProductAttributes.Rows[e.RowIndex].Cells[3].Controls[0]).Text;

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "UPDATE ProductAttributeValue SET att_value=@Value WHERE pro_att_id=@ID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Value", value);
                cmd.Parameters.AddWithValue("@ID", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            gvProductAttributes.EditIndex = -1;
            LoadProductAttributes();
        }
    }
}
