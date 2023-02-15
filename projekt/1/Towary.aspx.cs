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
using static System.Collections.Specialized.BitVector32;

namespace projekt
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        protected void Logout_Button_Click(object sender, EventArgs e)
        {
            Session.Remove("USER_ID");
            Session.RemoveAll();
        }
        protected void Page_Load(object sender, EventArgs e)
        {



            if (Session["USER_ID"] != null)
            {logout_button.Visible = true;
                    login_session.Text = Session["USER_ID"].ToString();
                    Panel2.Visible = true;
                
            }
            else
            {
                Panel2.Visible = false; 
                logout_button.Visible = false;
            }
        
            string sqlquery = "select Id, Nazwa, ilosc, cena from Towar";
                SqlCommand wys = new SqlCommand(sqlquery, con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(wys);
                DataTable tabela = new DataTable();
                sda.Fill(tabela);
                StringBuilder sb = new StringBuilder();
                sb.Append("<center>");
                
                sb.Append("<table border=1>");
                sb.Append("<tr>");

                // foreach (DataColumn kolumna in tabela.Columns)
                {

                    sb.Append("<th>");
                    sb.Append("id towaru");
                    sb.Append("</th>");
                    sb.Append("<th>");
                    sb.Append("nazwa");
                    sb.Append("</th>");
                    sb.Append("<th>");
                    sb.Append("ilość");
                    sb.Append("</th>");
                    sb.Append("<th>");
                    sb.Append("cena za sztukę");
                    sb.Append("</th>");
                   
                  

                }
                sb.Append("</th>");

                foreach (DataRow dr in tabela.Rows)
                {
                    sb.Append("<tr>");
                    foreach (DataColumn kolumna in tabela.Columns)
                    {
                        sb.Append("<th>");
                        sb.Append(dr[kolumna.ColumnName].ToString());
                        sb.Append("</th>");
                    }

                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                sb.Append("</center>");

                Panel1.Controls.Add(new Label { Text = sb.ToString() });

                con.Close();
            }
           

        }
 

}