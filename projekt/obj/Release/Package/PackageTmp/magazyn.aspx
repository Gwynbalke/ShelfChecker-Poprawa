<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="magazyn.aspx.cs" Inherits="projekt.WebForm3" %>

  <!-- Deklarowanie typu dokumentu i konfiguracji - HTML -->
  <!-- Konfiguracja przycisków, czcionek i tła - magazyn site -->

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Magazyn</title>
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
      #formularz{
        position:absolute;
        display: grid;
       text-align: center;
       justify-content: center;
        width: 25%;
        height: 40%;
        float: left;
        left: 10%;
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
h1{
  font-size: 30px;
  color: #fff;
  text-transform: uppercase;
  font-weight: 700;
  text-align: center;
  margin-bottom: 15px;
}
#Panel1 table{
   background-color:rgba(192,192,192, 0.2);
  position: absolute;
  overflow-x:auto;
  margin-top: 0px;
  top: 200px;
    left: 40%;
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

#Panel1 td{ 
  border: 1px solid black;

}

/* demo styles */
@import url(https://fonts.googleapis.com/css?family=Roboto:400,500,300,700);
section{
  margin: 50px;
}
/* for custom scrollbar for webkit browser*/
::-webkit-scrollbar {
    width: 6px;
} 
::-webkit-scrollbar-track {
    -webkit-box-shadow: inset 0 0 6px rgba(0,0,0,0.3); 
} 
::-webkit-scrollbar-thumb {
    -webkit-box-shadow: inset 0 0 6px rgba(0,0,0,0.3); 
}
    #dodanie {
              position: absolute;
              left: 10%;
              top: 65%;
              display: grid;
              border-bottom: 2px solid black;
              width: 25%;
                  border: 1px solid black;
        margin:0;
        margin: 5px;
        background-color: rgba(0,0,0, 0.3);
        font-weight: 700;
        min-height: 250px;
    }
    #formularz table{
        position:absolute;
       width: 70%;
       left: 15%;
        top: 30px;
     
        text-align:center;
    }
    #formularz td {
       
        display: grid;
        justify-content: center;
        width: 80%;
        text-align: center;
        align-content: center;
        width: 100%;
    }
 
   
    .btn{
        background-color:rgba(192,192,192, 0.5);
        border: none;
        border-radius: 3px;
        margin-top: 10px;
        padding: 5px 0px;
        border: 1px solid black;
    }
        .form-text {
            font-family: inherit;
            border: 0;
            border-bottom: 2px solid white;
            outline: 0;
            color: white;
            background: transparent;
            transition: border-color 0.2s;
            text-align: center;
        }

        #nazwa_towaru_text{
              font-family: inherit;
            border: 0;
            border-bottom: 2px solid white;
            outline: 0;
            color: white;
            background: transparent;
            transition: border-color 0.2s;
            text-align: center;
           justify-content: center;
           margin-left: 25%;
           width:170px;
            
}
            #nazwa_towaru_text:focus {
                 border-bottom: 2px solid black;
       opacity: 1;
        transition: border-color 0.5s;
            }

    .form-text:focus {
       border-bottom: 2px solid black;
       opacity: 1;
        transition: border-color 0.5s;
    }
    #dodanie .form-text{
      
        
        width: 50%;
       margin-left: 25%;
    }
 
</style>

  
</head>
<body>
    

    <!-- Forma strony, opcje dodawania/edycji produktów oraz zawartość sesji i informacje o logowaniu -->

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
      
             <asp:Button ID="logout_button" OnClick="Logout_Button_Click" Text="logout" class="button" runat="server" /><br />
                 <asp:Label ID="login_session" runat="server" Text="Label"></asp:Label>
                </div>
        <asp:Panel ID="Panel1" runat="server"></asp:Panel> 
       
            <div id="formularz">

             <table border="0">

               <tr border="0"><td>
                    Podaj nazwę produktu, który chcesz edytować<br/>
                    <asp:TextBox  type="text" CssClass="form-form" ID="Product_Name_Text"   placeholder="podaj nazwe" runat="server" /><br />
                   </td></tr> <tr border="0"><td>
                        Zmień ilość produktu<br />
                     <asp:TextBox  type="text" CssClass="form-text" ID="Enter_Quanity_Text"   placeholder="podaj ilość" runat="server" /><br />
                    <asp:Button ID="Subtract_Product_Button" OnClick="Subtract_Product_Button_Click" Text="Odejmij" class="btn" runat="server" />
                    <asp:Button ID="dodaj_button" OnClick="Add_Product_Button_Click" Text="Dodaj" class="btn" runat="server" /><br />
                
                  </td>
                   <td>
                        Zmień cenę towaru
                        <asp:TextBox  type="text" CssClass="form-text" ID="Product_Quanity_Text"   placeholder="podaj  cenę" runat="server" /><br/>
                        <asp:Button ID="zmien_cene_towaru" OnClick="Change_Product_Price_Click" Text="Zmień" class="btn" runat="server" />
                   </td>
                 </tr> 
                
                </table> 
                <asp:Label ID="lblError2" Text="" runat="server"></asp:Label>
             </div>
       
                <div id="dodanie">          
                    <center><label for="cena_towaru_text">Dodaj nowy produkt</label></center>  
                    <asp:TextBox  type="text" CssClass="form-text" ID="New_Product_Name"   placeholder="podaj nazwę" runat="server" />
                    <asp:TextBox  type="text" CssClass="form-text" ID="New_Product_Quanity"   placeholder="podaj ilość" runat="server" />
                    <asp:TextBox  type="text" CssClass="form-text" ID="New_Product_Price"   placeholder="podaj cenę" runat="server" />
                    <asp:Button ID="dodaj_nowy_button" OnClick="Add_New_Product_Click" Text="Dodaj nowy produkt" class="btn" runat="server" />
                    <asp:Label ID="lblError" Text="" runat="server"></asp:Label>
               </div>
      
    </form>
</body>
</html>
