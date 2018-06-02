<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="offers.aspx.cs" Inherits="try2.Offers.offers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!--Import Google Icon Font-->
      <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet"/>
      <!--Import materialize.css-->
      <link type="text/css" rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.100.2/css/materialize.min.css"  media="screen,projection"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <div class="center-align">
            <asp:Label class=" red-text" ID="er1" runat="server" Text=""></asp:Label>
          
            </div>
        <asp:CustomValidator 
                
                ID="CustomValidator3" runat="server" 
                ErrorMessage="Discount should be an integer" ControlToValidate="discount" 
                ForeColor="Red"
                OnServerValidate="CustomValidatorCNIC_ServerValidate">

              </asp:CustomValidator>
    <div class="row">
                <div class="input-field col s5">
                         
                  <input runat="server"  id="discount"  class="validate" maxlength="20" data-length="20">
                  <label>Discount Offer</label>
                    </div> 
      
        </div> 
        <div class="row">
              <div class="col s5">
                         <select id="category" runat="server">
                     
                      <option value="1">Economy</option>
                      <option value="2">Premium</option>
                      <option value="3">Royal Suit</option>
                    </select>
            </div>
        </div>      


      <div class="row">
            <div class="col s5"> </div>
            <asp:Button runat="server" class="btn waves-effect waves-light " type="submit" Text="Submit" name="action" OnClick="ChangeDiscount_Click"/>
             
        </div>
          <h5>Rooms</h5>
        <asp:GridView class="striped responsive-table" ID="grid" runat="server"></asp:GridView>
          <br /><br />      <h5>Halls</h5>
        <asp:GridView class="striped responsive-table" ID="grid2" runat="server"></asp:GridView>
        

    </div>
    </form>

    <!--Import jQuery before materialize.js-->
     <script type="text/javascript" src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
      <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.100.2/js/materialize.min.js"></script>
    <script src="script.js"></script>
</body>
</html>
