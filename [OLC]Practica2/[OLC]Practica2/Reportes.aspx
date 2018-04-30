<%@ Page Title="Manuales" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="_OLC_Practica2.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Esta es la gramatica:</h3>
    <p>&nbsp;</p>
<p><img ID="imagen1" src="~/imagenes/gramatica1.png" runat="server" visible="true"/></p>
<p><img ID="imagen2" src="~/imagenes/gramatica2.png" runat="server" visible="true"/></p>
    <h3>Esta es la  precedencia y asociatividad de operadores</h3>
<p><img ID="imagen3" src="~/imagenes/aso.png" runat="server" visible="true"/></p>

&nbsp;

</asp:Content>
