<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmBulkSMS.aspx.cs" Inherits="MotorPostalThirdParty.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="Styles.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">



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
        .auto-style2 {
        width: 762px;
    }
    .auto-style3 {
        text-align: center;
    }
        .auto-style4 {
            width: 101px;
        }
        .auto-style5 {
            width: 101px;
            height: 5px;
        }
        .auto-style6 {
            height: 5px;
        }

        .auto-style15 {
            width: 101px;
            height: 9px;
        }
        .auto-style16 {
            height: 9px;
        }
    .auto-style17 {
        color: #FF0000;
    }
    .auto-style18 {
        width: 106px;
        height: 473px;
    }
        .auto-style19 {
            width: 592px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auto-style19">
    <table class="auto-style18">
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style3" colspan="4"><strong>Post SMS Sending</strong></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td>Branch</td>
            <td><asp:DropDownList ID="DropDownBranch" runat="server" AutoPostBack="True" Height="29px" Width="169px">
                    </asp:DropDownList>
                </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5"></td>
            <td class="auto-style6"></td>
            <td class="auto-style6"></td>
            <td class="auto-style6"></td>
            <td class="auto-style6"></td>
            <td class="auto-style6"></td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td>Policy No</td>
            <td>
                <asp:TextBox ID="txtpolno" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style15"></td>
            <td class="auto-style16">
                <asp:HiddenField ID="hdfepf" runat="server" />
                <asp:HiddenField ID="hdfbr" runat="server" />
            </td>
            <td class="auto-style16">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Or</td>
            <td class="auto-style16"></td>
            <td class="auto-style16"></td>
            <td class="auto-style16"></td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td>
                Date From</td>
            <td><asp:TextBox ID="Txtboxfrom" runat="server" Width="86px"></asp:TextBox>
                            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td>
                Date To</td>
            <td><asp:TextBox ID="TxtboxTo" runat="server" Width="86px"></asp:TextBox>
                            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btn_search" runat="server" OnClick="btn_search_Click" Text="Search" Width="100px" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td colspan="2">
                <asp:Label ID="txterror" runat="server" CssClass="auto-style17"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="63px" Width="121px">
                        <Columns>
                            <asp:BoundField HeaderText="Policy No" DataField="PolicyNo" SortExpression="PolicyNo" />
                            <asp:BoundField HeaderText="Vehicle No" DataField="VeicleNo" SortExpression="VeicleNo" />
                            <asp:BoundField HeaderText="Premium" DataField="Premium" SortExpression="Premium" />
                            <asp:BoundField HeaderText="EntryDate" DataField="Entry_Date" SortExpression="Entry_Date" />
                            <asp:BoundField HeaderText="Mobile No" DataField="MobileNo" SortExpression="MobileNo" />
                            <asp:BoundField HeaderText="Name" DataField="Name" SortExpression="Name" />
                            <asp:TemplateField HeaderText="SMS">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSMS" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="SendSMS" runat="server" OnClick="Button1_Click" Text="Send SMS" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</div>
</asp:Content>
