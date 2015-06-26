<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="principal.aspx.cs" Inherits="logeo.principal" %>
<%@ Register src="pie.ascx" tagname="pie" tagprefix="uc2" %>
<%@ Register src="cabecera.ascx" tagname="cabecera" tagprefix="uc1" %>

<%@ Register src="inc_turnosprestador.ascx" tagname="inc_turnosprestador" tagprefix="uc3" %>
<%@ Register src="inc_turnosguardia.ascx" tagname="inc_turnosguardia" tagprefix="uc4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="App_Themes/acuario.css" rel="stylesheet" type="text/css" />
    <title>Principal</title>
  
</head>
<body>
<form id="form1" runat="server">  
  <uc1:cabecera ID="cabecera1" runat="server" />
 <div class="contenido" id="divContent">

    <div>
     <table align="center">
            <tr>
                <td colspan = "2">
                      <h2>Bienvenido <span class="h2Nombre">
                          <asp:Label ID="Label1" runat="server"></asp:Label> </span></h2></td>
               
            </tr>
           
        </table>
    </div>
    
              <uc2:pie ID="pie1" runat="server" />             
               <uc3:inc_turnosprestador ID="inc_turnosprestador1" runat="server" />
              <uc4:inc_turnosguardia ID="inc_turnosguardia1" runat="server" />
    
     </div>
   
        </form>
</body>
</html>
