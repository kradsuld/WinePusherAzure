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
                    <td class="HeaderPadding" style="border-width: 0px; text-align: center">
                        <asp:Login ID="Login1" runat="server" OnAuthenticate= "ValidateUser" LoginButtonText="Log på" PasswordRequiredErrorMessage="Password skal udfyldes." RememberMeText="Husk mig." TitleText="Log på" UserNameLabelText="Brugernavn:" UserNameRequiredErrorMessage="Brugernavn skal udfyldes.">
                            <FailureTextStyle ForeColor="Black" />
                        </asp:Login>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
