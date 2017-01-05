﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WinePusher.aspx.cs" Inherits="WinePusher.WinePusher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .centered-table {
            margin-left: auto;
            margin-right: auto;
        }

        .auto-style1 {
            height: 28px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="centered-table" border="0" style="background-color: #990000; color: #FFFFFF">
                <tr>
                    <td class="HeaderPadding" style="border-width: 0px; text-align: center">
                        <asp:Image ID="imaHeader" runat="server" ImageUrl="~/Images/wp_banner.jpg" />
                    </td>
                </tr>
                <tr>
                    <td style="padding: 0px 0px 0px 10px; border-width: 0px; text-align: left;" class="auto-style1">
                        <asp:Label ID="lblRoundsList" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Rundeliste"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td class="HeaderPadding" style="border-width: 0px; text-align: center">
                        <asp:GridView ID="gvRoundsList" OnRowCommand="gvRoundsList_RowCommand" runat="server" AutoGenerateColumns="False" AllowSorting="True" BackColor="#990000" CellPadding="5" Width="100%" BorderStyle="Groove" HorizontalAlign="Center" DataKeyNames="RoundId">
                            <Columns>
                                <asp:ButtonField ButtonType="Image" CommandName="addOrder" Text="Tilføj ordre" ImageUrl="~/Images/insert.png">
                                    <ControlStyle ForeColor="White" />
                                    <ItemStyle ForeColor="White" />
                                </asp:ButtonField>
                                <asp:BoundField DataField="RoundId" Visible="False" />
                                <asp:BoundField DataField="RoundDate" HeaderText="Dato" DataFormatString="{0:dd/MM/yyyy}" ReadOnly="True" />
                                <asp:BoundField DataField="WineType" HeaderText="Vintype" />
                                <asp:BoundField DataField="WineName" HeaderText="Vinnavn" />
                                <asp:BoundField DataField="Store" HeaderText="Butik" />
                                <asp:BoundField DataField="WinePrice" HeaderText="Pris" />
                                <asp:ButtonField CommandName="listOrders" DataTextField="OrdersCount" HeaderText="Ordrer" Text="OrdersCount">
                                    <ControlStyle ForeColor="White" />
                                    <ItemStyle ForeColor="White" />
                                </asp:ButtonField>
                                <asp:BoundField DataField="RoundStatus" HeaderText="Status" />
                            </Columns>
                            <HeaderStyle Font-Bold="True" Font-Size="Large" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="border-width: 0px;">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td style="padding: 5px; border-width: 0px; text-align: left; vertical-align: middle;">
                        <asp:Button ID="btnCreateRound" runat="server" Text="Opret runde" OnClick="btnCreateRound_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
