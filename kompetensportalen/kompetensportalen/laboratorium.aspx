<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="laboratorium.aspx.cs" Inherits="kompetensportalen.laboratorium" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <p>
            <asp:Button ID="Button1" runat="server" Height="32px" OnClick="Button1_Click" Text="Button" />
        </p>
    </form>
</body>
</html>
