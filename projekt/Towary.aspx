<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Towary.aspx.cs" Inherits="projekt.WebForm6" %>

<!DOCTYPE html>

     <!-- Deklarowanie typu dokumentu i konfiguracji - HTML -->
     <!-- Konfiguracja przycisków, czcionek i tła -->

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Towary</title>
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
    left: 25%;
  width: 50%;
  border: 1px solid black;
}
#panel1{
  margin: 0px;

}
#Panel1 th{
  margin:0px;
  text-align: left;
  font-weight: 900;
  font-size: 15px;
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

}
    </style>
</head>
<body>
  
     <!-- Opcje menu: Magazyn, Towar, Użytkownicy, Pomoc -->

     <div id="menu"> 
            <h1>SHELF CHECKER</h1>
            <div id="menu_tekst">
                  <asp:Panel ID="Panel2"  runat="server">
                <a href="magazyn.aspx">Magazyn</a>
                <a href="towary.aspx">Towar</a>              
                <a href="Użytkownicy.aspx">Użytkownicy</a>
                <a href="pomoc.aspx">Pomoc</a>
                        </asp:Panel>
            </div>
            
        </div>
   
    <!-- Formularz strony, funkcja dodawania użytkownika, wylogowania oraz zawartość sesji i informacje o logowaniu -->

    <form id="form1" runat="server">
        <div id="logout">
            <asp:Button ID="logout_button" OnClick="Logout_Button_Click" Text="logout" class="button" runat="server" /><br />
            <asp:Label ID="login_session" runat="server" Text=""></asp:Label>             
                
                
          </div>
        <div>
            <asp:Panel ID="Panel1" runat="server"></asp:Panel>  

        </div>
    </form>
</body>
</html>
