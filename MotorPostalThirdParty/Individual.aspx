<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Individual.aspx.cs" Inherits="MotorPostalThirdParty.Bulk" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style4 {
            width: 262px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       
        <div class="auto-style1">
        </div>
        <asp:Panel ID="Panel1" runat="server" Height="223px">
            <br />
            <br />
            <br />
            <table style="width:100%;">
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label14" runat="server" Text="E-Certificate Motor Third Party Insurance"></asp:Label>
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
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Height="434px">
            <table style="width: 100%;">
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text=" Customer Name :"></asp:Label>
                        &nbsp;
                        <asp:Label ID="Label4" runat="server" Text="lblName"></asp:Label>
                    </td>
                    <td rowspan="3">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Customer Mobile :"></asp:Label>
                                    &nbsp;
                                    <asp:Label ID="Label6" runat="server" Text="LblMobi"></asp:Label>
                                </td>
                                <td rowspan="3">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="Previous Sent"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table style="width: 100%;">
                            <tr>
                                <td class="auto-style4"></td>
                                <td rowspan="3"></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="SMS Sent Date :"></asp:Label>
                                    &nbsp;<asp:Label ID="Label9" runat="server" Text="LblSentDate"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="Audit Trail :"></asp:Label>
                                </td>
                                <td rowspan="3">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="106px" Width="215px">
                                        <AlternatingRowStyle BackColor="#DDDDDD" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ACTION" HeaderText="Action" />
                                            <asp:BoundField DataField="DATE" HeaderText="Date" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button2" runat="server" CssClass="auto-style6" Text="Send SMS" Width="133px" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
       
    </form>
</body>
</html>
