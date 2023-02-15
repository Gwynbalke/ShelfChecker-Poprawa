<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Użytkownicy.aspx.cs" Inherits="projekt.WebForm5" %>

  <!-- Deklarowanie typu dokumentu i konfiguracji - HTML -->
  <!-- Konfiguracja przycisków, czcionek i tła -->
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Użytkownicy</title>
    <style>
               .btn{
    cursor: pointer;
}
.btn:hover{
    font-weight:700;
    font-size:105%;
    transition: 0.5s;
}
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
  display: flex;
  align-items: center;
  justify-content: space-around;
  left: 150px;
  width: 80%;
 font-weight:700;
 color: white;
 
}

#Panel2{
    width: 80%;
    display: flex;
    justify-content: space-around;
}
#menu h1{
    width: 275px;
    position: absolute;
    top: 20%;
    margin-left: 60px;
    color: white;
}

    body{
     background-color: rgb(252, 244, 219);
     margin: 0;
    }
    a{
        text-decoration: none;
        color: white;
        font-size: 20px;
        font-weight: 700;
    }
    a:hover{
        color: #99683e;
        background-color: rgb(252, 244, 219);
        transition: 0.5s;
        border-radius: 5px;
        border: none;
    }
  
    #Panel1 table{
   background-color:rgba(192,192,192, 0.2);
  position: absolute;
  overflow-x:auto;
  margin-top: 0px;
  top: 200px;
    left: 45%;
  width: 40%;
  border: 1px solid black;
}

#Panel1 th{
  margin:0px;
  text-align: left;
  font-weight: 900;
  font-size: 20px;
  color: black;
  text-transform: uppercase;
 border: 0.5px solid black;
 margin: 0px;   
 background-color: rgba(0,0,0, 0.3);
 text-align: center; 

}
 #Panel1  tr {
  text-align: left;
  vertical-align:middle;
  font-weight: 300;
  font-size: 20px;
  color: black; 
  text-align: center; 
  padding:0;
  font-weight: 300;
}
  #logout {
        position: absolute;
        right: 0;
        display: block;
        float: right;
        top:0;
        color: white;

    }
  #logout_button{
      border-radius:5px;
      border: none;
      cursor: pointer;
      padding: 5px;
  }

  button:hover{
      cursor: pointer;
  }
#Panel1 td{ 
  border: 1px solid black;
  font-weight: 300;
  font-size: 20px;
  background-color: rgba(0,0,0, 0.3);

}
.form_registration{
 
       position: absolute;
       top: 200px;
       background-color: rgba(0,0,0, 0.3);
       width: 30%;
       height: 30%;
       text-align: center;
       margin-left: 10%;
       border: 1px solid black;
       justify-content: center;
  
}
#registration{
    position : absolute;
    justify-content: center;
    width: 100%;
       position: absolute;
  
    display: grid;
}
.dodaj{
    color: black;
    font-size: 30px;
    position: absolute;
    top: 160px;
    margin-left:  15%;
    font-weight: 700;
}


    </style>
</head>
<body>
            <!-- Div container dla menu -->
    <div id="menu">
        <h1>SHELF CHECKER</h1>
        <div id="menu_tekst">

            <!-- Opcje menu: Magazyn, Towar, Użytkownicy, Pomoc -->

            <a href="magazyn.aspx">Magazyn</a>
            <a href="towary.aspx">Towar</a>
            <a href="Użytkownicy.aspx">Użytkownicy</a>
            <a href="pomoc.aspx">Pomoc</a>
        </div>
    </div>

            <!-- Formularz strony, funkcja dodawania użytkownika, wylogowania oraz zawartość sesji i informacje o logowaniu -->

    <form id="form1" runat="server">
        <div class="dodaj">
            Dodaj nowego użytkownika
        </div>
        <div id="logout">
            <asp:Button ID="logout_button" OnClick="Logout_Button_Click" Text="logout" class="btn" runat="server" />
            <br />
            <asp:Label ID="login_session" runat="server" Text="Label"></asp:Label>
        </div>
        <asp:Panel ID="Panel1" runat="server"></asp:Panel>
        <div class="form_registration">
            <div id="registration">
                Email<br />
                <asp:TextBox ID="Email_Text" type="email" class="form-email" placeholder="email" runat="server" /><br />
                Login<br />
                <asp:TextBox type="text" CssClass="form-control" ID="UserID_Text" placeholder="login" runat="server" /><br />
                Hasło<br />
                <asp:TextBox type="password" class="" ID="Password_Text" placeholder="password" runat="server" />
                Imię<br />
                <asp:TextBox type="text" CssClass="form-control" ID="Input_Name" placeholder="imie" runat="server" />
                Nazwisko
                <asp:TextBox type="text" CssClass="form-control" ID="Input_Surname" placeholder="nazwisko" runat="server" /><br />
                <asp:Button ID="registration_button" OnClick="registration_button_Click" Text="Sign up" class="btn" runat="server" />
                <asp:Label ID="lblError" Text="" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
