<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="try2.home.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HMS | Home</title>
     <!--Import Google Icon Font-->
      <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet"/>
      <!--Import materialize.css-->    
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.100.2/css/materialize.min.css"/>
    <link href="style.css" rel="stylesheet" />
  

      <!--Let browser know website is optimized for mobile-->
      <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
</head>
<body>
    
     <form id="form1" runat="server">

    <!-- Dropdown Structure -->
    <ul id="dropdown1" class="dropdown-content">
        <li><a href="../Application/application.aspx">Apply</a></li>
        <li><a class="modal-trigger" href="../Employee Login/employeeLogin.aspx">Employee Login</a></li>
         <li><a class="modal-trigger" href="../Admin Login/adminLogin.aspx">Admin Login</a></li>
        
        
    </ul>
    <div class="navbar-fixed">
        <nav>
            <div class="nav-wrapper white">
                <a href="#" class="brand-logo black-text darken-4">HMS</a>
                <ul class="right hide-on-med-and-down ">
                    <li><a class="black-text active light-grey">Home</a></li>
                    <li><a class="black-text" href="../RoomInfo/roomInfo.aspx">Rooms</a></li>
                    <li><a class="black-text" href="../Hallinfo/hallinfo.aspx">Halls</a></li>
                      <li><a class="black-text" href="../Menu Info/menuInfo.aspx">Dinning</a></li>
                    
                    
                    <!-- Dropdown Trigger -->
                    <li><a class="dropdown-button black-text" href="#!" data-activates="dropdown1">Careers<i class="material-icons right">arrow_drop_down</i></a></li>
                    <li><a class="black-text modal-trigger" href="../signup/signup.aspx">Sign Up</a></li> 
                    <li><a class="black-text modal-trigger" href="../login/login.aspx">Sign In</a></li>
                    
                     </ul>
            </div>

        </nav>

    </div>


    <div class="carousel carousel-slider center" >
        <div class="carousel-fixed-item center white-text">
             <h2 >The Lap of Luxury</h2>
                    <h5>You do your thing. Leave the rest to us</h5>
       
        </div>

         
       
    <a class="carousel-item" href="#one!"><img src="pic/img1.jpg"/></a>
    <a class="carousel-item" href="#two!"><img src="pic/img2.jpg"/></a>
    <a class="carousel-item" href="#three!"><img src="pic/img3.jpg"/></a>
    
  </div>
    <div class="row"></div>
   <div class="container row">
       <div class="col s12 offset-s1"><blockquote><span class="flow-text">“We see our customers as invited guests to a party, and we are the hosts. 
           It’s our job every day to make every important aspect of the customer experience a little bit better.“ Shahreyar Ali (CEO HMS)</span></blockquote></div>
    
   </div>

       

</form>
   
    <!--Import jQuery before materialize.js-->
     <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.100.2/js/materialize.min.js"></script>
 
     <!--Materializecss Slider-->
    <script src="script.js"></script>


 
    
</body>
</html>
