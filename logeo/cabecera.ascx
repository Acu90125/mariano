<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cabecera.ascx.cs" Inherits="logeo.cabecera" %>


<style type="text/css">
    .style1
    {
        height: 64px;
    }
</style>


<script language="javascript" type="text/javascript">

$(document).ready(function(){
   $("a").mouseover(function(event){
      $("#capa").addClass("clasecss");
   });
   $("a").mouseout(function(event){
      $("#capa").removeClass("clasecss");
   });
});

//function TestLinkClick() {
//      if (!confirm("\"hol ,\" athletic.\"")) return false;
// 
//}

</script>


<div class="cabeza" id="cabezaContent">
	<table border="0" width="100%" cellpadding="0" cellspacing="0">
    <tr valign="top">
      <td width="1%" class="style1">
       	
		
          <asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo_1.png" />
		     
	  </td>
      <td width="97%" nowrap="nowrap" class="style1">
		<div align="right">
		
              <asp:Image ID="Image2" runat="server" ImageUrl="~/images/logoacuario60c.png" />
        	<span class="acutitulo">&nbsp;</span> 
		</div>
	  </td>
      <td width="1%" nowrap="nowrap" class="style1">
	  	<div id="cabeza_logo">Sistema de Gesti&oacute;n M&eacute;dica para<br />
      	la Atenci&oacute;n Primaria de la Salud</div>
	  </td>
      <td width="1%">

      <asp:HyperLink ID="HyperLink1" runat="server" Text="Salir"  NavigateUrl="~/"></asp:HyperLink>
     
     
      
       

      <br />
      <br />

      
        <br />
          
       </td>
    </tr>
  </table>



</div>


<div id="imgLOAD" style="text-align:center; z-index:110; width:100%; height:100%; position:fixed; left:0px; top:0px; background-color:#FFFFFF; ">
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<script type='text/javascript'>
    function noImgLoad() {
        document.getElementById("imgLOAD").style.display = "none";
    }
</script>
<a href="javascript:noImgLoad();" title="cerrar"><img src="images/cargando.gif" border="0" /></a><br />

</div>


