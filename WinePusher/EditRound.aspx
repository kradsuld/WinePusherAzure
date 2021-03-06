﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditRound.aspx.cs" Inherits="WinePusher.EditRound" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        
        .centered-table {
            margin-left: auto;
            margin-right: auto;
        }
        .auto-style7 {
            width: 10px;
        }
        .auto-style8 {
            width: 131px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="centered-table" border="1" style="border: thin solid #808080; background-color: #990000; color: #FFFFFF">
                <tr>
                    <td class="HeaderPadding" style="border-width: 0px; text-align: center">
                        <asp:Image ID="imaHeader" runat="server" ImageUrl="~/Images/wp_banner.jpg" />
                    </td>
                </tr>
                <tr>
                    <td style="border-width: 0px;">
                        <table style="width: 100%;">
                            <tr>
                                <td class="auto-style7">&nbsp;</td>
                                <td colspan="4">
                                    <asp:Label ID="lblCreateRound" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Ret runde"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style7">&nbsp;</td>
                                <td class="auto-style8">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style7">&nbsp;</td>
                                <td class="auto-style8">
                                    <asp:Label ID="lblWineType" runat="server" Text="Vintype"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblWineTypeSpacer" runat="server" Text=": &amp;nbsp;"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddWineTypes" runat="server">
                                        <asp:ListItem>Rødvin</asp:ListItem>
                                        <asp:ListItem>Hvidvin</asp:ListItem>
                                        <asp:ListItem>Sherry</asp:ListItem>
                                        <asp:ListItem>Portvin</asp:ListItem>
                                        <asp:ListItem>Bobler</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style7">&nbsp;</td>
                                <td class="auto-style8">
                                    <asp:Label ID="lblWineName" runat="server" Text="Vinnavn"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblWineNameSpacer" runat="server" Text=": &amp;nbsp;"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="tbWineName" runat="server" Width="200px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvWineName" runat="server" ControlToValidate="tbWineName" ErrorMessage="Vinnavn skal udfyldes"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style7">&nbsp;</td>
                                <td class="auto-style8">
                                    <asp:Label ID="lblStore" runat="server" Text="Butik"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblStoreSpacer" runat="server" Text=": &amp;nbsp;"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="tbStore" runat="server" Width="150px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvStore" runat="server" ControlToValidate="tbStore" ErrorMessage="Butik skal udfyldes"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style7">&nbsp;</td>
                                <td class="auto-style8">
                                    <asp:Label ID="lblUrl" runat="server" Text="Link til vinen"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblUrlSpacer" runat="server" Text=": &amp;nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tbUrl" runat="server" Width="500px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvUrl" runat="server" ControlToValidate="tbUrl" ErrorMessage="Link skal udfyldes"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style7">&nbsp;</td>
                                <td class="auto-style8">
                                    <asp:Label ID="lblWinePrice" runat="server" Text="Pris"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblWinePriceSpacer" runat="server" Text=": &amp;nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tbWinePrice" runat="server" ValidationGroup="vgCreateRound" Width="50px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="rvlWinePrice" runat="server" ControlToValidate="tbWinePrice" ErrorMessage="Skal indeholde tal" ValidationExpression="^\d{0,8}(\,\d{1,4})?$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style7">&nbsp;</td>
                                <td class="auto-style8">
                                    <asp:Label ID="lblCost" runat="server" Text="Omkostninger"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCostSpacer" runat="server" Text=": &amp;nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tbCost" runat="server" Width="50px"></asp:TextBox>
                                    &nbsp;
                                    <asp:Label ID="lblCostExplain" runat="server" Text="(Fragt og betalingsgebyr) "></asp:Label>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="rvlCost" runat="server" ControlToValidate="tbCost" ErrorMessage="Skal indeholde tal" ValidationExpression="^\d{0,8}(\,\d{1,4})?$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style7">&nbsp;</td>
                                <td class="auto-style8">
                                    <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblStatusSpacer" runat="server" Text=": &amp;nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddStatus" runat="server">
                                        <asp:ListItem Value="A">Aktiv</asp:ListItem>
                                        <asp:ListItem Value="C">Afsluttet</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 5px; border-width: 0px; text-align: left; vertical-align: middle;">
                        <hr />
                    </td>
                </tr>

                <tr>
                    <td style="padding: 5px; border-width: 0px; text-align: left; vertical-align: middle;">
                        <asp:Button ID="btnSaveRound" runat="server" Text="Gem runde" OnClick="btnSaveRound_Click" />
                        &nbsp;                
                        <asp:Button ID="btnDelete" runat="server"  CausesValidation="false" Text="Slet runde" OnClick="btnDeleteRound_Click" />
                        &nbsp;                
                        <asp:Button ID="btnBack" runat="server" CausesValidation="false" Text="Tilbage" OnClick="btnBack_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
