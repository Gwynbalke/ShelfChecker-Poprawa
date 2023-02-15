using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace projekt
{
    public partial class login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            
    
        }
   
 
        protected void txtUserId_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {












          try
            {
                string UserId = txtUserID.Text;
                string Pass = txtPassword.Text;

                con.Open();
                string Logging = "select User_Id from User_log where User_Id='" + UserId + "' and Password='" + Pass + "'";
                SqlCommand cmd = new SqlCommand(Logging, con);
                SqlDataReader srd = cmd.ExecuteReader();
                if (srd.Read())
                {
                    Session["USER_ID"] = UserId;
                    Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    lblError.Text = "Niepoprawne dane logowania";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

           
        }
    }
}