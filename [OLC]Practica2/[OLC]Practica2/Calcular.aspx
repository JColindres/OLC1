<%@ Page Title="Calcular" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calcular.aspx.cs" Inherits="_OLC_Practica2.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Aqui puedes realizar cualquier calculo y graficas.</h3>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4>Que desea calcular? Escribalo a continuacion</h4>
                    <hr />
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="entrada" CssClass="col-md-2 control-label">Aqui va su codigo .matt</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="entrada" CssClass="form-control" Height="172px" TextMode="MultiLine" Width="646px" />
                        </div>
                    </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="Analizar" Text="Analizar" CssClass="btn btn-default" />
                        &nbsp;&nbsp;
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
            </section>
        </div>
    </div>
</asp:Content>
