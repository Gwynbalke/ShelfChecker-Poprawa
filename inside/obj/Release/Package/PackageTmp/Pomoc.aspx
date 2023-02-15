<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pomoc.aspx.cs" Inherits="projekt.WebForm7" %>

  <!-- Deklarowanie typu dokumentu i konfiguracji - HTML -->
  <!-- Konfiguracja przycisków, czcionek i tła -->

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Pomoc</title>
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
        #logo {
        height: 60%;
        width: 60%;
        top: 25vh;
        margin-left: 20%;

        bottom: 25vh;
        padding: 0;
        position: absolute;
       border: 5px solid #99683e;
      
       color: brown;
       font-family: Arial Black;
        
        border-radius:15px;
        opacity: 0.4
        
    }
    #logo_insnide{
       position: relative;
         top: 20px;
       color: #99683e;
       width: 70%;
       height: 100%;
    }
    #zdj{
        
        width: 50%;
        height: 80%;
        opacity: 0.4;
    }
    #lista{
        top: 200px;
        position: absolute;
        width: 40%;
        border: 1px solid black;
        background-color:rgba(0,0,0, 0.3);
        margin-left: 30px;
    }
    ul{
    font-weight: 700;
    font-size: 20px;
    }
    li{
                margin-left: 30px;
                font-weight: 300;
    }
    #instr{
        font-size: 30px;
        font-weight: 700;
    }
    #lista2{
        position: absolute;
        margin-left: 60%;
        top:200px; 
        background-color:rgba(0,0,0, 0.3);
        border: 1px solid black;
    }
    #lista2 center{
        font-size:30px;

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
    </style>
</head>

        <!-- Treść "pomocy" wyświetlana na stronie -->
        

<body>
    <form id="form1" runat="server">
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
            <asp:Button ID="logout_button" OnClick="Logout_Button_Click" Text="logout" class="button" runat="server" />   <br />
            <asp:Label ID="login_session" runat="server" Text=""></asp:Label>             
              
                
          </div>
        <div id="instrukcja">

        </div>
        <center>
        <div id="logo">
            <div id="logo_insnide">
                <img id="zdj" src="logo.png" />
                <h1>SHELF CHECKER</h1>      
           </div>
        </div>
    </center>
        
        <ol type="1" id="lista"><center id="instr">INSTRUKCJA</center>
    <li>
         <ul> Magazyn
           <li>Pozwala na wgląd w aktualny stan wszystkich dostępnych produktów na magazynie. Wyświetlana tabela pozwala zobaczyć konkretne ID produktu, jego nazwę, ilość, cenę, wartość (ilość * cena), a także przez kogo został dodany.</li>  
          <li>  Można w tej karcie również edytować wpisy danych produktów, aby to zrobić wystarczy podać nazwę produktu jaki chcemy zmienić, następnie mamy możliwość zmniejszenia lub zwiększenia jego ilości, a także zmienić aktualną cenę. Jest również możliwe dodanie nowego produktu podając jego cechy w analogiczny sposób. Wszystko za pośrednictwem wpisania danej wartości/nazwy, a następnie naciśnięcia przycisku z interesującą nas opcją.
            </li>  
         </ul>
    </li>
    <li>
        <ul>Towar
           <li>Zakładka dotycząca towaru działa analogicznie do zakładki „Magazyn” z tą różnicą, że odnosi się do aktualnego stanu w sklepie, a nie w magazynie.
           </li>          
        </ul>
    </li>
             <li>
        <ul>Użytkownicy
           <li>Daje wgląd w listę aktualnie zarejestrowanych użytkowników platformy. Możemy znaleźć tutaj dane usera takie jak imię, nazwisko, email, a także login.

           </li>          
        </ul>
    </li>
            <li>
        <ul>Pomoc
           <li>Bieżące okno służy do poinstruowania użytkownika co do możliwości aplikacji, a także jako instrukcja dotycząca danych możliwości.

           </li>          
        </ul>
    </li>

 </ol> 
        <ul id="lista2"><center>Program pozwala na</center><br />
    <li>sprawdzenie ilości konkretnego produktu w bazie danych </li>
    <li>dodawanie nowych produktów  </li>
    <li>odejmowanie/odejmowanie ilości produktów 
</li>
    <li>dodawanie wysyłki towaru </li>
            <li>sprawdzanie zawartości magazynu </li>
            <li>wyświetlanie aktualnej ceny towaru </li>
            <li>przeliczanie wartości danego produktu i całego magazynu</li>
 </ul> 
    </form>
</body>
</html>
