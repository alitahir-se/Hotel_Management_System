<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="try2.Admin.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
       <title>Admin Dashboard</title> 

        <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    
    

    

    <!-- Bootstrap core CSS -->
    <link href="bootstrap.min.css" rel="stylesheet">
        <link href="style.css" rel="stylesheet" />
    <!-- Custom styles for this template -->
    <link href="style_modal.css" rel="stylesheet" />

    </head>
    <body>
        <form runat="server">
<div class="d-flex flex-column flex-md-row align-items-center p-3 px-md-4 mb-3 bg-white border-bottom box-shadow">
      <h5 class="my-0 mr-md-auto font-weight-normal">HMS</h5>
      <nav class="my-2 my-md-0 mr-md-3">
        <a class="p-2 text-dark" href="#"></a>        
      </nav>
      <asp:Button type="button" runat="server" onClick="Unnamed_Click" class="btn btn-outline-primary"   Text="Sign Out" />
    </div>

    <div class="pricing-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">
      <h1 class="display-4">Admin Dashboard</h1>
    </div>
             <div class="center-align">
            <asp:Label CssClass="center red-text" ID="Label1" runat="server" Text=""></asp:Label>
          
            </div>
    <div class="container">
      <div class="card-deck mb-3 text-center">
        <div class="card mb-4 box-shadow">
          <div class="card-header">
            <h4 class="my-0 font-weight-normal">New Rooms</h4>
          </div>
          <div class="card-body">
           
            
            <button type="button" onclick="document.getElementById('id02').style.display='block'" class="btn btn-lg btn-block btn-primary">Add a Room</button>
          </div>
        </div>
        <div class="card mb-4 box-shadow">
          <div class="card-header">
            <h4 class="my-0 font-weight-normal">New Hall</h4>
          </div>
          <div class="card-body">
           
            
            <button type="button" class="btn btn-lg btn-block btn-primary" onclick="document.getElementById('id01').style.display='block'" >Add a Hall</button>
          </div>
        </div>
          <div class="card mb-4 box-shadow">
          <div class="card-header">
            <h4 class="my-0 font-weight-normal">New Department</h4>
          </div>
          <div class="card-body">
           
            
            <button type="button" onclick="document.getElementById('id03').style.display='block'" class="btn btn-lg btn-block btn-primary">Add a Department</button>
          </div>
        </div>
          <div class="card mb-4 box-shadow">
          <div class="card-header">
            <h4 class="my-0 font-weight-normal">New Menu Item</h4>
          </div>
          <div class="card-body">
           
            
            <button type="button" onclick="document.getElementById('id04').style.display='block'" class="btn btn-lg btn-block btn-primary">Add New Item</button>
          </div>
        </div>

          <div class="card mb-4 box-shadow">
          <div class="card-header">
            <h4 class="my-0 font-weight-normal">New Offers</h4>
          </div>
          <div class="card-body">
           
            
            <a  href="../Offers/offers.aspx" target="_blank" class="btn btn-lg btn-block btn-primary">Add Offer</a>
          </div>
        </div>

          <div class="card mb-4 box-shadow">
          <div class="card-header">
            <h4 class="my-0 font-weight-normal">Customer Info</h4>
          </div>
          <div class="card-body">
           
            
            <a  runat="server" href="~/ShowCustomerInfo/showcustomerinfo.aspx" class="btn btn-lg btn-block btn-primary" target="_blank">View Customer Info</a>
          </div>
        </div>
          
        <div class="card mb-4 box-shadow">
          <div class="card-header">
            <h4 class="my-0 font-weight-normal">Feedback</h4>
          </div>
          <div class="card-body">
                    <a  runat="server" href="~/ShowFeedback/showfeedback.aspx" class="btn btn-lg btn-block btn-primary" target="_blank">View Feedback</a>
            
          </div>
        </div>
      </div>
        
           
            
           <!---modal add a hall---->
           <div id="id01" class="modal">

        <div class="modal-content animate" runat="server">
            <div class="container">
                <span onclick="document.getElementById('id01').style.display='none'" class="close" title="Close Login Form">&times;</span>
                <h2  style="text-align:center;"><b>Add New Hall</b></h2>
            </div>
            <div class="imgcontainer">

                <img src="https://cdn.meetingsbooker.com/images/venues/Sheffield-City-Hall-2.jpg" alt="Hotel Pic" class="avatar"/>
            </div>

            <div class="container">
             
                <label for="Category"><b>Category</b></label>
                <br/> 
                   <asp:DropDownList ID="DropDownList1" CssClass="DropDownList" runat="server" >
               
                <asp:ListItem Text="Economy" Value="economy"></asp:ListItem>
                <asp:ListItem Text="Premium Suit" Value="premium"></asp:ListItem>
                <asp:ListItem Text="Royal Suit" Value="royal"></asp:ListItem>
                 
                </asp:DropDownList>
                <asp:CustomValidator 
                
                ID="CustomValidator1" runat="server" 
                ErrorMessage="" ControlToValidate="DropDownList1" 
                ForeColor="Red"
                OnServerValidate="CustomValidatorSelect_ServerValidate">

              </asp:CustomValidator>
               <label ><b>Status</b></label>
      <input type="text" id="stat12" runat="server" value="available" placeholder="Available"  readonly/>


                  
                <asp:Button type="button" ID="Button1" CssClass="btn btn-primary" OnClick="add_halls" runat="server" Text="Add Hall" />
               
            </div>

            
                <button type="button" onclick="document.getElementById('id01').style.display='none'" class="btn btn-danger">Cancel</button>
              
            
        </div>
