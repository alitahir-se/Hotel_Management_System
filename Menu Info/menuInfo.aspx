<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menuInfo.aspx.cs" Inherits="try2.Menu_Info.menuInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet"/>
      <!--Import materialize.css-->
      <link type="text/css" rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.100.2/css/materialize.min.css"  media="screen,projection"/>
    <link href="style.css" rel="stylesheet" />


<style>
.mySlides {display:none;}

.food{
  width:100%;
  height: 40%;
}

</style>
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
                    <li><a href="../home/home.aspx" class="black-text active light-grey">Home</a></li>
                    <li><a class="black-text" href="../RoomInfo/roomInfo.aspx">Rooms</a></li>
                    <li><a class="black-text"href="../Hallinfo/hallinfo.aspx">Halls</a></li>
                      <li><a class="black-text" href="#">Dinning</a></li>
                    
                    
                    <!-- Dropdown Trigger -->
                    <li><a class="dropdown-button black-text" href="#!" data-activates="dropdown1">Careers<i class="material-icons right">arrow_drop_down</i></a></li>
                    <li><a class="black-text modal-trigger" href="../signup/signup.aspx">Sign Up</a></li> 
                    <li><a class="black-text modal-trigger" href="../login/login.aspx">Sign In</a></li>
                    
                     </ul>
            </div>

        </nav>

    </div>


    <div>
    <div class="w3-container">
 <div class="w3-container w3-teal">
  <h1 style="text-align: center">Our Foods Our Culture</h1>
</div>
  <p style="text-align: center">Eat , drink and be merry.....</p>
</div>

<div class="w3-content w3-section" style="max-width:1000px">
  <img class="mySlides" src="https://cdn.cheapism.com/images/090617_breakfast_food_calories_slide_0_fs.max-784x410.jpg" style="width:100%" height="40%">
  <img class="mySlides" src="https://cdn.cheapism.com/images/090617_breakfast_food_calories_slide_33_fs.max-784x410.jpg" style="width:100%" height="40%">
  <img class="mySlides" src="https://cdn.cheapism.com/images/090617_breakfast_food_calories_slide_27_fs.max-784x410.jpg"  style="width:100%" height="40%">
  <img  class="mySlides" src="https://cdn.cheapism.com/images/090617_breakfast_food_calories_slide_38_fs.max-784x410.jpg" style="width:100%" height="40%">
</div>
<br> <br> <br>
<div class="w3-container w3-teal">
  <h1>Delicious..........</h1>
</div>

<div class="w3-row-padding w3-margin-top">
  <div class="w3-third">
    <div class="w3-card">
      <img class="food" src="https://cdn.cheapism.com/images/090617_breakfast_food_calories_slide_0_fs.max-784x410.jpg" style="width:100%" height="40%">
      <div class="w3-container">
        <h5>Desi Breakfast</h5>
      </div>
    </div>
  </div>

  <div class="w3-third">
    <div class="w3-card">
      <img class="food" src="https://cdn.cheapism.com/images/090617_breakfast_food_calories_slide_12_fs.max-784x410.jpg" style="width:100%" height="40%">
      <div class="w3-container">
        <h5>Desi Lunch</h5>
      </div>
    </div>
  </div>

  <div class="w3-third">
    <div class="w3-card">
      <img class="food" src="https://cdn.cheapism.com/images/090617_breakfast_food_calories_slide_33_fs.max-784x410.jpg" style="width:100%" height="40%">
      <div class="w3-container">
        <h5>Desi Dinner</h5>
      </div>
    </div>
  </div>
</div>

<div class="w3-row-padding w3-margin-top">
  <div class="w3-third">
    <div class="w3-card">
      <img class="food" src="https://cdn.cheapism.com/images/090617_breakfast_food_calories_slide_29_fs.max-784x410.jpg" style="width:100%" height="40%">
      <div class="w3-container">
        <h5>Fast Food</h5>
      </div>
    </div>
  </div>

  <div class="w3-third">
    <div class="w3-card">
      <img class="food" src="https://cdn.cheapism.com/images/090617_breakfast_food_calories_slide_35_fs.max-784x410.jpg" style="width:100%" height="40%">
      <div class="w3-container">
        <h5>Our Special Burgers</h5>
      </div>
    </div>
  </div>

  <div class="w3-third">
    <div class="w3-card">
      <img class="food" src="https://cdn.cheapism.com/images/090617_breakfast_food_calories_slide_38_fs.max-784x410.jpg" style="width:100%" height="40%">
      <div class="w3-container">
        <h5>Our Special Pizza</h5>
      </div>
    </div>
  </div>
</div>

        <br /><br /><h5>Menu Items</h5>
        <asp:GridView class="striped responsive-table " ID="menuGrid" runat="server"></asp:GridView>
       

    </div>
    </form>

     <script type="text/javascript" src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
      <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.100.2/js/materialize.min.js"></script>
 


    <script>
var myIndex = 0;
carousel();

function carousel() {
    var i;
    var x = document.getElementsByClassName("mySlides");
    for (i = 0; i < x.length; i++) {
       x[i].style.display = "none";  
    }
    myIndex++;
    if (myIndex > x.length) {myIndex = 1}    
    x[myIndex-1].style.display = "block";  
    setTimeout(carousel, 2000); // Change image every 2 seconds
}
</script>

</body>
</html>
