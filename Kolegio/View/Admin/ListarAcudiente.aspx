<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/SubMasterAcudiente.master" AutoEventWireup="true" CodeFile="~/Controller/Admin/ListarAcudiente.aspx.cs" Inherits="View_Admin_ListarAcudiente" %>

<%-- Agregue aquí los controles de contenido --%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
    <div class="text-center">
             <h3><span class="label label-danger"><asp:Label ID="L_AdminListaAcuTitulo" runat="server"></asp:Label></span></h3>
         <br />
         </div>
    </div>


    <div class="container">
                  <asp:Button ID="btn_descargar" runat="server"  class="btn btn-success btn-lg" Width="222px" BorderColor="#660033" OnClick="btn_descargar_Click"/>



    <asp:GridView ID="GridView1" runat="server"  CssClass="table table-bordered bs-table" AutoGenerateColumns="False" DataSourceID="DAOacu" BackColor="White" BorderColor="#660033" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" AllowPaging="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="3">
        <AlternatingRowStyle BackColor="#F7F7F7" BorderColor="#0677D2" />
        <Columns>
             <asp:ImageField DataImageUrlField="fotoacudiente" HeaderText="Acudiente">
                        <ControlStyle Height="100px" Width="90px" />
                        <HeaderStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                    </asp:ImageField>
            <asp:BoundField DataField="apeacudiente" HeaderText="Apellido" />
            <asp:BoundField DataField="nomacudiente" HeaderText="Nombre" >
            <ControlStyle Font-Size="Large" />
            </asp:BoundField>
            <asp:BoundField DataField="docacudiente" HeaderText="Documento" />
            <asp:BoundField DataField="telefonoacudiente" HeaderText="Telefono" />
            <asp:BoundField DataField="useracudiente" HeaderText="Usuario" />
            <asp:BoundField DataField="claveacudiente" HeaderText="Contraseña" />
                           <asp:CommandField SelectText="Editar" ShowSelectButton="True" HeaderImageUrl="~/Imagenes/edituser2.png" SelectImageUrl="~/Imagenes/EditarUser.png" UpdateImageUrl="~/Imagenes/EditarUser.png" />

             <asp:ImageField DataImageUrlField="fotoestudiante" HeaderText="Estudiante">
                 <ControlStyle Height="100px" Width="90px" />
                 <HeaderStyle HorizontalAlign="Justify" VerticalAlign="Middle" BackColor="#DE0101" />
                 <ItemStyle BackColor="#FFDFDF" />
             </asp:ImageField>
            <asp:BoundField DataField="nomestudiante" HeaderText="Nombre" >
             <ControlStyle BackColor="Red" BorderColor="Lime" ForeColor="Yellow" />
             <HeaderStyle BackColor="#DE0101" />
             <ItemStyle BackColor="#FFDFDF" />
             </asp:BoundField>
             <asp:BoundField DataField="apeestudiante" HeaderText="Apellido" >
             <HeaderStyle BackColor="#DE0101" />
             <ItemStyle BackColor="#FFDFDF" />
             </asp:BoundField>
             <asp:BoundField DataField="docestudiante" HeaderText="Documento" >
             <HeaderStyle BackColor="#DE0101" />
             <ItemStyle BackColor="#FFDFDF" />
             </asp:BoundField>
             <asp:BoundField DataField="telefonoestudiante" HeaderText="Telefono" >
             <HeaderStyle BackColor="#DE0101" />
             <ItemStyle BackColor="#FFDFDF" />
             </asp:BoundField>

        </Columns>
        <EmptyDataTemplate>
            <br />
&nbsp;
        </EmptyDataTemplate>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <SortedAscendingCellStyle BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>


        <asp:ObjectDataSource ID="DAOacu" runat="server" SelectMethod="listaacuestu" TypeName="Datos.DUser"></asp:ObjectDataSource>


</div>



    </asp:Content>