<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="projekt.WebForm1" %>


  <!-- Deklarowanie typu dokumentu i konfiguracji - HTML -->
  <!-- Konfiguracja przycisków, czcionek i tła - main site-->

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Strona główna</title>

    <style>
   *{
  margin: 0;
  padding: 0;
  box-sizing: border-box;
  text-decoration: none;
  font-family: 'Poppins', sans-serif;
}
   #menu{
  background-color: #99683e;
  position: fixed;
  width: 100%;
  color: white;
}
#menu_tekst{
  position: relative;
  display: flex;
  margin: 0 auto;
  height: 70px;
  align-items: center;
  justify-content: space-between;
  left: 150px;
  width: 40%;
 font-weight:700;

}
#menu h1{
    width: 275px;
    position: absolute;
    top: 20%;
    margin-left: 60px;
    
}

    body{
     background-color: rgb(252, 244, 219);
     margin: 0;
    }
    #logout {
        position: absolute;
        right: 0;
        display: block;
        float: right;
        top:0;
        color: white;
    }
    #form3 {

    }

    #logo {
        height: 50%;
        width: 50%;
        top: 25vh;
        left: 25%;

        bottom: 25vh;
        padding: 0;
        position: absolute;
       border: 5px solid #99683e;
      
       color: brown;
       font-family: Arial Black;
        
        border-radius:15px;
        
    }
    #logo_insnide{
       position: relative;
       top: 20%;    
       color: #99683e;
    }
    a {
       
        color: white;
        text-decoration: none;
    }
    a:hover{
        color: #99683e;
        background-color: rgb(252, 244, 219);
        transition: 0.5s;
        border-radius: 5px;
        border: none;
    }
    .button{
        background-color: rgb(252, 244, 219);
        padding: 0;
        border: none;
        padding:  5px 10px;
        border-radius: 7px;
    }
    .button:hover {
        padding: 6px 11px;
        cursor: pointer;
        transition: 0.5s;
        font-weight: 900;
    }

</style>
    
</head>

    <!-- Forma strony, opcje dodawania/edycji produktów oraz zawartość sesji i informacje o logowaniu -->
    <!-- Opcję menu: Magazyn, Towar, Użytkownicy, Pomoc -->

<body>
    <form id="form3" runat="server">
        <div id="menu"> 
            <h1>SHELF CHECKER</h1>
            <div id="menu_tekst">
                <a href="magazyn.aspx">Magazyn</a>
                <a href="towary.aspx">Towar</a>
                <a href="Użytkownicy.aspx">Użytkownicy</a>
                <a href="pomoc.aspx">Pomoc</a>
            </div>
        </div>
          <div id="logout">
                <asp:Panel ID="Panel1"  runat="server"></asp:Panel>
                <asp:Label ID="login_session" runat="server" Text="Label"></asp:Label>             
                <br />
                <asp:Button ID="logout_button" OnClick="Logout_Button_Click" Text="logout" class="button" runat="server" />
                <asp:Label ID="lblError" cssID="logout" Text=""  class="logout" CssClass="logout" runat="server"></asp:Label>
            </div>
        
       
    </form>
    <center>
        <div id="logo">
            <div id="logo_insnide">
                <img src="logo.png" />
                <h1>SHELF CHECKER</h1>      
           </div>
        </div>
    </center>
    <div class="pixels"></div>
</body>
</html>
