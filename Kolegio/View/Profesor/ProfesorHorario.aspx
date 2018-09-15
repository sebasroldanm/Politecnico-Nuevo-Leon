﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/Profesor/MasterProfesor.master" AutoEventWireup="true" CodeFile="~/Controller/Profesor/ProfesorHorario.aspx.cs" Inherits="View_Profesor_ProfesorHorario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="container">
    <div class="text-center">
             <h3><span class="label label-info"><asp:Label ID="L_ProfeConfigHorario" runat="server"></asp:Label></span></h3>
         </div>


        <asp:Button ID="btn_descargar" runat="server"  class="btn btn-success btn-lg" Width="222px" BorderColor="#660033" OnClick="btn_descargar_Click"/>



        <asp:GridView ID="GridView1" runat="server"  CssClass="table table-bordered bs-table" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="#DCDCDC" />
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

