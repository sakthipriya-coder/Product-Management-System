using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public partial class ProductPage : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
                LoadProducts();
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

        private void LoadProducts()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(@"
                    SELECT p.prod_id, p.prod_name, p.price, c.cat_name
                    FROM Product p
                    INNER JOIN Category c ON p.cat_id = c.cat_id", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                gvProducts.DataSource = dt;
                gvProducts.DataBind();
            }
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "INSERT INTO Product (prod_name, price, cat_id) VALUES (@prod_name, @price, @cat_id)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@prod_name", txtProductName.Text);
                cmd.Parameters.AddWithValue("@price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@cat_id", ddlCategory.SelectedValue);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            LoadProducts();

            txtProductName.Text = "";
            txtPrice.Text = "";
        }

        // Edit
        protected void gvProducts_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvProducts.EditIndex = e.NewEditIndex;
            LoadProducts();
        }

        // Cancel Edit
        protected void gvProducts_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvProducts.EditIndex = -1;
            LoadProducts();
        }

        // Update
        protected void gvProducts_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int prodId = Convert.ToInt32(gvProducts.DataKeys[e.RowIndex].Value);
            string prodName = ((System.Web.UI.WebControls.TextBox)gvProducts.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string price = ((System.Web.UI.WebControls.TextBox)gvProducts.Rows[e.RowIndex].Cells[2].Controls[0]).Text;

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "UPDATE Product SET prod_name=@prod_name, price=@price WHERE prod_id=@prod_id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@prod_name", prodName);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@prod_id", prodId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            gvProducts.EditIndex = -1;
            LoadProducts();
        }

        // Delete
        protected void gvProducts_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int prodId = Convert.ToInt32(gvProducts.DataKeys[e.RowIndex].Value);

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "DELETE FROM Product WHERE prod_id=@prod_id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@prod_id", prodId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            LoadProducts();
        }
    }
}
