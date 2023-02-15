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
using System.Web.Http.Results;

namespace projekt
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            
            // sprawdzanie czy użytkownik jest zalogowany
            if (Session["USER_ID"] != null)
            {
                // wyświetlanie zalogowanego użytkownika
                login_session.Text = Session["USER_ID"].ToString();


                // połączenie SQL
                string sqlquery = "select imie, nazwisko, email, User_Id from User_log";
                SqlCommand wys = new SqlCommand(sqlquery, con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(wys);
                DataTable tabela = new DataTable();
                sda.Fill(tabela);
                StringBuilder sb = new StringBuilder();
                
                //Wczytywanie danych z bazy w formie tabeli
                sb.Append("<center>");

                sb.Append("<table border=1>");
                sb.Append("<tr>");

                {
                    // Określanie nagłówków tabeli
                    sb.Append("<th>");
                    sb.Append("imie");
                    sb.Append("</th>");
                    sb.Append("<th>");
                    sb.Append("nazwisko");
                    sb.Append("</th>");
                    sb.Append("<th>");
                    sb.Append("email");
                    sb.Append("</th>");
                    sb.Append("<th>");
                    sb.Append("Login");
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
                Response.Redirect("default.aspx");
            }

        }

        //wylogowanie
        protected void Logout_Button_Click(object sender, EventArgs e)
        {
            Session.Remove("USER_ID");
            Session.RemoveAll();
        }

      //rejestracja nowego użytkownika
        protected void registration_button_Click(object sender, EventArgs e)
        {




            try
            {
                string Login = UserID_Text.Text;
                string Email = Email_Text.Text;
                string Password = Password_Text.Text;
                string name = Input_Name.Text;
                string surname = Input_Surname.Text;


                // Reguły dla loginu:
                // - musi zawierać co najmniej 2 litery lub znaki
                if (Login.Length < 2 || string.IsNullOrWhiteSpace(Login) || !Login.All(char.IsLetterOrDigit))
                {
                    lblError.Text = "Login musi zawierać co najmniej 2 litery lub znaki";
                }

                // Regułu dla hasła
                // - musi zawierać więcej niż 4 znaki
                else if (Password.Length <4|| string.IsNullOrWhiteSpace(Password))
                {
                    lblError.Text = "Hasło musi zawierać minimum 4 znaki";
                }

                
                // Reguły dla adresu email:
                // - nie może być pusty
                else  if (string.IsNullOrWhiteSpace(Email) )
                {
                    lblError.Text = "Adres email jest niepoprawny";
                }

                // Reguły dla imienia:
                // - nie może być pusty
                // - musi być literami
               else if (string.IsNullOrWhiteSpace(name) || !name.All(char.IsLetter))
                {
                   
                    lblError.Text = "Imię jest niepoprawne";
                }
               
                // Reguły dla nazwiska:
                // - nie może być puste
                 else   if (string.IsNullOrWhiteSpace(surname) || !surname.All(char.IsLetter))
                {
                    lblError.Text = "Nazwisko jest niepoprawne";
                }


             

                else
                {
                                     
                 // dodawanie użytkownika, jeśli jego dane spełniają określone wymagania
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select count(*) from User_log where User_Id = '" + Login + "'", con);

                    // Sprawdzanie czy użytkownik istnieje
                    string getValue = cmd.ExecuteScalar().ToString();
                    if (getValue != "0")
                    {
                        lblError.Text = "Nazwa takiego użytkownika już istnieje";
                    }
                    else //dodawanie użytkownika
                    {
                        string Register = "Insert into User_log (ID, User_Id, email, Password, imie, nazwisko) values (5, '" + Login + "', '" + Email + "', '" + Password + "', '" + name + "', '" + surname + "' )";
                        SqlCommand cmmd = new SqlCommand(Register, con);
                        SqlDataReader regcomm = cmmd.ExecuteReader();
                        lblError.Text = "Pomyślnie dodano użytkownika";
                        Response.Redirect("Użytkownicy.aspx");
                        foreach (Control control in Form.Controls)
                        {
                            if (control is TextBox)
                            {
                                ((TextBox)control).Text = string.Empty;
                            }
                        }
                    }

                    con.Close();


                }

            }
            catch (Exception)
            {
                lblError.Text = "nieprawidłowe dane";
            }




        }

    }
}