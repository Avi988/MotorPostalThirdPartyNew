<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Individualchild.aspx.cs" Inherits="MotorPostalThirdParty.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script  language="javascript" type="text/javascript">
    <link href="Styles.css" rel="stylesheet" type="text/css" />

    </script>
    
    <style type="text/css">
         
    .style1
        {
            width: 327px; 
        }
        .style2
        {
            width: 233px;
        }
        .style3
        {
            height: 45px;
        }
        .style4
        {
            width: 233px;
            height: 45px;
        }
        .style5
        {
            width: 73px;
        }
        .style6
        {
            height: 45px;
            width: 73px;
        }
        .style7
        {
            width: 160px;
        }

        .auto-style1 {
            width: 593px;
            margin-left: 122px;
            height: 420px;
        }

        .auto-style2 {
            width: 170px;
        }
        .auto-style4 {
            width: 331px;
            
        }
        .auto-style5 {
            width: 331px;
            text-align: center;
        }

        .auto-style6 {
            height: 23px;
            width: 511px;
        }
        .auto-style7 {
            height: 23px;
            text-align: center;
            width: 32px;
        }
        .auto-style9 {
            text-align: center;
            width: 32px;
        }
        .auto-style10 {
            width: 511px;
        }
        .auto-style11 {
            height: 23px;
        }

        .auto-style12 {
            margin-top: 2px;
        }

    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <fieldset id="fieldSet_individual" runat="server" style="border-color: #4682B4; " class="auto-style1">


    <legend style="background-color: #4682B4; color: #FFFFFF; text-align: left; font-size: 15px">
            Motor Third Party</legend>

    

        <asp:Panel ID="Panel1" runat="server" Height="99px">
            <table style="width:100%;">
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style4" style="color:#0000CD" >
                        <asp:Label ID="Label2" runat="server" Text="Policy No :"></asp:Label>
                        <asp:TextBox ID="Txtboxpol" runat="server"></asp:TextBox>
                    </td>
                    <td rowspan="3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style5">
                        <asp:Button ID="Btnsearch" runat="server" Text="SEARCH" CssClass="auto-style12" Height="30px" BackColor="#4682B4" ForeColor="#FFFFFF" OnClick="Btnsearch_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>

        <asp:Panel ID="Panel2" runat="server" Height="184px" Width="618px">
            <table style="width:100%;">
                <tr>
                    <td class="auto-style7"></td>
                    <td class="auto-style6" >
                        <asp:Label ID="LblCusName" runat="server" Text="Customer Name : " style="color:#0000CD"></asp:Label>
                        <asp:Label ID="LblName" runat="server" Text="LblName"></asp:Label>
                    </td>
                    <td rowspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style6">
                        <asp:Label ID="LblMobile" runat="server" Text="Customer Mobile :" style="color:#0000CD"></asp:Label>
                        <asp:Label ID="LabelMobi" runat="server" Text="LblMobi"></asp:Label>
                        &nbsp;<table style="width:100%;">
                            <tr>
                                <td class="auto-style11"></td>
                                <td class="auto-style11"></td>
                                <td class="auto-style11"></td>
                            </tr>
                            <tr>
                                <td class="auto-style11">
                                    <asp:Label ID="LblPreSent" runat="server" Text="Previous Sent" style="color:#0000CD"></asp:Label>
                                    
                                </td>
                                <td class="auto-style11"></td>
                                <td class="auto-style11"></td>
                            </tr>
                            </tr>
                            <tr>
                                <td class="auto-style11">
                                    <asp:Label ID="LabelSentDate" runat="server" Text="SMS Sent Date :" style="color:#0000CD"></asp:Label>
                                    
                                    <asp:Label ID="LblDate" runat="server" Text="LblSentDate"></asp:Label>
                                    
                                </td>
                                <td class="auto-style11"></td>
                                <td class="auto-style11"></td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Audit Trail : " style="color:#0000CD"></asp:Label>
                                    <table style="width:100%;">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="168px" Height="50px">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Action" />
                                                        <asp:BoundField HeaderText="Date" />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="loginDisplay">&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                                <td colspan="2">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>


            </asp:Panel>

    

        <table __designer:mapid="2227" style="width:100%;">
            <tr __designer:mapid="2228">
                <td __designer:mapid="2229" class="auto-style11"></td>
            </tr>
            <tr __designer:mapid="222c">
                <td __designer:mapid="222d" class="loginDisplay">
                    <asp:Button ID="BtnsendSMS" runat="server" Text="Send SMS" Height="33px" BackColor="#4682B4" ForeColor="#FFFFFF" />
                </td>
            </tr>
        </table>

    

        </fieldset>
</asp:Content>
