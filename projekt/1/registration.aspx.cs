using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace projekt
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());

        protected void registration_button_Click(object sender, EventArgs e)
        {




            try
            {
                string Login = txtUser_Id.Text;
                string Email = txtEmail.Text;
                string Password = txtPassword.Text;
                string name = input_name.Text;
                string surname = input_surname.Text;

                con.Open();
                string Register = "Insert into User_log (ID, User_Id, email, Password, imie, nazwisko) values (5, '" + Login + "', '" + Email + "', '" + Password + "', '" + name + "', '" + surname + "' )";
                SqlCommand cmd = new SqlCommand(Register, con);
                SqlDataReader regcomm = cmd.ExecuteReader();

                if (Login == "" || Email == "" || Password == "" || name == "" || surname == "" )
                {
                    lblError.Text = "nieprawidłowe dane";

                }
                else
                {

                    if (regcomm.Read())
                    {

                    }
                    else
                    {
                        lblError.Text = "Pomyślnie zarejstrowano konto";
                        Response.Redirect("login.aspx");
                    }
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