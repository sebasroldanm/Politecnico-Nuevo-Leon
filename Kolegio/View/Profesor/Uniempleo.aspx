﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/Profesor/MasterProfesor.master" AutoEventWireup="true" CodeFile="~/Controller/Profesor/Uniempleo.aspx.cs" Inherits="View_Profesor_Uniempleo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container">
        <div class="text-center">
            <h3><span class="label label-danger">Uniempleo Ofertas de Empleo</span></h3>
            <br />
        </div>
    </div>

    <div class="modal-body" style="margin: 0% 0% 0% 5%">


        <div class="container">
            <div class="text-center">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/maletin.png" Width="90px" />

                <h5><span class="label label-info">La mejor opcion para conseguir Empleo</span></h5>
                <label class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminAgreEstuUser" runat="server" Text="Para mas Informacion :"></asp:Label></label>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://uniempleo.ddns.net" Target="_blank">Uniempleo.com</asp:HyperLink>
                <br />
            </div>
        </div>


        <div class="form-inline" role="form">

            <asp:TextBox ID="tb_buscar" runat="server" class="form-control" title="Buscar Ofertas" Width="433px"></asp:TextBox>
            <asp:Button ID="btn_buscaroferta" runat="server" class="btn btn-primary btn-lg" Width="141px" BorderColor="#660033" Visible="True" Text="Buscar" OnClick="btn_buscaroferta_Click" />
            <br />
            <br />
            <br />

        </div>


        <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered bs-table" AllowPaging="True" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="4">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:BoundField DataField="Nombre_oferta" HeaderText="Empleo" />
                <asp:BoundField DataField="Sueldo" HeaderText="Sueldo" />
                <asp:BoundField DataField="Horario" HeaderText="Horario" />
                <asp:BoundField DataField="Funciones" HeaderText="Funciones" />
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

