<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pie.ascx.cs" Inherits="logeo.pie" %>

 <script language="javascript" type="text/javascript">
    document.getElementById("imgLOAD").style.display = "none";
</script>
<script type='text/javascript'>


function alertar(tipo)
{
	document.getElementById('alertasesion').style.visibility="visible";
	if (tipo == 1){
		document.getElementById('alertasesion').innerHTML="Se esta terminando el tiempo de sesión!";
	}
	if (tipo == 2){
		document.getElementById('alertasesion').innerHTML="Se agotó el tiempo de sesión!\nDeberá registrarse nuevamente en el sistema!";
	}
}
function desalertar()
{
	document.getElementById('alertasesion').style.visibility="hidden";
	document.getElementById('alertasesion').innerHTML="";
}

</script>
<div id="ContainerDiv">
    <div id="InnerContainer">
        <div id="TheBelowDiv">
            <div class="pie" id="pieContent"  >
<table border="0" width="100%" cellpadding="0" cellspacing="0" style="bottom: auto">
  <tr>
    <td valign="middle">
       <div align="left">      
        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/logo_2.png" />
       
       </div>    </td>
    <td>
      <p>Plataforma Argentina de Salud <br />
        Moreno 634, piso 4 Ciudad Aut&oacute;noma de Buenos Aires (C1091AAN) - Buenos Aires, Argentina <br />
          tel. (+54)(+11) 4833 0055 -<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>    <a title="Enviar e-mail" href="mailto:info@telemed.org.ar">info@telemed.org.ar</a><br />
      &copy;2007 -   - Todos los Derechos   Reservados<br />
      Hecho el dep&oacute;sito que marca la Ley No 11.723 bajo el numero   737.777
      <br />
      </p>    </td>
    <td>&nbsp;</td>
    <td valign="middle">
    	<div align="right"><img src="images/logo_2.png" /></div>    </td>
  </tr>
</table>
            </div>
       </div>
    </div>
</div>
   <script language="javascript" type="text/javascript">
    alto = document.body.offsetHeight;
    alto = alto - 160;
    document.getElementById('divContent').style.minHeight = alto + "px";

    document.getElementById('divContent').style.overflow = "auto";
    anchoC = document.getElementById('divContent').scrollWidth;
    anchoW = document.getElementById('divContent').offsetWidth;
    document.getElementById('divContent').style.overflow = "visible";
    if (anchoW < anchoC) {
        anchoC = anchoC + 230;
        document.getElementById('pieContent').style.width = anchoC + "px";
        document.getElementById('cabezaContent').style.width = anchoC + "px";
    }
</script>