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
using System.Collections;
using System.Linq;

namespace projekt
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        protected void Page_Load(object sender, EventArgs e)
            

        {
            
            if (Session["USER_ID"] != null)
            {

                login_session.Text = Session["USER_ID"].ToString();



                try
                {
                    con.Open();
                    string aktual = "update  Towar set wartosc = cena * ilosc";
                    SqlCommand cmmd = new SqlCommand(aktual, con);
                    SqlDataReader regcomm = cmmd.ExecuteReader();


                    if (regcomm.Read())
                    {
                       
                    }
                    else
                    {

                     
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }

            if (Session["USER_ID"] != null)
            {

                odejmij_towar_button.Visible = true;
                podaj_ilosc_text.Visible = true;
                string sqlquery = "select * from towar";
                SqlCommand wys = new SqlCommand(sqlquery, con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(wys);
                DataTable tabela = new DataTable();
                sda.Fill(tabela);
                StringBuilder sb = new StringBuilder();
                
                sb.Append("<table  border='1' cellspacing='0' cellpadding='0'");
                sb.Append("<tr>");

                // foreach (DataColumn kolumna in tabela.Columns)
                {

                    sb.Append("<th>");
                    sb.Append("id");
                    sb.Append("</th>");
                    sb.Append("<th>");
                    sb.Append("nazwa");
                    sb.Append("</th>");
                    sb.Append("<th>");
                    sb.Append("ilość");
                    sb.Append("</th>");
                    sb.Append("<th>");
                    sb.Append("cena(zł)");
                    sb.Append("</th>");
                    sb.Append("<th>");
                    sb.Append("wartość(zł)");
                    sb.Append("</th>");
                    sb.Append("<th>");
                    sb.Append("dodane przez");
                    sb.Append("</th>");
                }
                sb.Append("</th>");

                foreach (DataRow dr in tabela.Rows)
                {
                    sb.Append("<tr>");
                    foreach (DataColumn kolumna in tabela.Columns)
                    {
                        sb.Append("<td>");
                        sb.Append(dr[kolumna.ColumnName].ToString());
                        sb.Append("</td>");
                    }

                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                sb.Append("</center>");

                Panel1.Controls.Add(new Label { Text = sb.ToString() });

                con.Close();
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

        protected void Dodaj_Towar_Button_Click(object sender, EventArgs e)
        {
            try
            {
                string ilosc_towaru = podaj_ilosc_text.Text;
                string nazwa_towaru = nazwa_towaru_text.Text;

                con.Open();
                string dodaj_towar = " UPDATE Towar SET ilosc = ilosc + " + ilosc_towaru + " WHERE Nazwa ='" + nazwa_towaru + "' ; ";
                SqlCommand cmd = new SqlCommand(dodaj_towar, con);
                SqlDataReader regcomm = cmd.ExecuteReader();


                if (regcomm.Read())
                {
                    lblError.Text = "Niepowodzenie, podano nieprawidłowe dane";
                }
                else
                {

                    lblError.Text = "Operacja zakończona sukcesem";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }


        protected void Odejmij_Towar_Button_Click(object sender, EventArgs e)
        {
            try
            {
                string ilosc_towaru = podaj_ilosc_text.Text;
                string nazwa_towaru = nazwa_towaru_text.Text;

                con.Open();
                string odejmij_towar = " UPDATE Towar SET ilosc = ilosc - " + ilosc_towaru + " WHERE Nazwa ='" + nazwa_towaru + "' ; ";
                SqlCommand cmd = new SqlCommand(odejmij_towar, con);
                SqlDataReader regcomm = cmd.ExecuteReader();


                if (regcomm.Read())
                {
                    lblError.Text = "Niepowodzenie, podano nieprawidłowe dane";
                }
                else
                {

                    lblError.Text = "Operacja zakończona sukcesem";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void Zmien_Cene_Towaru_Click(object sender, EventArgs e)
        {
            try
            {
                int cena_towaru = int.Parse(cena_towaru_text.Text);
                string nazwa_towaru = nazwa_towaru_text.Text;

                con.Open();
                string zmien_cene = " UPDATE Towar SET cena =" + cena_towaru + " WHERE Nazwa ='" + nazwa_towaru + "' ; ";
                SqlCommand cmd = new SqlCommand(zmien_cene, con);
                SqlDataReader regcomm = cmd.ExecuteReader();


                if (regcomm.Read())
                {
                    lblError.Text = "Niepowodzenie, podano nieprawidłowe dane";
                }
                else
                {

                    lblError.Text = "Operacja zakończona sukcesem";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void Dodaj_Nowy_Towar_Click(object sender, EventArgs e)
        {
            try
            {
                int cena_towaru = int.Parse(nowy_towar_cena.Text);
                string nazwa_towaru = nowy_towar_nazwa.Text;
                int ilosc = int.Parse(nowy_towar_ilosc.Text);
                string kto_dodal = Session["USER_ID"].ToString();

                con.Open();
                string dodaj_nowy = "insert into Towar (Nazwa, ilosc, cena, dodane_przez) values('"+ nazwa_towaru +"', "+ ilosc +", "+ cena_towaru +", '"+kto_dodal+"');";
                SqlCommand cmd = new SqlCommand(dodaj_nowy, con);
                SqlDataReader regcomm = cmd.ExecuteReader();


                if (regcomm.Read())
                {
                    lblError.Text = "Niepowodzenie, podano nieprawidłowe dane";
                }
                else
                {

                    lblError.Text = "Operacja zakończona sukcesem";
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

