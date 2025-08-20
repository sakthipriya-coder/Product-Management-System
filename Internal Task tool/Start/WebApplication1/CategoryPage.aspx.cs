using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public partial class CategoryPage : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        // show data
        void BindGrid(string search = "")
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "SELECT cat_id, cat_name FROM Category";
                if (!string.IsNullOrEmpty(search))
                {
                    query += " WHERE cat_name LIKE @search";
                }
                query += " ORDER BY cat_name";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (!string.IsNullOrEmpty(search))
                        cmd.Parameters.AddWithValue("@search", search + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvCategories.DataSource = dt;
                    gvCategories.DataBind();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                lblMsg.Text = "Category name is required!";
                lblMsg.CssClass = "error";
                return;
            }

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Category WHERE cat_name=@name", con);
                checkCmd.Parameters.AddWithValue("@name", txtCategoryName.Text.Trim());
                int exists = (int)checkCmd.ExecuteScalar();

                if (exists > 0)
                {
                    lblMsg.Text = "Category already exists!";
                    lblMsg.CssClass = "error";
                    return;
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Category(cat_name) VALUES(@name)", con);
                cmd.Parameters.AddWithValue("@name", txtCategoryName.Text.Trim());
                cmd.ExecuteNonQuery();
                lblMsg.Text = "Category saved successfully!";
                lblMsg.CssClass = "msg";
            }
            txtCategoryName.Text = "";
            BindGrid();
        }

        protected void gvCategories_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int catId = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "EditCat")
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand("SELECT cat_name FROM Category WHERE cat_id=@id", con);
                    cmd.Parameters.AddWithValue("@id", catId);
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        txtCategoryName.Text = result.ToString();
                        hfCatId.Value = catId.ToString();
                        btnSave.Visible = false;
                        btnUpdate.Visible = true;
                        btnCancel.Visible = true;
                    }
                }
            }
            else if (e.CommandName == "DeleteCat")
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    // check for products before delete
                    SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM Product WHERE cat_id=@id", con);
                    check.Parameters.AddWithValue("@id", catId);
                    con.Open();
                    int cnt = (int)check.ExecuteScalar();
                    if (cnt > 0)
                    {
                        lblMsg.Text = "Cannot delete. Products exist under this category.";
                        lblMsg.CssClass = "error";
                        return;
                    }

                    SqlCommand cmd = new SqlCommand("DELETE FROM Category WHERE cat_id=@id", con);
                    cmd.Parameters.AddWithValue("@id", catId);
                    cmd.ExecuteNonQuery();
                    lblMsg.Text = "Category deleted.";
                    lblMsg.CssClass = "msg";
                }
                BindGrid();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text) || string.IsNullOrEmpty(hfCatId.Value))
                return;

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Category WHERE cat_name=@name AND cat_id<>@id", con);
                checkCmd.Parameters.AddWithValue("@name", txtCategoryName.Text.Trim());
                checkCmd.Parameters.AddWithValue("@id", hfCatId.Value);
                int exists = (int)checkCmd.ExecuteScalar();

                if (exists > 0)
                {
                    lblMsg.Text = "Category already exists!";
                    lblMsg.CssClass = "error";
                    return;
                }

                SqlCommand cmd = new SqlCommand("UPDATE Category SET cat_name=@name WHERE cat_id=@id", con);
                cmd.Parameters.AddWithValue("@name", txtCategoryName.Text.Trim());
                cmd.Parameters.AddWithValue("@id", hfCatId.Value);
                cmd.ExecuteNonQuery();
                lblMsg.Text = "Category updated successfully!";
                lblMsg.CssClass = "msg";
            }
            txtCategoryName.Text = "";
            hfCatId.Value = "";
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            BindGrid();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtCategoryName.Text = "";
            hfCatId.Value = "";
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid(txtSearch.Text.Trim());
        }
    }
}
