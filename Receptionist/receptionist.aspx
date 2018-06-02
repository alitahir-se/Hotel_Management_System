<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="receptionist.aspx.cs" Inherits="try2.Receptionist.receptionist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet"/>
      <!--Import materialize.css-->
      <link type="text/css" rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.100.2/css/materialize.min.css"  media="screen,projection"/>
    <link href="style.css" rel="stylesheet" />
    <link href="../signup/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="center-align">
            <asp:Label class=" red-text" ID="er1" runat="server" Text=""></asp:Label>
           <asp:Label CssClass="center red-text" ID="Label1" runat="server" Text=""></asp:Label>
          
            </div>

        <asp:Button runat="server" class="btn white black-text right" Text="Sign Out" OnClick="RecepSignOut_Click"/>

         <asp:CustomValidator
                ID="CustomValidator1" runat="server" 
                 ErrorMessage="This Input feild cannot be empty and must have Integer Value" 
                ControlToValidate="RoomID"
                
                ForeColor="Red"
                OnServerValidate="CustomValidatorRoomID_ServerValidate"
                
                >

            </asp:CustomValidator>

       <div class="row">
           <div class="col s1"></div>
          
           <div class="input-field col s5">
            
                    
          <input runat="server"  id="RoomID"  class="validate" maxlength="6" >
          <label >Room Reservation ID</label>

                <asp:Button  class="btn waves-effect waves-light" runat="server"  type="submit" name="action" Text="Reject" OnClick="RejectReservationRoom_Click"  />
                <asp:Button  class="btn waves-effect waves-light" runat="server"  type="submit" name="action" Text="Check Out" OnClick="CheckOutRoom_Click" />

       </div>
           </div>

        <asp:CustomValidator
                ID="CustomValidatorHallID" runat="server" 
                 ErrorMessage="This Input feild cannot be empty and must have Integer Value" 
                ControlToValidate="HallID"
                
                ForeColor="Red"
                OnServerValidate="CustomValidatorHallID_ServerValidate"
                
                >

            </asp:CustomValidator>

        <div class="row">
           <div class="col s1"></div>
            
           <div class="input-field col s5">
                
                
          <input runat="server"  id="HallID"  class="validate" maxlength="6" >
          <label >Hall Reservation ID</label>

             
                <asp:Button class="btn waves-effect waves-light" runat="server"  type="submit" name="action" Text="Reject" OnClick="RejectReservationHall_Click" />
                <asp:Button class="btn waves-effect waves-light" runat="server"  type="submit" name="action" Text="Check Out" OnClick="CheckOutHall_Click" />


               

       </div>
           </div>
        <h6>Rooms Reservation : </h6>      
        <asp:gridview class="striped responsive-table" ID="grid" runat="server"></asp:gridview>
        <br /><br />
        <h6>Rooms Reservation Record : </h6>
        <asp:GridView class="striped responsive-table" ID="grid2" runat="server"></asp:GridView>
        <br /><br />
        <h6>Halls Reservation : </h6>
        <asp:gridview class="striped responsive-table" ID="grid3" runat="server"></asp:gridview>
        <br /><br />
        <h6>Halls Reservation Record : </h6>
        <asp:GridView class="striped responsive-table" ID="grid4" runat="server"></asp:GridView>

        
    </div>
    </form>

     <!--Import jQuery before materialize.js-->
     <script type="text/javascript" src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
      <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.100.2/js/materialize.min.js"></script>
 
</body>
</html>

