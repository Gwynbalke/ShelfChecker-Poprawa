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
using System.Runtime.Remoting.Services;
using Newtonsoft.Json.Linq;
using System.Web.Configuration;
using System.Text.RegularExpressions;

namespace projekt
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        // Podłączenie do bazy danych
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
       
        
        
        //Wczytanie strony
        protected void Page_Load(object sender, EventArgs e)


        {
            // Sprawdzanie, czy użytkownik jest zalogowany
            if (Session["USER_ID"] != null)
            {
                // Wyświetlenie ID zalogowanego użytkownika
                login_session.Text = Session["USER_ID"].ToString();

                try
                {
                    // Otwarcie połączenia z bazą danych
                    con.Open();
                    // Aktualizacja wartości w tabeli towar poprzez mnożenie ceny przez ilość
                    string aktual = "update  Towar set wartosc = cena * ilosc";
                    SqlCommand cmmd = new SqlCommand(aktual, con);
                    SqlDataReader regcomm = cmmd.ExecuteReader();

                    // Sprawdzenie, czy zapytanie się powiodło
                    if (regcomm.Read())
                    {
                        // Nic nie robić, jeśli zapytanie się powiodło
                    }
                    else
                    {
                        // Nic nie robić, jeśli zapytanie się nie powiodło
                    }
                    // Zamknięcie połączenia z bazą danych
                    con.Close();
                }
                catch (Exception)
                {
                    // Wyświetlenie komunikatu o błędzie w przypadku wystąpienia wyjątku
                    lblError.Text = "nieprawidłowe dane";
                }
            }
            else
            {
                // Przekierowanie do strony domyślnej, jeśli użytkownik nie jest zalogowany
                Response.Redirect("default.aspx");
            }

            // Jeśli użytkownik jest zalogowany
            if (Session["USER_ID"] != null)
            {
                // Ustawienie widoczności przycisku i pola tekstowego
                Subtract_Product_Button.Visible = true;
                Enter_Quanity_Text.Visible = true;

                // Zapytanie SQL do pobrania wszystkich danych z tabeli towar
                string sqlquery = "select * from towar";
                SqlCommand wys = new SqlCommand(sqlquery, con);
                // Otwarcie połączenia z bazą danych
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(wys);
                DataTable tabela = new DataTable();
                sda.Fill(tabela);
                StringBuilder sb = new StringBuilder();

                // Budowanie tabeli HTML z danymi z tabeli towar
                sb.Append("<table  border='1' cellspacing='0' cellpadding='0'");
                sb.Append("<tr>");

                // tworzenie nagłówka tabeli
                sb.Append("<th>");
                sb.Append("id"); // kolumna id
                sb.Append("</th>");
                sb.Append("<th>");
                sb.Append("nazwa"); // kolumna nazwa
                sb.Append("</th>");
                sb.Append("<th>");
                sb.Append("ilość"); // kolumna ilość
                sb.Append("</th>");
                sb.Append("<th>");
                sb.Append("cena(zł)"); // kolumna cena
                sb.Append("</th>");
                sb.Append("<th>");
                sb.Append("wartość(zł)"); // kolumna wartość
                sb.Append("</th>");
                sb.Append("<th>");
                sb.Append("dodane przez"); // kolumna dodane przez
                sb.Append("</th>");
                sb.Append("</th>");

                // pętla wypełniająca tabelę danymi
                foreach (DataRow dr in tabela.Rows)
                {
                    sb.Append("<tr>");
                    foreach (DataColumn kolumna in tabela.Columns)
                    {
                        sb.Append("<td>");
                        sb.Append(dr[kolumna.ColumnName].ToString()); // dodawanie wartości z kolumn
                        sb.Append("</td>");
                    }

                    sb.Append("</tr>");
                }

                // zakończenie tabeli i dodanie do panelu
                sb.Append("</table>");
                sb.Append("</center>");
                Panel1.Controls.Add(new Label { Text = sb.ToString() });

                // zamknięcie połączenia z bazą danych
                con.Close();
            }
            else
            {
                // przekierowanie na stronę jeśli użytkownik jest nizalogowany
                Response.Redirect("default.aspx");
            }


        }
            // Wylogowanie
            protected void Logout_Button_Click(object sender, EventArgs e)
        {
            Session.Remove("USER_ID");
            Session.RemoveAll();
        }

        // Dodawanie ilości towaru
        protected void Add_Product_Button_Click(object sender, EventArgs e)
        {
            string Product_Quanity = Enter_Quanity_Text.Text;
            string Product_Name = Product_Name_Text.Text;

            // Sprawdź czy ilość jest liczbą dodatnią
            int productQuantity;
            if (!Int32.TryParse(Product_Quanity, out productQuantity) || productQuantity <= 0)
            {
                lblError2.Text = "Podana ilość nie jest liczbą dodatnią";
                return;
            }

            // Połącz z bazą danych
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            con.Open();

            // Sprawdź czy towar istnieje w bazie danych
            string selectProduct = "SELECT COUNT(*) FROM Towar WHERE Nazwa='" + Product_Name + "'";
            SqlCommand checkProduct = new SqlCommand(selectProduct, con);
            int productCount = (int)checkProduct.ExecuteScalar();

            if (productCount == 0)
            {
                lblError2.Text = "Podany towar nie istnieje w bazie danych";
                con.Close();
                return;
            }

            // Zmień ilość towaru w bazie danych
            string updateProduct = "UPDATE Towar SET ilosc = ilosc + " + Product_Quanity + " WHERE Nazwa ='" + Product_Name + "'";
            SqlCommand updateCommand = new SqlCommand(updateProduct, con);
            updateCommand.ExecuteNonQuery();
            lblError2.Text = "Pomyślnie zaktualizowano ilość towaru";
            Response.Redirect("magazyn.aspx");

            // Zakończ połączenie z bazą danych
            con.Close();

          
        }

        // Odjęcie ilości towaru
        protected void Subtract_Product_Button_Click(object sender, EventArgs e)
        {
         
            string Product_Quanity = Enter_Quanity_Text.Text;
            string Product_Name = Product_Name_Text.Text;

            try
            {
                con.Open();

                // Sprawdzanie czy produkt istnieje w bazie danych
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Towar WHERE Nazwa = @ProductName", con);
                cmd.Parameters.AddWithValue("@ProductName", Product_Name);

                int productExists = (int)cmd.ExecuteScalar();

                // Jeśli produkt istnieje, następuje dalsze sprawdzanie jego ilości
                if (productExists > 0)
                {
                    cmd = new SqlCommand("SELECT ilosc FROM Towar WHERE Nazwa = @ProductName", con);
                    cmd.Parameters.AddWithValue("@ProductName", Product_Name);

                    int existingQuantity = (int)cmd.ExecuteScalar();

                    int newQuantity = 0;
                    // Sprawdzanie, czy wprowadzona ilość jest liczbą dodatnią oraz czy jest mniejsza lub równa ilości produktu w bazie danych
                    if (int.TryParse(Product_Quanity, out newQuantity) && newQuantity > 0 && newQuantity <= existingQuantity)
                    {
                        // Aktualizacja ilości produktu w bazie danych
                        cmd = new SqlCommand("UPDATE Towar SET ilosc = ilosc - @Quantity WHERE Nazwa = @ProductName", con);
                        cmd.Parameters.AddWithValue("@Quantity", newQuantity);
                        cmd.Parameters.AddWithValue("@ProductName", Product_Name);

                        cmd.ExecuteNonQuery();
                        lblError2.Text = "Odejmowanie produktu zakończone pomyślnie";

                        // Przekierowanie na stronę magazynu
                        Response.Redirect("magazyn.aspx");
                    }
                    else
                    {
                        lblError2.Text = "Wprowadzoną niepoprawną ilość";
                    }
                }
                else
                {
                    lblError2.Text = "Nie istnieje taki produkt";
                }
            }
            catch (Exception ex)
            {
                lblError2.Text = "Nie udało się połączyć z bazą danych";
            }
            finally
            {
                // Zamykanie połączenia z bazą danych
                con.Close();
            }




        }

        // Zmiana ceny towaru
        protected void Change_Product_Price_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["mycon"].ConnectionString);

            try
            {
                // Pobieranie danych z formularza
                int Product_Quanity = int.Parse(Product_Quanity_Text.Text);
                string Product_Name = Product_Name_Text.Text;

                // Sprawdzenie, czy podana cena jest dodatnia
                if (Product_Quanity <= 0)
                {
                    lblError2.Text = "Podana cena musi być liczbą dodatnią";
                    return;
                }

                // Otwieranie połączenia z bazą danych
                con.Open();

                // Tworzenie zapytania do bazy danych, sprawdzającego czy produkt o podanej nazwie istnieje
                string checkProductExistsQuery = "SELECT COUNT(*) FROM Towar WHERE Nazwa = @Nazwa";
                SqlCommand checkProductExistsCommand = new SqlCommand(checkProductExistsQuery, con);
                checkProductExistsCommand.Parameters.AddWithValue("@Nazwa", Product_Name);

                // Wykonanie zapytania
                int productExists = (int)checkProductExistsCommand.ExecuteScalar();

                // Jeśli produkt nie istnieje, wyświetlenie komunikatu o błędzie
                if (productExists == 0)
                {
                    lblError2.Text = "Podany produkt nie istnieje w bazie danych";
                    return;
                }

                // Tworzenie zapytania aktualizującego cenę produktu
                string updateProductPriceQuery = "UPDATE Towar SET cena = @Cena WHERE Nazwa = @Nazwa";
                SqlCommand updateProductPriceCommand = new SqlCommand(updateProductPriceQuery, con);
                updateProductPriceCommand.Parameters.AddWithValue("@Nazwa", Product_Name);
                updateProductPriceCommand.Parameters.AddWithValue("@Cena", Product_Quanity);

                // Wykonanie zapytania
                updateProductPriceCommand.ExecuteNonQuery();

                // Wyświetlenie komunikatu o powodzeniu
                lblError2.Text = "Cena produktu została pomyślnie zaktualizowana";
                Response.Redirect("magazyn.aspx");
            }
            catch (FormatException)
            { }
                
            }
           

            // Dodawanie nowego produktu
            protected void Add_New_Product_Click(object sender, EventArgs e)
            {
            try
            {
                // Pobieranie danych z formularza
                int Product_Price;
                if (!int.TryParse(New_Product_Price.Text, out Product_Price) || Product_Price <= 0)
                {
                    lblError.Text = "Nieprawidłowa wartość pola 'Cena'. Wprowadź dodatnią liczbę.";
                    return;
                }
                string Product_Name = New_Product_Name.Text;
                int Quantity;
                if (!int.TryParse(New_Product_Quanity.Text, out Quantity) || Quantity <= 0)
                {
                    lblError.Text = "Nieprawidłowa wartość pola 'Ilość'. Wprowadź dodatnią liczbę.";
                    return;
                }
                string Who_Added = Session["USER_ID"].ToString();

                // Sprawdzenie, czy nazwa produktu składa się tylko z liter
                if (!Regex.IsMatch(Product_Name, @"^[a-zA-Z]+$"))
                {
                    lblError.Text = "Nieprawidłowa wartość pola 'Nazwa produktu'. Wprowadź tylko litery.";
                    return;
                }

                {
                    con.Open();

                    // Sprawdzanie, czy produkt już istnieje w bazie danych
                    string Check_If_Exists = "SELECT COUNT(*) FROM Towar WHERE Nazwa = @productName";
                    SqlCommand Cmd_Check_If_Exists = new SqlCommand(Check_If_Exists, con);
                    Cmd_Check_If_Exists.Parameters.AddWithValue("@productName", Product_Name);
                    int Existing_Product_Count = (int)Cmd_Check_If_Exists.ExecuteScalar();

                    if (Existing_Product_Count > 0)
                    {
                        // Produkt już istnieje w bazie danych, wyświetlenie komunikatu o błędzie
                        lblError.Text = "Produkt o podanej nazwie już istnieje w bazie danych";
                        return;
                    }

                    // Dodawanie produktu do bazy danych
                    string Add_New_Product = "INSERT INTO Towar (Nazwa, ilosc, cena, dodane_przez) VALUES ('" + Product_Name + "', " + Quantity + ", " + Product_Price + ", '" + Who_Added + "');";
                    SqlCommand Cmd_Add_New_Product = new SqlCommand(Add_New_Product, con);
                    Cmd_Add_New_Product.ExecuteNonQuery();
                }

                // Wyświetlenie komunikatu o powodzeniu operacji
                lblError.Text = "Dodano nowy produkt do bazy danych";
                Response.Redirect("magazyn.aspx");
            }
            catch (Exception ex)
            {
                // Wyświetlenie komunikatu o błędzie
                lblError.Text = "Wystąpił błąd podczas dodawania nowego produktu. Upewnij się, że podany produkt nie istnieje już w bazie danych lub podaj jego poprawną nazwę.";
            }




        }
    }
}