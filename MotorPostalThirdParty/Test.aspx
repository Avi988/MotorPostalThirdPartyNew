<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="MotorPostalThirdParty.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>










    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl_polno" runat="server" Text="Policy no. :"></asp:Label>
            <asp:TextBox ID="txt_polno" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </div>
        <div>
            <hr />
        </div>
        <div>
            <asp:Label ID="lbl_VehNo" runat="server" Text="Vehicle no. :"></asp:Label>
            <asp:TextBox ID="txt_VehNo" runat="server" Width="150"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lbl_CusName" runat="server" Text="Customer name :"></asp:Label>
            <asp:TextBox ID="txt_CusName" runat="server" Width="300"></asp:TextBox>
        </div>
    </form>
</body>
</html>
