<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="tbArtista" Text="" runat="server" ></asp:TextBox>
            <asp:Button ID="btBuscarArtista" Text="OK" runat="server" OnClick="btnBuscarArtista_Click" />
            <br />
            <asp:GridView ID="gdArtistas" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
