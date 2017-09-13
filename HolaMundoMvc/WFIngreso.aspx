<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFIngreso.aspx.cs" Inherits="HolaMundoMvc.WFIngreso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1><asp:Label ID="lblTitulo" runat="server"></asp:Label></h1>

            <table>
                <tr>
                    <td><asp:Label ID="Label1" runat="server"></asp:Label></td>
                    <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                </tr>


                <tr>
                    <td><asp:Label ID="Label2" runat="server"></asp:Label></td>
                    <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                </tr>


                <tr>
                    <td><asp:Label ID="Label3" runat="server"></asp:Label></td>
                    <td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" />
                        <asp:Button ID="Button2" runat="server" Visible="false" OnClick="Button2_Click" />
                    </td>
                    <td><asp:Label ID="lblMensaje" runat="server"></asp:Label></td>
                </tr>
                
                <tr><td><asp:GridView ID="GridView1" runat="server">

                             <Columns>

            <asp:HyperLinkField
                 HeaderText="Seleccione un Item"
                 DataNavigateUrlFormatString="/WfIngreso.aspx?code={0}"
                DataNavigateUrlFields="Id"
                DataTextField="Id"/>

         </Columns>
                        </asp:GridView></td></tr>

            </table>     
        </div>
        

    </form>
</body>
</html>
