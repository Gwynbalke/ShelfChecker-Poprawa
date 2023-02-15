<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="projekt.login" %>

  <!-- Deklarowanie typu dokumentu i konfiguracji - HTML -->
  <!-- Konfiguracja przycisków, czcionek i tła - login site -->

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Strona logowania</title>
  <style>
     p{
         
      }
      img {
          height: 70px;
         width: 70px;
         margin-left: 50px;
         margin-top: 5px;
      }
      body{
             background-color: rgb(252, 244, 219);
     margin: 0;
      }
      #login{
        position:absolute;
        display: grid;
       text-align: center;
       justify-content: center;
        width: 30%;
        height: 40%;
        float: left;
        left: 35%;
        top: 20%;
        overflow:inherit;
        border: 1px solid black;
        margin:0;
        margin: 5px;
        background-color: rgba(0,0,0, 0.3);
        font-weight: 700;
        min-height: 300px;
        min-width: 300px;

      }
      #menu_tekst{
  position: relative;
  display: flex;
  margin: 0 auto;
  height: 70px;
  align-items: center;
  justify-content: space-between;
  left: 10%;
  width: 40%;
 color: white;
 position: absolute;
 top: 10px;
 font-size: 25px;
 font-weight: 900;

}
       #menu{
  background-color: #99683e;
  position: fixed;
  width: 100%;
  color: white;
  height: 100px;
}
       #menu_tekst a{
           text-decoration: none;
           color: white;
           margin-left: 15%;

       }
       #menu_tekst  a:hover{
            background-color: rgb(252, 244, 219);
           transition: 1s;
           color: #99683e;
           border-radius: 5px;
       }
       input {
           margin-right: 10px;

       }
  </style>
</head>

    <!-- Ekran logowania wraz z jego konfiguracją -->

<body>
  <div id="menu">
    <img src="logo.png" />
    <div id="menu_tekst">
      <p>SHELF CHECKER</p>
      <a href="Towary.aspx">Dostępność towaru</a>
    </div>
  </div>
  <div id="login">
    <form id="form1" runat="server">
      <div>
        <asp:Panel ID="Panel1" runat="server"></asp:Panel>
      </div>
      <h3>Login</h3>
      <div class="userLogin">
        Nazwa użytkownika<br />
        <asp:TextBox ID="txtUserID" AutoComplete="off" runat="server" placeholder="User" OnTextChanged="txtUserId_TextChanged"></asp:TextBox>
        <br />
        Hasło <br />
        <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" placeholder="Password" runat="server"></asp:TextBox>
        <br />
        <asp:Button type="button" CssClass="button" ID="btnLogin" runat="server" Text="Zaloguj" OnClick="btnLogin_Click"  /><br />
        <asp:Label ID="lblError" Text="" runat="server"></asp:Label>
      </div> 
      <div>
      </div>
    </form>
  </div>
</body>
</html>