</div><!---end modal add a hall-->


         <div id="id02" class="modal"><!---add room modal-->

        <div class="modal-content animate" runat="server">
            <div class="container">
                <span onclick="document.getElementById('id02').style.display='none'" class="close" title="Close Login Form">&times;</span>
                <h2  style="text-align:center;"><b>Add New Room</b></h2>
            </div>
            <div class="imgcontainer">

                <img src="https://room-matehotels.com/images/img/general/slide_inicio/slide_01.jpg" alt="Hotel Pic" class="avatar"/>
            </div>

            <div class="container">
             
                <label for="Category"><b>Category</b></label>
                <br/> 
                   <asp:DropDownList ID="DropDownList2" CssClass="DropDownList" runat="server" >
               
                <asp:ListItem Text="Economy" Value="economy"></asp:ListItem>
                <asp:ListItem Text="Premium Suit" Value="premium"></asp:ListItem>
                <asp:ListItem Text="Royal Suit" Value="royal"></asp:ListItem>
                 
                </asp:DropDownList>
                 <asp:CustomValidator 
                
                ID="CustomValidator2" runat="server" 
                ErrorMessage="" ControlToValidate="DropDownList2" 
                ForeColor="Red"
                OnServerValidate="CustomValidatorSelect_ServerValidate">

              </asp:CustomValidator>
               <label ><b>Status</b></label>
      <input type="text" value="available" id="Text1" placeholder="Available" runat="server"  readonly/>
                <asp:Button type="button" ID="Button2" CssClass="btn btn-primary" OnClick="add_rooms" runat="server" Text="Add room" />

                 
               
            </div>

            <div class="container" style="background-color:#f1f1f1">
                <button type="button" onclick="document.getElementById('id02').style.display='none'" class="btn btn-danger">Cancel</button>
              
            </div>
        </div>
    </div><!---add room modal end--->

         <div id="id03" class="modal">
        <div class="modal-content animate" runat="server"> <!--- add a department modal--->
            <div class="container">
                <span onclick="document.getElementById('id03').style.display='none'" class="close" title="Close Login Form">&times;</span>
                <h2  style="text-align:center;"><b>Add New Department</b></h2>
            </div>
            <div class="imgcontainer">

                <img src="http://www.socializer.me/wp-content/uploads/2014/05/social-group.jpg" alt="Department Pic" class="avatar"/>
            </div>

             <asp:CustomValidator
                ID="CustomValidatorFirstName" runat="server" 
                 ErrorMessage=" Name Cannot be empty or have numbers" 
                ControlToValidate="dep12"
                
                ForeColor="Red"
                OnServerValidate="CustomValidatorFirstName_ServerValidate"
                ValidateEmptyText="true"
                ClientValidationFunction="FirstNameValidation">

            </asp:CustomValidator>

            <div class="container">
             
                
               <label ><b>Name</b></label>
      <input type="text" id="dep12" runat="server"  placeholder="Enter Name of Department"  />


                <asp:Button type="button" ID="Button3" CssClass="btn btn-primary" runat="server" OnClick="add_departments" Text="Add Department" />
               
            </div>

            <div class="container" style="background-color:#f1f1f1">
                <button type="button" onclick="document.getElementById('id03').style.display='none'" class="btn btn-danger">Cancel</button>
              
            </div>
        </div>
    </div><!---add a department modal end--->




         <div id="id04" class="modal"><!---add new Menu item modal--->

        <div class="modal-content animate"  runat="server">
            <div class="container">
                <span onclick="document.getElementById('id04').style.display='none'" class="close" title="Close Login Form">&times;</span>
                <h2  style="text-align:center;"><b>Add New Menu</b></h2>
            </div>
            <div class="imgcontainer">

                <img src="https://image.freepik.com/free-vector/restaurant-menu-background-vector_23-2147489858.jpg" alt="Menu Logo" class="avatar"/>
            </div>


             <asp:CustomValidator
                ID="CustomValidator3" runat="server" 
                 ErrorMessage="Name Cannot be empty or have numbers" 
                ControlToValidate="name12"
                
                ForeColor="Red"
                OnServerValidate="CustomValidatorFirstName_ServerValidate"
               
                >

            </asp:CustomValidator>
            
            <div class="container">
             
                
               <label ><b>Name</b></label>
      <input type="text" id="name12" runat="server" placeholder="Enter Name of Item"  />
                
                 <asp:CustomValidator
                ID="CustomValidator4" runat="server" 
                 ErrorMessage=" Name Cannot be empty or have numbers" 
                ControlToValidate="price12"
                
                ForeColor="Red"
                OnServerValidate="CustomValidatorFirstName_ServerValidate"
                
                >

            </asp:CustomValidator>
                 <label ><b>Price</b></label>
      <input type="text" id="price12" runat="server" placeholder="Enter Price of Item in Rupees" />

                <asp:Button  type="button" ID="Button4" CssClass="btn btn-primary" runat="server" OnClick="add_items" Text="Add Menu" />
               
            </div>

            <div class="container" style="background-color:#f1f1f1">
                <button type="button" onclick="document.getElementById('id04').style.display='none'" class="btn btn-danger">Cancel</button>
              
            </div>
        </div>
    </div><!--Add new menu item end--->

       
          
      <footer class="pt-4 my-md-5 pt-md-5 border-top">
        <div class="row">
          <div class="col-12 col-md">
            <img class="mb-2" src="https://getbootstrap.com/assets/brand/bootstrap-solid.svg" alt="" width="24" height="24">
            <small class="d-block mb-3 text-muted">&copy; 2017-2018</small>
          </div>
          </div>
          
             
       
       
      </footer>
    </div>

        </form>     
 <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" ></script>
    <script>window.jQuery || document.write('<script src="jquery-slim.min.js"><\/script>')</script>
    <script src="popper.min.js"></script>
    <script src="bootstrap.min.js"></script>
    <script src="holder.min.js"></script>
<script src="script_modal.js"></script>

    <script>
      Holder.addTheme('thumb', {
        bg: '#55595c',
        fg: '#eceeef',
        text: 'Thumbnail'
      });
    </script>
    </body>
</html>
