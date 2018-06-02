<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="displayrooms.aspx.cs" Inherits="try2.DisplayRooms.displayrooms" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater ID="Repeater1" runat="server">
        
            
        </asp:Repeater>
        
        <asp:gridview ID="grid" runat="server"></asp:gridview>
        <asp:GridView ID="grid2" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>

