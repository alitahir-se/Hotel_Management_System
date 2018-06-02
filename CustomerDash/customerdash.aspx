<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="customerdash.aspx.cs" Inherits="try2.CustomerDash.customerdash" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    
   
    <!-- Bootstrap core CSS -->
    <link href="bootstrap.min.css" rel="stylesheet">
    <link href="../Admin/style.css" rel="stylesheet" />
    
    <link href="../Admin/style_modal.css" rel="stylesheet" />

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
      <h1 class="display-4">Customer Dashboard</h1>
    </div>
      
          <div class="center-align">
            <asp:Label class="center red-text" ID="Label1" runat="server" Text=""></asp:Label>
          
            </div>
        
              
    <div class="container">
      <div class="card-deck mb-3 text-center">
        <div class="card mb-4 box-shadow">
          <div class="card-header">
            <h4 class="my-0 font-weight-normal">Room Booking</h4>
          </div>
          <div class="card-body">
           
            
            <button type="button" onclick="document.getElementById('id01').style.display='block'" class="btn btn-lg btn-block btn-primary">Book a Room</button>
          </div>
        </div>
        <div class="card mb-4 box-shadow">
          <div class="card-header">
            <h4 class="my-0 font-weight-normal">Hall Booking</h4>
          </div>
          <div class="card-body">
           
            
            <button type="button" class="btn btn-lg btn-block btn-primary" onclick="document.getElementById('id02').style.display='block'" >Book a Hall</button>
          </div>
        </div>
          <div class="card mb-4 box-shadow">
          <div class="card-header">
            <h4 class="my-0 font-weight-normal">My Info</h4>
          </div>
          <div class="card-body">
           
            
            <a target="_blank" href="../CustomerInfo/CustomerInfo.aspx"  class="btn btn-lg btn-block btn-primary">View My Info</a>
          </div>
        </div>
          <div class="card mb-4 box-shadow">
          <div class="card-header">
            <h4 class="my-0 font-weight-normal">Feedback</h4>
          </div>
          <div class="card-body">
           
             <button type="button" class="btn btn-lg btn-block btn-primary" onclick="document.getElementById('id03').style.display='block'" >Give Feedback</button>
           
          </div>
        </div>
          
          
          
        
      </div>


        <div id="id01" class="modal"><!--book a room modal-->

        <div class="modal-content animate"  runat="server">
            <div class="container">
                <span onclick="document.getElementById('id01').style.display='none'" class="close" title="Close Login Form">&times;</span>
                <h2  style="text-align:center;"><b>Book a Room</b></h2>
            </div>
            <div class="imgcontainer">

                <img src="https://room-matehotels.com/images/img/general/slide_inicio/slide_01.jpg" alt="Hotel Pic" class="avatar"/>
            </div>


             <asp:CustomValidator 
                
                ID="CustomValidator7" runat="server" 
                ErrorMessage="" ControlToValidate="chko" 
                ForeColor="Red"
                OnServerValidate="CustomValidatorDate_ServerValidate">

              </asp:CustomValidator>

             <asp:CustomValidator 
                
                ID="CustomValidator8" runat="server" 
                ErrorMessage="" ControlToValidate="chki" 
                ForeColor="Red"
                OnServerValidate="CustomValidatorDate_ServerValidate">

              </asp:CustomValidator>

            <div class="container">
               <label for="Check IN"><b>Check In</b></label>
                <br/> 
                <input type="date" id="chki" runat="server" class="DropDownList"  />
                <br/> 
                <label for="Check Out"><b>Check Out</b ></label>
                <br/> 
                <input type="date" id="chko" runat="server" class="DropDownList" />
                <br/> 
                <label for="Category"><b>Category</b></label>
                <br/>  <!--  <asp:ListItem Text="Select" Value=""></asp:ListItem> -->
                <asp:DropDownList ID="DropDownList1" CssClass="DropDownList" runat="server" >
             
                <asp:ListItem Text="Economy" Value="economy"></asp:ListItem>
                <asp:ListItem Text="Premium Suit" Value="premium"></asp:ListItem>
                <asp:ListItem Text="Royal Suit" Value="royal"></asp:ListItem>
            
                </asp:DropDownList>
                 <asp:CustomValidator 
                
                ID="CustomValidator2" runat="server" 
                ErrorMessage="" ControlToValidate="DropDownList1" 
                ForeColor="Red"
                OnServerValidate="CustomValidatorSelect_ServerValidate">

              </asp:CustomValidator>
                <br/> 
                <label for="no. of Rooms"><b>No. of Rooms</b></label>
                <br/>
                <!-- <asp:ListItem Text="Select" Value=""></asp:ListItem> -->
                
                <asp:DropDownList ID="DropDownList2" CssClass="DropDownList" runat="server" >
                
                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                </asp:DropDownList>


                        
            </div>
             <asp:CustomValidator 
                
                ID="CustomValidator1" runat="server" 
                ErrorMessage="" ControlToValidate="DropDownList2" 
                ForeColor="Red"
                OnServerValidate="CustomValidatorSelect_ServerValidate">

              </asp:CustomValidator>
            <div class="container" style="background-color:#f1f1f1">
            <asp:Button runat="server" CssClass="btn btn-primary"  Text="Make Reservation" onclick="Reserve_the_room">
							
						</asp:Button>
            </div>
                <div class="container" style="background-color:#f1f1f1">
                <button type="button" onclick="document.getElementById('id01').style.display='none'" class="btn btn-danger">Cancel</button>
              
            </div>
        </div>
    </div> <!--book a room end -->




         <div id="id02" class="modal"><!--book a hall modal-->

        <div class="modal-content animate"  runat="server">
            <div class="container">
                <span onclick="document.getElementById('id02').style.display='none'" class="close" title="Close Login Form">&times;</span>
                <h2  style="text-align:center;"><b>Book a Hall</b></h2>
            </div>
            <div class="imgcontainer">

                <img src="https://cdn.meetingsbooker.com/images/venues/Sheffield-City-Hall-2.jpg" alt="Hotel Pic" class="avatar"/>
            </div>

            <asp:CustomValidator 
                
                ID="CustomValidator5" runat="server" 
                ErrorMessage="" ControlToValidate="Date1" 
                ForeColor="Red"
                OnServerValidate="CustomValidatorDate_ServerValidate">

              </asp:CustomValidator>

             <asp:CustomValidator 
                
                ID="CustomValidator6" runat="server" 
                ErrorMessage="" ControlToValidate="Date2" 
                ForeColor="Red"
                OnServerValidate="CustomValidatorDate_ServerValidate">

              </asp:CustomValidator>

            <div class="container">
               <label for="Check IN"><b>Check In</b></label>
                <br/> 
                <input type="date" id="Date1" class="DropDownList" runat="server" />
                <br/> 
                <label for="Check Out"><b>Check Out</b></label>
                <br/> 
                <input type="date" id="Date2" class="DropDownList" runat="server"/>
                <br/> 
                <label for="Category"><b>Category</b></label>
                <br/>
                 <!--<asp:ListItem Text="Select" Value=""></asp:ListItem>-->
                
                <asp:DropDownList ID="DropDownList3" CssClass="DropDownList" runat="server" >
                <asp:ListItem Text="Economy" Value="economy"></asp:ListItem>
                <asp:ListItem Text="Premium Suit" Value="premium"></asp:ListItem>
                <asp:ListItem Text="Royal Suit" Value="royal"></asp:ListItem>
            
                </asp:DropDownList>
                 <asp:CustomValidator 
                
                ID="CustomValidator3" runat="server" 
                ErrorMessage="" ControlToValidate="DropDownList3" 
                ForeColor="Red"
                OnServerValidate="CustomValidatorSelect_ServerValidate">

              </asp:CustomValidator>
                <br/> 
                <label for="no. of Rooms"><b>No. of Halls</b></label>
                <br/><!-- <asp:ListItem Text="Select" Value=""></asp:ListItem>-->
                
                <asp:DropDownList ID="DropDownList4" CssClass="DropDownList" runat="server" >
                
                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                
                </asp:DropDownList>
                 <asp:CustomValidator 
                
                ID="CustomValidator4" runat="server" 
                ErrorMessage="" ControlToValidate="DropDownList4" 
                ForeColor="Red"
                OnServerValidate="CustomValidatorSelect_ServerValidate">

              </asp:CustomValidator>

               <asp:Button runat="server" class="btn btn-primary" Text="Make Reservation" onclick="Reserve_the_hall">
							
						</asp:Button>
            
               
            </div>

            <div class="container" style="background-color:#f1f1f1">
                <button type="button" onclick="document.getElementById('id02').style.display='none'" class="cancelbtn">Cancel</button>
              
            </div>
        </div>
    </div><!--end book hall modal-->
        <asp:CustomValidator 
                
                ID="CustomValidator9" runat="server" 
                ErrorMessage="" ControlToValidate="txt_comments1" 
                ForeColor="Red"
                OnServerValidate="CustomValidatorFirstName_ServerValidate">

              </asp:CustomValidator>


         <div id="id03" class="modal"><!--feedback modal-->

        <div class="modal-content animate" runat="server">
            <div class="container">
                <span onclick="document.getElementById('id03').style.display='none'" class="close" title="Close Login Form">&times;</span>
                <h2  style="text-align:center;"><b>Give Feedback</b></h2>
            </div>
            <div class="imgcontainer">

                <img src="https://static1.squarespace.com/static/57b1985fe4fcb55f1bf1eac3/t/5859331b579fb307924e9e8f/1482240839559/?format=1500w" alt="FeedBack logo" class="avatar"/>
            </div>

            <div class="container">
             
                
              

            <label><b>Your Feedback</b></label><br/>
                
           <textarea id="txt_comments1" runat="server" class="DropDownList" name="txt_comments"  rows="10" cols="40" maxlength="140">
           </textarea>
                   
                <asp:Button ID="Button1" CssClass="btn btn-primary" OnClick="add_feedback" runat="server" Text="Submit Feedback" />
               
            </div>

            <div class="container" style="background-color:#f1f1f1">
                <button type="button" onclick="document.getElementById('id03').style.display='none'" class="cancelbtn">Cancel</button>
              
            </div>
        </div>
    </div><!--feedback end-->

        
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
</body>
</html>
