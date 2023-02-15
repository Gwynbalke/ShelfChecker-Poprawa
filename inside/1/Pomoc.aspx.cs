using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projekt
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_ID"] != null)
            {

                login_session.Text = Session["USER_ID"].ToString();



            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
        protected void Logout_Button_Click(object sender, EventArgs e)
        {
            Session.Remove("USER_ID");
            Session.RemoveAll();
        }
    }
}