using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShowSignIn_Click(object sender, EventArgs e)
        {
            pnlSignIn.Visible = true;
            pnlSignUp.Visible = false;
        }

        protected void btnShowSignUp_Click(object sender, EventArgs e)
        {
            pnlSignIn.Visible = false;
            pnlSignUp.Visible = true;
        }

        // Sign In logic
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtLoginUsername.Text;
            string password = txtLoginPassword.Text;

            // Use the connection string from Web.config
            string connStr = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            SqlConnection con = new SqlConnection(connStr);

            string query = "SELECT COUNT(*) FROM Table1 WHERE aname=@Username AND password=@Password";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);

            con.Open();
            int count = (int)cmd.ExecuteScalar();
            con.Close();

            if (count == 1)
            {
                Response.Redirect("AdminDashboard.aspx");
            }
            else
            {
                Response.Write("<script>alert('Invalid Username or Password');</script>");
            }
        }

        // Sign Up logic
        protected void btnSignup_Click(object sender, EventArgs e)
        {
            string username = txtSignupUsername.Text;
            string password = txtSignupPassword.Text;
            string email = txtSignupEmail.Text;
            string phone = txtSignupPhone.Text;
            string address = txtSignupAddress.Text;

            string connStr = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            SqlConnection con = new SqlConnection(connStr);

            string query = "INSERT INTO Table1 (aname, password, email, phone, address) " +
                           "VALUES (@Username, @Password, @Email, @Phone, @Address)";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Address", address);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Response.Write("<script>alert('Sign Up Successful! Please log in.');</script>");

            pnlSignIn.Visible = true;
            pnlSignUp.Visible = false;
        }
    }
}
