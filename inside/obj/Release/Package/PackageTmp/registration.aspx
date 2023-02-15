<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="projekt.WebForm2" %>


    <!-- Deklarowanie typu dokumentu i konfiguracji - HTML -->

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <title>rejestracja</title>
  <link rel="stylesheet" href="style.css" type="text/css" />
  <style>
  </style>
</head>
<body>
  <form id="form2" runat="server">
    <center>
      <div class="form_registration">
        <label for="input_email">Email</label>
        <asp:TextBox ID="txtEmail" type="email" class="form-email" placeholder="email" runat="server" />
      </div>
      <div class="dodaj">
    Dodaj nowego użytkownika
  </div>
  <label for="input_login" class="">Login</label>
  <asp:TextBox type="text" CssClass="form-control" ID="txtUser_Id" placeholder="login" runat="server" />

  <label for="inputPassword" class="form-label">Hasło</label>
  <div class="" id="show_hide_password">
    <asp:TextBox type="password" class="" ID="txtPassword" placeholder="password" runat="server" />
  </div>

  <asp:Button ID="registration_button" OnClick="registration_button_Click" Text="Sign up" class="btn" runat="server" />
  <asp:Label ID="lblError" Text="" runat="server"></asp:Label>

  <label for="input_name" class="">Imię</label>
  <asp:TextBox type="text" CssClass="form-control" ID="input_name" placeholder="imie" runat="server" />

  <label for="input_login" class="">Nazwisko</label>
  <asp:TextBox type="text" CssClass="form-control" ID="input_surname" placeholder="nazwisko" runat="server" />
    </center>
        </form>
    </body>
</html>