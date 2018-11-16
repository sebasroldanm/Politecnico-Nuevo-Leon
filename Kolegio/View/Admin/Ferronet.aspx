<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/SubMasterAlianzas.master" AutoEventWireup="true" CodeFile="~/Controller/Admin/Ferronet.aspx.cs" Inherits="View_Admin_Ferronet" %>

<%-- Agregue aquí los controles de contenido --%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="text-center">
            <h3><span class="label label-danger">Ferronet</span></h3>
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
                    <asp:DropDownList ID="DDL_Categoria"  Class="form-control" runat="server" AutoPostBack="True" DataTextField="nomCategoria" DataValueField="Id_cate" Width="402px">
                        <asp:ListItem Value="1">Tornilleria</asp:ListItem>
                        <asp:ListItem Value="2">Pegamentos</asp:ListItem>
                        <asp:ListItem Value="3">Electricidad</asp:ListItem>
                        <asp:ListItem Value="4">Elementos de Proteccion Personal</asp:ListItem>
                        <asp:ListItem Value="5">Elementos de Pinturas</asp:ListItem>
                        <asp:ListItem Value="6">Herramientas</asp:ListItem>
                        <asp:ListItem Value="7">Plomeria</asp:ListItem>
                        <asp:ListItem Value="8">Otros</asp:ListItem>
                    </asp:DropDownList>
                 </div>
            </div>
        <div class="text-center">
            <asp:GridView ID="GV_Compramatic" runat="server" CssClass="table table-bordered bs-table" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
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




