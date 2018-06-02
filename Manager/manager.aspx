<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manager.aspx.cs" Inherits="try2.Manager.manager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet"/>
      <!--Import materialize.css-->
      <link type="text/css" rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.100.2/css/materialize.min.css"  media="screen,projection"/>
    <link href="style.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">
    <div>

         <div class="center-align">
            <asp:Label class=" red-text" ID="er1" runat="server" Text=""></asp:Label>
          
            </div>
         <asp:Button runat="server" class="btn white black-text right" Text="Sign Out" OnClick="RecepSignOut_Click"/>
       <div class="row">
           <div class="col s1"></div>
           <div class="input-field col s5">
                 <div class="center-align">
            <asp:Label class=" red-text" ID="Label1" runat="server" Text=""></asp:Label>
          
            </div>
    
               <asp:CustomValidator 
                
                ID="CustomValidator3" runat="server" 
                ErrorMessage="CNIC Must have 13 Integers" ControlToValidate="customerID" 
                ForeColor="Red"
                OnServerValidate="CustomValidatorCNIC_ServerValidate">

              </asp:CustomValidator>
          <input runat="server"  id="customerID"  class="validate" maxlength="13" data-length="13">
          <label >CNIC</label>

                <asp:Button class="btn waves-effect waves-light" OnClick="Accept_Application" runat="server"  type="submit" name="action" Text="Accept" />
                <asp:Button class="btn waves-effect waves-light" OnClick="Reject_Application" runat="server"  type="submit" name="action" Text="Reject" />

       </div>
           </div>
        
        <h6>Applications Table</h6>
        <asp:gridview class="striped responsive-table" ID="grid" runat="server"></asp:gridview>
        <br /><br /><br />
        <h6>Employee Table</h6>
        <asp:GridView class="striped responsive-table" ID="grid2" runat="server"></asp:GridView>
    </div>
    </form>

     <!--Import jQuery before materialize.js-->
     <script type="text/javascript" src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
      <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.100.2/js/materialize.min.js"></script>
 
</body>
</html>

