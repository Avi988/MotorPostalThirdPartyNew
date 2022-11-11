<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormIndividual.aspx.cs" Inherits="MotorPostalThirdParty.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: left;
        }
        .auto-style3 {
            margin-left: 8px;
        }
        .auto-style4 {
            margin-left: 6px;
        }
    .auto-style5 {
        margin-left: 95px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td class="loginDisplay">
            
            <td class="auto-style3"><strong>Motor Third Party</strong></td>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Policy No : "></asp:Label>
            <asp:TextBox ID="TxtBoxPol" runat="server" Width="125px" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td class="auto-style1">
            <asp:Button ID="Btn_Search" runat="server" CssClass="auto-style5" Text="Search" />
            <asp:Label ID="message" runat="server" CssClass="auto-style17"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>
            <asp:TextBox ID="txtboxMobile" runat="server" CssClass="auto-style4" Height="20px" Width="125px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>
            <asp:Label ID="LblName" runat="server" Text="Name : "></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TxtboxName" runat="server" CssClass="auto-style4" Height="20px" Width="125px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>
            <asp:Label ID="LblMobiNo" runat="server" Text="Mobile :"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TxtBoxMobi" runat="server" Height="20px" Width="125px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Previous Sent"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Audit Trail :"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>
            <asp:GridView ID="grv_MatchingVehicleNo" runat="server" AutoGenerateColumns="False" Width="304px"
                        Height="16px">
                        <Columns>
<%--                            <asp:TemplateField HeaderText=" Matching Manual PR Nos" HeaderStyle-ForeColor="#ffffff"
                                HeaderStyle-BackColor="#4682B4" HeaderStyle-Font-Bold="false" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HyperLink ID="manualPRNo" runat="server" NavigateUrl='<%# String.Format("Inquired_Details.aspx?txt_ManualPRNo="+Eval("Manual PR Nos"))%>'
                                        Text='<%# Eval("Manual PR Nos") %>' HorizontalAlign="Center"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                         <asp:BoundField HeaderText="Seq No" DataField="Sequence_No" SortExpression="Sequence_No"
                                           HeaderStyle-ForeColor="#ffffff" HeaderStyle-BackColor="#4682B4" HeaderStyle-Font-Bold="false">
<HeaderStyle BackColor="SteelBlue" Font-Bold="False" ForeColor="White"></HeaderStyle>

                                            <ItemStyle HorizontalAlign="Center" ForeColor="#000000"></ItemStyle>
                                        </asp:BoundField>
                            <asp:BoundField HeaderText="IS_Send" DataField="IS_SEND" SortExpression="IS_SEND"
                                           HeaderStyle-ForeColor="#ffffff" HeaderStyle-BackColor="#4682B4" HeaderStyle-Font-Bold="false">
<HeaderStyle BackColor="SteelBlue" Font-Bold="False" ForeColor="White"></HeaderStyle>

                                            <ItemStyle HorizontalAlign="Center" ForeColor="#000000"></ItemStyle>
                                        </asp:BoundField>
                             <%--<asp:TemplateField HeaderText="Date" HeaderStyle-ForeColor="#ffffff"
                                HeaderStyle-BackColor="#4682B4" HeaderStyle-Font-Bold="false" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HyperLink ID="receiptNo" runat="server" NavigateUrl='<%# String.Format("Search_By_VehicleNo_3.aspx?txt_ReceiptNo="+Eval("receiptNo"))%>'
                                        Text='<%# Eval("receiptNo") %>' HorizontalAlign="Center"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:BoundField DataField="SEND_USER" HeaderText="Send_User" SortExpression="SEND_USER" />
                            <asp:BoundField DataField="SEND_IP" HeaderText="Send_IP" SortExpression="SEND_IP" />
                            <asp:BoundField DataField="IS_RESEND" HeaderText="IS_Resend" SortExpression="IS_RESEND" />
                            <asp:BoundField DataField="ENTRY_DATE" HeaderText="Entry_Date" SortExpression="ENTRY_DATE" />
                            <asp:BoundField DataField="ENTRY_EPF" HeaderText="Entry_EPF" SortExpression="ENTRY_EPF" />
                            <asp:BoundField DataField="MOBILE_NO" HeaderText="MobileNo" SortExpression="MOBILE_NO" />
                        </Columns>
                    </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>
            <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Text="Send" />
        </td>
    </tr>
</table>
</asp:Content>
