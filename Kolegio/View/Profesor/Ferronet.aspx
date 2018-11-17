<%@ Page Title="" Language="C#" MasterPageFile="~/View/Profesor/MasterProfesor.master" AutoEventWireup="true" CodeFile="~/Controller/Profesor/Ferronet.aspx.cs" Inherits="View_Profesor_Ferronet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <div class="container">
        <div class="text-center">
            <h3><span class="label label-danger">Ferronet</span></h3>
             <br />
        </div>

          <div class="container">
            <div class="text-center">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Ferronet.jpeg" Width="179px" Height="76px" />
                <br />
            </div>
        </div>
    </div>

    <div class="modal-body" style="margin: 0% 0% 0% 5%">

       
        
         <div class="form-inline" role="form">

                <asp:TextBox ID="tb_buscar" runat="server" class="form-control" title="Buscar Productos" Width="433px"></asp:TextBox>
                <asp:Button ID="btn_buscarproducto" runat="server" class="btn btn-primary btn-lg" Width="141px" BorderColor="#660033" Visible="True" Text="Buscar" OnClick="btn_buscarproducto_Click"/>

             </div>
        
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="GV_Ferronet" runat="server" CssClass="table table-bordered bs-table" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" AutoGenerateColumns="False" >
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:ImageField DataImageUrlField="Imagen" HeaderText="Imagen">
                    <ControlStyle Height="100px" Width="90px" />
                </asp:ImageField>
                <asp:BoundField DataField="CodigoProducto" HeaderText="Codigo" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                <asp:BoundField DataField="NombreSubsede" HeaderText="Sede" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
         </asp:GridView>

    </div>



</asp:Content>
