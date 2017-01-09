<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WinePusher.Logon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .centered-table {
            margin-left: auto;
            margin-right: auto;
        }

        #login {
            width: 270px;
            margin: 0 auto;
        }

        .auto-style2 {
            width: 235px;
        }

        .auto-style5 {
            height: 30px;
        }

        .auto-style6 {
            width: 206px;
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
                    <td class="HeaderPadding" style="border-width: 0px; text-align: center">
                        <div id="login">
                            <asp:Login ID="Login1" runat="server" OnAuthenticate="ValidateUser" LoginButtonText="Log på" PasswordRequiredErrorMessage="Password skal udfyldes." RememberMeText="Husk mig." TitleText="Log på" UserNameLabelText="Brugernavn:" UserNameRequiredErrorMessage="Brugernavn skal udfyldes." Height="196px" Width="267px" FailureText="Dit login-forsøg gik ikke godt. Venligst prøv igen.">
                                <LayoutTemplate>
                                    <table style="border-collapse: collapse;">
                                        <tr>
                                            <td class="auto-style2">
                                                <table style="height: 176px; width: 264px">
                                                    <tr>
                                                        <td style="text-align: center" colspan="2">Log på</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-width: 0px; text-align: right">
                                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Brugernavn:</asp:Label>
                                                        </td>
                                                        <td class="auto-style6" style="border-width: 0px; text-align: center">
                                                            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="Brugernavn skal udfyldes." ToolTip="Brugernavn skal udfyldes." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border-width: 0px; text-align: right">
                                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                                        </td>
                                                        <td class="auto-style6" style="border-width: 0px; text-align: center">
                                                            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password skal udfyldes." ToolTip="Password skal udfyldes." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:CheckBox ID="RememberMe" runat="server" Text="Husk mig" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: center" colspan="2" style="color: Black;">
                                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: center" colspan="2" class="auto-style5">
                                                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log på" ValidationGroup="Login1" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </LayoutTemplate>
                                <FailureTextStyle ForeColor="Black" />
                            </asp:Login>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
