<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/SubMasterAlianzas.master" AutoEventWireup="true" CodeFile="~/Controller/Admin/Compromatic.aspx.cs" Inherits="View_Admin_Compromatic" %>

<%-- Agregue aquí los controles de contenido --%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="text-center">
            <h3><span class="label label-danger">Compromatic</span></h3>
            <asp:Label ID="LB_Mensaje" runat="server" Text=""></asp:Label>
            <br/>
            <asp:Label ID="LB_Link" runat="server" Text=""></asp:Label>
            <br/>
            </div>
        
            <div style="text-align: left">
                <div class="form-inline" role="form">
                    <label for="LB_Select" class="control-label" style="color: #FFFFFF"> 
                        <asp:Label ID="LB_Select" runat="server" Text="Seleccione una Categoria"></asp:Label>
                    </label>
            
                    <br/>
                    <asp:DropDownList ID="DDL_Categoria"  Class="form-control" runat="server" AutoPostBack="True" DataTextField="nomCategoria" DataValueField="Id_cate" Width="402px"></asp:DropDownList>
                 </div>
            </div>
        <div class="text-center">
            <asp:GridView ID="GV_Compramatic" runat="server" CssClass="table table-bordered bs-table" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:ImageField DataImageUrlField="_foto" HeaderText="Foto">
                        <ControlStyle Height="100px" Width="90px" />
                    </asp:ImageField>
                    <asp:BoundField DataField="_nomproducto" HeaderText="Producto" />
                    <asp:BoundField DataField="_desproducto" HeaderText="Descripcion" />
                    <asp:BoundField DataField="_precioproducto" HeaderText="Precio" />
                    <asp:BoundField DataField="_nomempresa" HeaderText="Empresa" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <br />
        </div>
    </div>
    
</asp:Content>

