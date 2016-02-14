<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="AltaExcursion.aspx.cs" Inherits="PresentacionWeb.AltaExcursion" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 runat="server">Alta Excursion</h1>
    <br />
    <br />
    <asp:Label ID="lblCodigo" runat="server" Text="Codigo" CssClass="control-label" AssociatedControlID="txtCodigo"></asp:Label>
    <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion" CssClass="control-label" AssociatedControlID="txtDescripcion"></asp:Label>
    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio" CssClass="control-label" AssociatedControlID="fechaInicio"></asp:Label>
    <asp:Calendar ID="fechaInicio" runat="server" CssClass="form-control"></asp:Calendar>
    <br />
    <br />
    <asp:Label ID="lblDiasTraslado" runat="server" Text="Dias de Traslado" CssClass="control-label" AssociatedControlID="txtDiasTraslado"></asp:Label>
    <asp:TextBox ID="txtDiasTraslado" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblCostoDiario" runat="server" Text="Costo Diario" CssClass="control-label" AssociatedControlID="txtCostoDiario"></asp:Label>
    <asp:TextBox ID="txtCostoDiario" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblPuntos" runat="server" Text="Puntos" CssClass="control-label" AssociatedControlID="txtPuntos"></asp:Label>
    <asp:TextBox ID="txtPuntos" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblDestinos" runat="server" Text="Destinos" CssClass="control-label" AssociatedControlID="grvDestinos"></asp:Label>
    <br />
    <asp:GridView ID="grvDestinos" runat="server" CssClass="table table-hover table-striped" GridLines="None" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Pais" HeaderText="Pais" />
            <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" />
        </Columns>
    </asp:GridView>
</asp:Content>
