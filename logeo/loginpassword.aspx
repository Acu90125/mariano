<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginpassword.aspx.cs" Inherits="logeo.loginpassword" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="App_Themes/acuario.css" rel="stylesheet" type="text/css" />
     <link href="http://dev.acuariosalud.com/favicon.ico" type="image/x-icon" rel="Shortcut Icon" />
    
    <title>Acuario Login</title>
   
      <script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.7.1.min.js"></script>
        <script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/modernizr/modernizr-2.0.6-development-only.js"></script>
     
          <style type="text/css">
          #UpdatePanel1 { 
           width:300px; height:270px;
          background-color:#1172B3;
          padding:15px;
         -moz-border-radius: 10px;
         -webkit-border-radius:10px;    
         }  
             
        </style>
</head>
<body>

    <form id="form1" runat="server">
    <br />
   
<br />
<br />
<br />

     <div style="padding-top: 10px" align="center">
    
      <asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo_acuario_salud.png" />
      <br />
      <br />    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
    <ContentTemplate>
      <table>
        <tr>
            <td>
                &nbsp;</td>
            <td style="color: #FFFFFF" >
               <asp:Label ID="Label2" runat="server" Text="Tipo de Documento" 
                          Visible="False"></asp:Label></td>
        </tr>
          <caption>
              
              </tr>
              <tr>
                  <td>
                      &nbsp;</td>
                  <td > 
                      <asp:DropDownList ID="ident" runat="server" Height="19px" Width="168px" 
                          Visible="False" CssClass="inputLogin">
                      </asp:DropDownList>
                  </td>
              </tr>
              <tr>
                  <td>
                      &nbsp;</td>
                 <td style="color: #FFFFFF" >
                      Usuario</td>
              </tr>
              <tr>
                  <td>
                      &nbsp;</td>
                  <td >
                      <asp:TextBox ID="txtusuario" runat="server" CssClass="inputLogin"  ></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td >
                      </td>
                 
              </tr>
              <tr>
                  <td >
                  </td>
                 
              </tr>
              <tr>
                  <td >
                      &nbsp;</td>
                   <td  >
                       &nbsp;</td>
              </tr>
              <tr>
                  <td>
                  </td>
                  <td >
                      <asp:Image ID="imCaptcha" runat="server" ImageUrl="validar.aspx"/>
                      <br/>
                  </td>
              </tr>
              <tr>
                  <td >
                  </td>
                  <td style="color: #FFFFFF" >
                      Ingrese el Código</td>
              </tr>
              <tr>
                  <td>
                      &nbsp;</td>
                  <td  >
                      <asp:TextBox ID="txtcaptcha" runat="server" CssClass="inputLogin" ></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>
                      &nbsp;</td>
                    <td >
                       
                           &nbsp;</td>
              </tr>
              <tr>
                  <td> <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                        </asp:ToolkitScriptManager> 
                 
                  
                    
                  </td>
                  <td  >
                      &nbsp;</td>
              </tr>
              <tr>
                  <td>
                      &nbsp;</td>
                  <td align="right" >
                 
                      
                           <label>
                             <asp:Button ID="inputNewLogin1" runat="server" onclick="Button1_Click" Text="Recordar Contraseña" />                            
                           </label>
                          
                  </td>
              </tr>
              </input></caption>
          <tr>
              <td >
                  </td>
              <td align="right" >
                
          </tr>
          <tr>
              <td>
                  &nbsp;</td>
              <td align="center" >
              <div class="error">
                  <asp:Label ID="Label3" runat="server" style="text-align: justify"></asp:Label>
                  </div>
                   <div class="error">
                  <asp:Label ID="Label4" runat="server" style="text-align: justify"></asp:Label>
                  </div>
                   <div class="error">
                  <asp:Label ID="Label5" runat="server" style="text-align: justify"></asp:Label>
                  </div>
                   <div class="error">
                  <asp:Label ID="Label6" runat="server" style="text-align: justify"></asp:Label>
                  </div>
                   <div class="error">
                  <asp:Label ID="Label7" runat="server" style="text-align: justify"></asp:Label>
                  </div>
                   <div class="error">
                  <asp:Label ID="Label8" runat="server" style="text-align: justify"></asp:Label>
                  </div>
              </td>
          </tr>
    </table>
    
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    </form>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</body>
</html>
<script type="text/javascript">
    if (!Modernizr.borderradius) {
        $.getScript("js/jquery.corner.js", function () {
            $("form").corner();
        });
    }
</script>
