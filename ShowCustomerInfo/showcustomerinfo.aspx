<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showcustomerinfo.aspx.cs" Inherits="try2.ShowCustomerInfo.showcustomerinfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <!--Import Google Icon Font-->
      <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet"/>
      <!--Import materialize.css-->
      <link type="text/css" rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.100.2/css/materialize.min.css"  media="screen,projection"/>
 
    <link href="../signup/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
         <div class="row">
           <div class="col s1"></div>
           <div class="input-field col s5">
                 <div class="center-align">
            <asp:Label class=" red-text" ID="er2" runat="server" Text=""></asp:Label>
          
            </div>
    
               <asp:CustomValidator 
                
                ID="CustomValidator3" runat="server" 
                ErrorMessage="ID must be integer" ControlToValidate="blackid" 
                ForeColor="Red"
                OnServerValidate="CustomValidatorCNIC_ServerValidate">

              </asp:CustomValidator>
          <input runat="server"  id="blackid"  class="validate" />
          <label >Cid to be BlackListed</label>
                           <asp:Button class="btn waves-effect waves-light" OnClick="Blacklistcid" runat="server"  type="submit" name="action" Text="Blacklist" />

                      </div>
           </div>
       

    <div>
        <br /><br /><h4>Customer Info</h4>
        <asp:GridView class="striped" ID="gridFeedback" runat="server"></asp:GridView>
    
    </div>
        <div>
        <br /><br /><h4>BlackListed User</h4>
        <asp:GridView class="striped" ID="Blacklisted" runat="server"></asp:GridView>
    
    </div>
    </form>

       <!--Import jQuery before materialize.js-->
     <script type="text/javascript" src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
      <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.100.2/js/materialize.min.js"></script>
 
</body>
</html>
