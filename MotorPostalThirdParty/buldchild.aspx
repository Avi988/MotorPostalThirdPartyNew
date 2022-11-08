<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="buldchild.aspx.cs" Inherits="MotorPostalThirdParty.WebForm1" %>

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
        .style22 {
            height: 50px;
            width: 156px;
        }

        .auto-style1 {
            text-align: center;
        }

        .style2 {
            width: 160px;
        }


        .auto-style7 {
            text-align: center;
            width: 531px;
            height: 499px;
            margin-left: 64px;
        }

        .auto-style8 {
            text-align: center;
            margin-left: 64px;
        }


        .auto-style9 {
            height: 19px;
            text-align: left;
        }

        .auto-style10 {
            width: 19px;
            /*height: 50px;*/
            text-align: center;
        }


        .auto-style11 {
            margin-left: 157px;
        }


        .auto-style12 {
            text-align: left;
        }

        .auto-style13 {
            margin-left: 101px;
        }

        .auto-style14 {
            margin-left: 74px;
        }

        .auto-style15 {
            margin-left: 128px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>     

    <div class="auto-style1">
    </div>
    <asp:Panel ID="Panel1" runat="server" Height="737px" Width="619px">
        <legend style="background-color: #4682B4; color: #FFFFFF; text-align: left; font-size: 15px">Post SMS Sending 
        </legend>


        <table style="font-size: 11pt; margin-bottom: 5px; text-align: left;" class="auto-style5">



            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td rowspan="4" class="auto-style4">&nbsp;</td>
            </tr>

            <tr>
                <td class="auto-style1"><strong>
                    <!--<asp:Label ID="Label14" runat="server" Text="Post SMS Sending"></asp:Label>-->
                </strong></td>
            </tr>

            <tr>
                <td class="auto-style10" style="color: #0000CD;">

                    <asp:Label ID="Label13" runat="server" Text="Branch :"></asp:Label>
                    &nbsp;<asp:DropDownList ID="DropDownBranch" runat="server" AutoPostBack="True" Height="22px">
                    </asp:DropDownList>
                </td>


            </tr>

            <tr>
                <td class="auto-style4">&nbsp;<table style="width: 100%;">
                    <tr>

                        <td class="auto-style9" style="color: #000080">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="LblDate" runat="server" Text="Date "></asp:Label>
                        </td>


                        <td rowspan="3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style12" style="color: #000080">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text="From :"></asp:Label>
                            &nbsp;&nbsp;<asp:TextBox ID="Txtboxfrom" runat="server" CssClass="auto-style13" Width="86px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        </td>

                        <!--<td class="style3">
                                <asp:TextBox ID="txt_From" runat="server" Width="80px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_FromDate" runat="server" ErrorMessage="Required" ForeColor="red" ControlToValidate="txt_From" ValidationGroup="a"></asp:RequiredFieldValidator>
                                </td>-->



                    </tr>
                    <tr style="color: #000080">
                        <td class="auto-style12">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label9" runat="server" Text="To :"></asp:Label>
                            <asp:TextBox ID="TxtboxTo" runat="server" Width="83px" Height="17px" CssClass="auto-style15"></asp:TextBox>
                            &nbsp;</td>
                    </tr>
                </table>
                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td rowspan="3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style12" style="color: #000080">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label12" runat="server" Text="Policy No :"></asp:Label>
                                &nbsp;<asp:TextBox ID="TxtboxTo0" runat="server" CssClass="auto-style14" Height="17px" Width="178px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style8">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:HyperLink ID="HyperLink1" NavigateUrl="Individualchild.aspx" runat="server">BACK</asp:HyperLink>
                                <asp:Button ID="Button4" runat="server" CssClass="auto-style8" Style="margin-left: 119px" Text="SEARCH" Height="33px" Width="69px" BackColor="#4682B4" ForeColor="#FFFFFF" OnClick="Button4_Click" />
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:CheckBox ID="CheckBoxSelectAll" runat="server" />
                                <asp:Label ID="Label7" runat="server" Text="Select All"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxSelectNon" runat="server" />
                                <asp:Label ID="Label8" runat="server" Text="Select Non"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="63px" Width="121px">
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
                    <table style="width: 100%;">
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="BtnbuildSMS" runat="server" Height="31px" Text="Send SMS" CssClass="auto-style11" BackColor="#4682B4" ForeColor="#FFFFFF" />
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>

                        <tr>
                            <td class="style22">&nbsp;</td>

                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>


                        <!--<tr>
                            <td colspan="6" style="text-align: center; color: Red">
                            <asp:Label ID="lbl_Error" runat="server" Text=""></asp:Label>
                            </td>
                            </tr>-->


                    </table>
                </td>
            </tr>
        </table>
        </fieldset>

    </asp:Panel>
</asp:Content>


