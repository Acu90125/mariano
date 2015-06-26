<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="inc_turnosprestador.ascx.cs"
    Inherits="logeo.inc_turnosprestador" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<h3>
    Mis Turnos</h3>
<table border="0" cellpadding="0" cellspacing="0" class="resultados">
    <tr class="resultadosCab">
        <td colspan="2">
            Turnos
            <asp:TextBox ID="txtfecha" runat="server" Visible="true" CssClass="inputLogin"> </asp:TextBox>
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
            <asp:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtfecha"
                Format="dd/MM/yyyy">
            </asp:CalendarExtender>
            &nbsp;<asp:ImageButton ID="imgPopup" ImageUrl="images/calendar.png" ImageAlign="Bottom"
                runat="server" Visible="true" />
            &nbsp;
            <asp:CheckBox ID="todos" runat="server" value="1" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Ver" OnClick="Button2_Click" />
            <br />
            <br />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
        <td>
            <br />
                   <%--  <asp:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" TargetControlID="Panel1"
                    Radius="20">
                </asp:RoundedCornersExtender>--%>
                <asp:Panel ID="Panel1" runat="server" Width="450px">
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <strong>
                                            <br />
                                            <%-- <asp:CheckBox ID="Ident" runat="server" Checked='<%# Convert.ToBoolean(Eval("identturno")) %>'/>--%>
                                            <%-- <asp:HyperLink ID="HyperLinkThread" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"identturno")%>'
        NavigateUrl='<%#GetDetail(DataBinder.Eval(Container.DataItem,"identturno"))%>'/>--%>
                                            <%# DataBinder.Eval(Container.DataItem, "fechaturno")%></strong> -
                                        <%# DataBinder.Eval(Container.DataItem, "estadoturnoletras")%><br>
                                        <%# DataBinder.Eval(Container.DataItem, "nombrepaciente")%>
                                        <%# DataBinder.Eval(Container.DataItem, "apellidopaciente")%><br>
                                        <%# DataBinder.Eval(Container.DataItem, "tipodoc")%>
                                        <%# DataBinder.Eval(Container.DataItem, "nrodoc")%><br>
                                        Obra Social:
                                        <%# DataBinder.Eval(Container.DataItem, "nombreos")%>
                                        <%# DataBinder.Eval(Container.DataItem, "nombrecobertura")%><br>
                                        Nro Afiliado:
                                        <%# DataBinder.Eval(Container.DataItem, "carnet")%><br>
                                        <%# DataBinder.Eval(Container.DataItem, "etiquetaextraa") != null && !String.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "etiquetaextraa").ToString()) ? DataBinder.Eval(Container.DataItem, "etiquetaextraa").ToString() + DataBinder.Eval(Container.DataItem, "extraa").ToString() : "" %><br>
                                        <%# DataBinder.Eval(Container.DataItem, "etiquetaextrab") != null && !String.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "etiquetaextrab").ToString()) ? DataBinder.Eval(Container.DataItem, "etiquetaextrab").ToString() + DataBinder.Eval(Container.DataItem, "extrab").ToString() : "" %><br>
                                        <%# DataBinder.Eval(Container.DataItem, "etiquetaextrac") != null && !String.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "etiquetaextrac").ToString()) ? DataBinder.Eval(Container.DataItem, "etiquetaextrac").ToString() + DataBinder.Eval(Container.DataItem, "extrac").ToString() : "" %><br>
                                        <%# DataBinder.Eval(Container.DataItem, "etiquetaextrad") != null && !String.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "etiquetaextrad").ToString()) ? DataBinder.Eval(Container.DataItem, "etiquetaextrad").ToString() + DataBinder.Eval(Container.DataItem, "extrad").ToString() : "" %><br>
                                        Especialidad: &nbsp;<strong><%# DataBinder.Eval(Container.DataItem, "especialidad")%></strong><br>
                                        Solicitado por:
                                        <%# DataBinder.Eval(Container.DataItem, "prestadororigen")%>
                                        <%# DataBinder.Eval(Container.DataItem, "fechapedido")%>
                                        desde el Centro
                                        <%# DataBinder.Eval(Container.DataItem, "centroderiv")%><br>
                                    </td>
                                    <td style="width:20px;" >
                                      
                                    </td>
                                  
                                    <td>
                                        <asp:Button ID="Atender" runat="server" Text="Atender Paciente" Style="width: 150px;"
                                            CommandName="presente" CommandArgument='<%#Eval("identturno") %>' />
                                        <br />
                                        <asp:Button ID="anunciar" runat="server" Text="Anunciar" Style="width: 150px;" CommandName="anunciar"
                                            CommandArgument='<%#Eval("identturno") %>' />
                                        <br />
                                        <asp:Button ID="ausente" runat="server" Text="No Concurrio" Style="width: 150px;"
                                            CommandName="ausente" CommandArgument='<%#Eval("identturno") %>' />
                                        <br />
                                        <asp:Button ID="RDM" runat="server" Text="Ver R.M.D." Style="width: 150px;" />
                                        <br />
                                        <asp:Button ID="Datos_Paciente" runat="server" Text="Ver Datos Paciente" Style="width: 150px;" />
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:Repeater>
                </asp:Panel>
        </td>
    </tr>
</table>
