<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="logeo.inicio" %>
<%@ Register src="pie.ascx" tagname="pie" tagprefix="uc2" %>
<%@ Register src="cabecera.ascx" tagname="cabecera" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  
  
<head runat="server">
<link href="App_Themes/acuario.css" rel="stylesheet" type="text/css" />

    <title>Inicio</title>

</head>

<body>
   <uc1:cabecera ID="cabecera1" runat="server" />
  <div class="contenido" id="divContent">
    <form id="form1" runat="server">
<br />
    <div>
    
        <br />

        <table align="center" class="style1">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                      <h2>Bienvenido <span class="h2Nombre">
                          <asp:Label ID="Label1" runat="server"></asp:Label> </span></h2></td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                     <asp:DropDownList ID="centro" runat="server" Height="19px" Width="168px" 
                          Visible="true" CssClass="inputLogin" AutoPostBack="false" 
                       >
                      </asp:DropDownList>
                      
                      
                      
                      </td>
            </tr>
            <tr>
                <td style="margin-left: 80px">
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:RadioButton ID="si" runat="server" Visible="False" GroupName="acuario" 
                        Text ="si" />
                    <br />
                    <asp:RadioButton ID="no" runat="server" Checked="True" Visible="False" GroupName="acuario" Text ="no" />
                </td>
            </tr>
            <tr>
                <td>
                                          
                </td>
                <td>
                     <asp:Button ID="inputNewLogin1" runat="server"  Text="Continuar" 
                         onclick="inputNewLogin1_Click1"     />   </td>
            </tr>
        </table>
        <br />
        <br />
    
    </div>

  
    </form>
  <uc2:pie ID="pie1" runat="server" />
 </div>
</body>
</html>
  