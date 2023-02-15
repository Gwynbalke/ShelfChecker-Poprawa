using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.Common;
using System.Diagnostics;

namespace projekt
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());


        // Ładowanie strony
        protected void Page_Load(object sender, EventArgs e)
        {

            // Sprawdzenie czy użytkownik jest zalogowany
            if (Session["USER_ID"] != null)
            {

                login_session.Text = Session["USER_ID"].ToString();
            }
            else
            {
                Response.Redirect("default.aspx");
            }
         
        }

        // Przycisk wylogowania
        protected void Logout_Button_Click(object sender, EventArgs e)
        {
            Session.Remove("USER_ID");
            Session.RemoveAll();
        }

        // Sprawdzenie magazynu
        protected void Magazyn_Button_Click(object sender, EventArgs e)
        {
            Response.Redirect("magazyn.aspx");
        }
   
       
        
    }
}