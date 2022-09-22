<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bulk.aspx.cs" Inherits="MotorPostalThirdParty.Bulk1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link type="text/css" href="css/custom-theme/jquery-ui-1.10.3.custom.css" rel="stylesheet" />	
    <script type="text/javascript" src="js/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.10.3.custom.js"></script>
    <script type="text/javascript" src="js/script.js"></script> 
    

    <script  language="javascript" type="text/javascript">

        $(function () {
        today = new Date();
        var month, day, year;
        year = today.getFullYear();
        month = today.getMonth();
        date = today.getDate();
        year = today.getFullYear() - 60;
        var backdate = new Date(year, month, date)


        $("input[id$='Txtboxfrom']").datepicker({ dateFormat: "yy/mm/dd", changeMonth: true, changeYear: true });
            $("input[id$='TxtboxTo']").datepicker({ dateFormat: "yy/mm/dd", changeMonth: true, changeYear: true });
    });

       
</script>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            margin-left: 74px;
        }
        .auto-style3 {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
        </div>
        <asp:Panel ID="Panel1" runat="server" Height="627px">
            <br />
            <br />
            <br />
            <br />
            <br />
            <table style="width:100%;">
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label1" runat="server" Text="Post SMS Sending"></asp:Label>
                    </td>
                    <td rowspan="3">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label2" runat="server" Text="Branch : "></asp:Label>
                        <asp:DropDownList ID="DropdwnBranch" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <table style="width:100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td rowspan="3">&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Date"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <table style="width:100%;">
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="From : "></asp:Label>
                        <asp:TextBox ID="TxtBoxFrom" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label5" runat="server" Text="To : "></asp:Label>
                        <asp:TextBox ID="TxtBoxTo" runat="server"></asp:TextBox>
                    </td>
                    <td rowspan="3">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Policy No : "></asp:Label>
                        <asp:TextBox ID="TxtBoxPol" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table style="width:100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td rowspan="3">&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" CssClass="auto-style2" Text="Search" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="CheckBoxSelectAll" runat="server" Text="Select All" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="ChckBoxSelectNon" runat="server" Text="Select Non" />
                    </td>
                </tr>
            </table>
            <table style="width:100%;">
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField />
                                <asp:BoundField HeaderText="Policy No" />
                                <asp:BoundField HeaderText="Vehicle No" />
                                <asp:BoundField HeaderText="Payment" />
                                <asp:BoundField HeaderText="Date" />
                                <asp:BoundField HeaderText="Mobile No" />
                                <asp:BoundField HeaderText="Name of Customer" />
                                <asp:BoundField HeaderText="SMS" />
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Button ID="Button2" runat="server" Text="Send SMS" />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
        </asp:Panel>
    </form>
</body>
</html>
