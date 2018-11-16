<%@ Page Title="" Language="C#" MasterPageFile="~/View/Profesor/MasterProfesor.master" AutoEventWireup="true" CodeFile="~/Controller/Profesor/PlatoWeb.aspx.cs" Inherits="View_Profesor_PlatoWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <div class="container">
        <div class="text-center">
            <h3><span class="label label-danger">Reservar en Plato a la WEB</span></h3>
            <br />
        </div>
    </div>

    <div class="modal-body" style="margin: 0% 0% 0% 10%">

       
        
         <div class="form-inline" role="form">
             <asp:ImageButton ID="btnigm_calendar" runat="server" ImageUrl="~/Imagenes/calendario 3030.png" />

                <label for="fechanac" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminAgreAdminFechanac" runat="server" Text="Fecha :"></asp:Label></label>
                <asp:TextBox ID="fechanac" runat="server" class="form-control" title="Fecha de Nacimiento"></asp:TextBox>

                <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>

                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMMM/yyyy" PopupButtonID="btnigm_calendar" PopupPosition="BottomRight" TargetControlID="fechanac" />

            </div>


    


          <div class="form-group">
                <label for="ddl_hora" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="Label1" runat="server" Text="Hora :"></asp:Label></label>
                    <asp:DropDownList ID="DDL_Hora" Class="form-control" runat="server">
                        <asp:ListItem Value="1">12</asp:ListItem>
                            <asp:ListItem Value="2">13</asp:ListItem>
                            <asp:ListItem Value="3">14</asp:ListItem>
                            <asp:ListItem Value="4">15</asp:ListItem>
                            <asp:ListItem Value="5">16</asp:ListItem>
                    </asp:DropDownList>               

            </div>


          <div class="form-group">
                <label for="tb_fecha" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="Label2" runat="server" Text="Cantidad Personas :"></asp:Label></label>
                <asp:DropDownList ID="DDL_Cantidad" Class="form-control" runat="server">
                     <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                    </asp:DropDownList>               

            </div>





            <asp:Button ID="btn_Reservar" runat="server" class="btn btn-primary btn-lg" Width="141px" BorderColor="#660033" Visible="True" Text="Reservar" OnClick="btn_Reservar_Click"/>


        </div>
</asp:Content>

