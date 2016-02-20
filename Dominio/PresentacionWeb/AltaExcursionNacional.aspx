<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="AltaExcursionNacional.aspx.cs" Inherits="PresentacionWeb.AltaExcursion" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
    <script src="JavaScript/ValidarAltaExcursion.js"></script>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 runat="server">Alta Excursion Nacional</h1>
    <br />
    <br />
    <asp:Label ID="lblCodigo" runat="server" Text="Codigo" CssClass="control-label" AssociatedControlID="txtCodigo"></asp:Label>
    <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCodigo" ErrorMessage="Por favor ingrese un codigo alfanumerico" CssClass="alert alert-danger"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion" CssClass="control-label" AssociatedControlID="txtDescripcion"></asp:Label>
    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="Por favor ingrese un codigo alfanumerico" CssClass="alert alert-danger"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio" CssClass="control-label"></asp:Label>
    <asp:Calendar ID="fechaInicio" runat="server"></asp:Calendar>
    <br />
    <br />
    <asp:Label ID="lblDiasTraslado" runat="server" Text="Dias de Traslado" CssClass="control-label" AssociatedControlID="txtDiasTraslado"></asp:Label>
    <asp:TextBox ID="txtDiasTraslado" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Por favor ingrese la cantidad de dias de traslado" ControlToValidate="txtDiasTraslado" CssClass="alert alert-danger"></asp:RequiredFieldValidator>
    <br />
    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="La cantidad de dias de traslado debe ser mayor a 0" ClientValidationFunction="ValidarDiasTraslado" ControlToValidate="txtDiasTraslado" CssClass="alert alert-danger"></asp:CustomValidator>
    <br />
    <br />
    <asp:Label ID="lblCostoDiario" runat="server" Text="Costo Diario" CssClass="control-label" AssociatedControlID="txtCostoDiario"></asp:Label>
    <asp:TextBox ID="txtCostoDiario" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Por favor ingrese el costo diario" ControlToValidate="txtCostoDiario" CssClass="alert alert-danger"></asp:RequiredFieldValidator>
    <br />
    <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="El costo diario debe ser mayor a 0" ClientValidationFunction="ValidarPuntos" ControlToValidate="txtCostoDiario" CssClass="alert alert-danger"></asp:CustomValidator>
    <br />
    <br />
    <asp:Label ID="lblPuntos" runat="server" Text="Puntos" CssClass="control-label" AssociatedControlID="txtPuntos"></asp:Label>
    <asp:TextBox ID="txtPuntos" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Por favor ingrese la cantidad de puntos" ControlToValidate="txtPuntos" CssClass="alert alert-danger"></asp:RequiredFieldValidator>
    <br />
    <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="La cantidad de puntos debe ser mayor a 0" ClientValidationFunction="ValidarCostoDiario" ControlToValidate="txtPuntos" CssClass="alert alert-danger"></asp:CustomValidator>
    <br />
    <br />
    <asp:Label ID="lblDescuento" runat="server" Text="Descuento" CssClass="control-label" AssociatedControlID="txtDescuento"></asp:Label>
    <asp:TextBox ID="txtDescuento" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblDestinos" runat="server" Text="Destinos" CssClass="control-label" AssociatedControlID="grvDestinos"></asp:Label>
    <br />
    <asp:GridView ID="grvDestinos" runat="server" CssClass="table table-hover table-striped" GridLines="None" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Pais" HeaderText="Pais" />
            <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" />
            <asp:TemplateField HeaderText="Seleccionar">
                <ItemTemplate>
                    <asp:CheckBox runat="server" ID="chkSel"></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cantidad de Dias">
                <ItemTemplate>
                    <asp:TextBox ID="txtCant" runat="server" Height="20px" Width="36px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="txtGuardar" runat="server" Text="Guardar" CssClass="btn btn-default" OnClick="txtGuardar_Click" OnClientClick="ValidoSeleccionDestino"/>
    <br />
    <br />
    <br />
    <asp:Label ID="lblMensajes" runat="server" Text="" CssClass="alert alert-danger"></asp:Label>
</asp:Content>
