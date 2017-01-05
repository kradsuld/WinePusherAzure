﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListOrders.aspx.cs" Inherits="WinePusher.ListOrders" %>

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
                        <asp:Label ID="lblOrdersList" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Ordreliste til:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 0px 0px 0px 10px; border-width: 0px; text-align: left;" class="auto-style1">
                        <asp:Label ID="lbloWineName" runat="server" Text="*" Font-Bold="True" Font-Size="Large"></asp:Label>
                        <asp:Label ID="lblFrom" runat="server" Text="fra" Font-Bold="True" Font-Size="Large"></asp:Label>
                        <asp:Label ID="lbloStore" runat="server" Text="*" Font-Bold="True" Font-Size="Large"></asp:Label>
                        <asp:Label ID="lblPrice" runat="server" Text="til kr." Font-Bold="True" Font-Size="Large"></asp:Label>
                        <asp:Label ID="lbloPrice" runat="server" Text="*" Font-Bold="True" Font-Size="Large"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="HeaderPadding" style="border-width: 0px; text-align: center">
                        <asp:GridView ID="gvOrdersList" OnRowCommand="gvOrdersList_RowCommand" OnRowDataBound="gvOrdersList_RowDataBound" runat="server" AutoGenerateColumns="False" AllowSorting="True" BackColor="#990000" CellPadding="5" Width="100%" BorderStyle="Groove" HorizontalAlign="Center" DataKeyNames="OrderId">
                            <Columns>
                                <asp:BoundField DataField="OrderId" Visible="False" />
                                <asp:ButtonField ButtonType="Image" CommandName="editOrder" Text="Ret ordre" FooterText="Ret ordre" ImageUrl="~/Images/edit.png">
                                    <ControlStyle ForeColor="White" />
                                    <ItemStyle ForeColor="White" />
                                </asp:ButtonField>
                                <asp:BoundField DataField="OrderDate" HeaderText="Dato" DataFormatString="{0:dd/MM/yyyy}" ReadOnly="True" />
                                <asp:BoundField DataField="MemberName" HeaderText="Medlem" />
                                <asp:BoundField DataField="Bottles" HeaderText="Flasker" />
                                <asp:BoundField DataField="TotalAmount" HeaderText="Ordrebeløb" />
                                <asp:BoundField DataField="Delivered" HeaderText="Delivered" />
                                <asp:BoundField DataField="Paid" HeaderText="Paid" />
                                <asp:TemplateField HeaderText="Leveret">
                                    <ItemTemplate>
                                        <asp:Image ID="ImgDelivered" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Betalt">
                                    <ItemTemplate>
                                        <asp:Image ID="ImgPaid" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
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
                        <asp:Button ID="btnCreateOrder" runat="server" Text="Tilføj ordre" OnClick="btnCreateOrder_Click" />
                        &nbsp;                
                        <asp:Button ID="btnBack" runat="server" CausesValidation="false" Text="Tilbage" OnClick="btnBack_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
