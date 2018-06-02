<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerInfo.aspx.cs" Inherits="try2.CustomerInfo.CustomerInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up</title>
     <!--Import Google Icon Font-->
      <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet"/>
      <!--Import materialize.css-->
      <link type="text/css" rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.100.2/css/materialize.min.css"  media="screen,projection"/>
    <link href="style.css" rel="stylesheet" />
  

      <!--Let browser know website is optimized for mobile-->
      <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
</head>
<body>
    <form id="form1" runat="server">
    <!-- Dropdown Structure -->
    <ul id="dropdown1" class="dropdown-content">
        <li><a href="#">Apply</a></li>
        <li><a class="modal-trigger" href="#">Employee Login</a></li>
        <li><a class="modal-trigger" href="#">Admin Login</a></li>
        <li class="divider"></li>
        
    </ul>
    


    
    <br /><br /><br /><br />

     <div class="row">
    <div class="col s12">
       
      <div class="row">
          <div class="col s1"> </div>
        <div class="input-field col s5">
          <i class="material-icons prefix">account_circle</i>
          <input runat="server" disabled id="first_name" type="text" class="validate text-darken-4" maxlength="30">
          <label for="icon_prefix">First Name</label>
            <span class="helper-text" data-error="wrong" data-success="right"></span>

            
           
        </div>
          
          <div class="input-field col s5">
          <i class="material-icons prefix">account_circle</i>
         <input id="last_name" runat="server" disabled type="text" class="validate text-darken-4" maxlength="30">
          <label for="last_name">Last Name</label>
              <span class="helper-text" data-error="wrong" data-success="right"></span>
              
        </div>
         

        </div> 
        <div class="row"> 
          <div class="col s1"> </div>
          <div class="input-field col s5">
              
              <i class="material-icons prefix">info</i>
            <input runat="server" disabled id="cnic" class="text-darken-4" type="text" data-length="15">
            <label for="input_text">CNIC</label>
               
          </div>
          <div class="input-field col s5">
          <i class="material-icons prefix">phone</i>
          <input runat="server" id="phone" disabled type="tel" class="validate text-darken-4" maxlength="11" data-length="11">
          <label for="contact_phone">Phone</label>
              
        </div>
          
          </div> 
        <div class="row"> 
            <div class="col s1"> </div>
        

            <div class="input-field col s5">
               <i class="material-icons prefix">email</i>
          <input runat="server"  id="email" disabled type="email" class="validate text-darken-4">
          <label for="email">Email</label>
                
        </div>
            <div class="input-field col s5">
                 <i class="material-icons prefix">info</i>
          <input runat="server"  id="privledge" disabled type="text" class="validate text-darken-4" maxlength="20" data-length="20">
           <label for="input_text">Privledge</label>
                
               
        </div>
         </div> 

        <div class="row">
            <div class="col s1"> </div>
            <div class="input-field col s5">
          <i class="material-icons prefix">home</i>
          <input runat="server" disabled id="address" type="text" class="validate text-darken-4" maxlength="50">
          <label for="icon_prefix">Address</label>
               
        </div>

            <div class="input-field col s5">
          <i class="material-icons prefix">location_city</i>
          <input runat="server" disabled  id="city" type="text" class="validate text-darken-4" maxlength="30">
          <label for="icon_prefix">City</label>
                  
        </div>

        </div>
      
    
            
    </div>
  </div>
    
        </form>

      <!--Import jQuery before materialize.js-->
     <script type="text/javascript" src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
      <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.100.2/js/materialize.min.js"></script>
 
     <!--Materializecss Slider-->
    <script src="script.js" type="text/javascript" ></script>
</body>
</html>