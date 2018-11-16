<%@ Page Title="" Language="C#" MasterPageFile="~/View/Estudiante/MasterEstudiante.master" AutoEventWireup="true" CodeFile="~/Controller/Estudiante/GamesCol.aspx.cs" Inherits="View_Estudiante_GamesCol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <div class="container">
        <div class="text-center">
            <h3><span class="label label-danger">Noticas de Juegos</span></h3>
            <br />
        </div>
    </div>

      <div class="container">
            <div class="text-center">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/gamecol.jpg" Width="127px" Height="75px" />

                <h5><span class="label label-info">Noticas sobre los mejores Videojuegos</span></h5>
                <label class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminAgreEstuUser" runat="server" Text="Para mas Informacion :"></asp:Label></label>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://GamesCol.ddns.net" Target="_blank">GamesCol.com</asp:HyperLink>
                <br />
            </div>
        </div>

    <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered bs-table"  CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
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

        <Columns>
                    <asp:TemplateField HeaderText="Contenido">
                        <HeaderTemplate>
                            <asp:Label ID="LB_conten" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LB_contenido" runat="server" Text='<%# Bind("contenido") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>


</asp:Content>

