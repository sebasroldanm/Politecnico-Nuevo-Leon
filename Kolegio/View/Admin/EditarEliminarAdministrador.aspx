﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/SubMasterAdministrador.master" AutoEventWireup="true" CodeFile="~/Controller/Admin/EditarEliminarAdministrador.aspx.cs" Inherits="View_Admin_EditarEliminarAdministrador" %>

<%-- Agregue aquí los controles de contenido --%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


    <div class="container">
        <div class="text-center">
            <h3><span class="label label-danger">
                <asp:Label ID="L_AdminEditAdminTitulo" runat="server"></asp:Label></span></h3>
            <br />
        </div>
    </div>
    <div class="modal-body" style="margin: 0% 0% 0% 10%">


        <div class="form-inline" role="form">
            <div class="form-group">
                <label for="tb_AministradorAdministradorId" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminEditAdminDocumento" runat="server"></asp:Label></label>
                <asp:TextBox ID="tb_AministradorAdministradorId" runat="server" class="form-control" title="Numero de Documento" MaxLength="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_id" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="tb_AministradorAdministradorId" ValidationGroup="form_ejm" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_AministradorAdministradorId" runat="server" ControlToValidate="tb_AministradorAdministradorId" ValidationExpression="^[0-9]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm"></asp:RegularExpressionValidator>
                <asp:Label ID="L_ErrorAdmin" class="control-label" Style="color: crimson" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>

            </div>

            <div class="form-group">
                <label for="tb_AdministradorAdministradorNombre" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminEditAdminNombre" runat="server"></asp:Label></label>
                <asp:TextBox ID="tb_AdministradorAdministradorNombre" runat="server" class="form-control" title="Nombres Administrador" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_nombre" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="tb_AdministradorAdministradorNombre" ValidationGroup="form_ejm2" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_AdministradorAdministradorNombre" runat="server" ControlToValidate="tb_AdministradorAdministradorNombre" ValidationExpression="^[a-zA-Z0-9ñÑ\s]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm2"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group">
                <label class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminEditAdminApellido" runat="server"></asp:Label></label>
                <asp:TextBox ID="tb_AdministradorAdministradorApellido" runat="server" MaxLength="30" class="form-control" title="Apellidos Administrador"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rv_apellido" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="tb_AdministradorAdministradorApellido" ValidationGroup="form_ejm2" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_AdministradorAdministradorApellido" runat="server" ControlToValidate="tb_AdministradorAdministradorApellido" ValidationExpression="^[a-zA-Z0-9ñ\sÑ]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm2"></asp:RegularExpressionValidator>
            </div>
            <asp:Image ID="ImagenEst" runat="server" Height="80px" Width="60px" for="TB_Usuaro" />


        </div>
        <br />
        <br />



        <div class="form-inline" role="form">

            <label for="lugarnac1" class="control-label" style="color: #FFFFFF">
                <asp:Label ID="L_AdminEditAdminDep" runat="server"></asp:Label></label>
            <asp:DropDownList ID="ddt_lugarnacimDep" class="form-control" runat="server" DataSourceID="ObjectDataSourceDep" DataTextField="nom_dep" DataValueField="id_dep" AutoPostBack="True" Width="119px"></asp:DropDownList>
            <asp:ObjectDataSource ID="ObjectDataSourceDep" runat="server" SelectMethod="departamento" TypeName="Datos.DUser"></asp:ObjectDataSource>

            <asp:DropDownList ID="DDT_Ciudad" Class="form-control" runat="server" DataSourceID="ODS_Ciudad" DataTextField="nombre_ciudad" DataValueField="id_ciudad" Width="141px">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="ODS_Ciudad" runat="server" SelectMethod="ciudad" TypeName="Datos.DUser">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddt_lugarnacimDep" Name="idDepart" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>

            <div class="form-group">
                <label for="tb_AdministradorFoto" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminEditAdminFoto" runat="server"></asp:Label></label>
                <asp:FileUpload ID="tb_AdministradorFoto" runat="server" accept=".jpg,.png" class="form-control" ErrorMessage="Solo Imagenes" ValidationExpression="(.*).(.jpg|.JPG|.gif|.GIF|.jpeg|.JPEG|.bmp|.BMP|.png|.PNG)$" Width="240px" />
                <label for="fechanac" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminEditAdminFechanac" runat="server"></asp:Label></label>
                <asp:TextBox ID="fechanac" runat="server" class="form-control" title="Fecha de Nacimiento"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_fechaNac" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="fechanac" ValidationGroup="form_ejm2" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator>

                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMMM/yyyy" PopupButtonID="btnigm_calendar" PopupPosition="BottomRight" TargetControlID="fechanac" />

            </div>

            <div class="form-group">


                <asp:ImageButton ID="btnigm_calendar" runat="server" ImageUrl="~/Imagenes/calendario 3030.png" />

            </div>




        </div>
        <br />
        <br />



        <div class="form-inline" role="form">
            <div class="form-group">
                <label for="tb_AdministradorAdministradorCorreo" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminEditAdminCorreo" runat="server"></asp:Label></label>
                <asp:TextBox type="email" runat="server" class="form-control" ID="tb_AdministradorAdministradorCorreo" title="Email" Width="400px" TextMode="Email" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rv_correo" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="tb_AdministradorAdministradorCorreo" ValidationGroup="form_ejm2" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_AdministradorAdministradorCorreo" runat="server" ControlToValidate="tb_AdministradorAdministradorCorreo" ValidationExpression="^[a-zA-Z0-9ñÑ_@./]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm2"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label for="tb_AdministradorAdministradorDireccion" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_ADminEditAdminDir" runat="server"></asp:Label></label>
                <asp:TextBox type="text" runat="server" class="form-control" ID="tb_AdministradorAdministradorDireccion" title="Direccion" Width="400px" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rv_direccion" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="tb_AdministradorAdministradorDireccion" ValidationGroup="form_ejm2" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_AdministradorAdministradorDireccion" runat="server" ControlToValidate="tb_AdministradorAdministradorDireccion" ValidationExpression="^[a-zA-Z0-9ñÑ,.#/\s]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm2"></asp:RegularExpressionValidator>
            </div>

        </div>
        <br />
        <br />
        <div class="form-inline" role="form">

            <div class="form-group">
                <label for="tb_AdministradorTelefono" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminEditAdminTel" runat="server"></asp:Label></label>
                <asp:TextBox type="text" class="form-control" ID="tb_AdministradorTelefono" title="Telefono" MaxLength="15" runat="server" TextMode="Phone"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rv_telefono" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="tb_AdministradorTelefono" ValidationGroup="form_ejm2" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_AdministradorTelefono" runat="server" ControlToValidate="tb_AdministradorTelefono" ValidationExpression="^[a-z0-9()-+\s]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm2"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label for="tb_AdministradorUsuario" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminEditAdminUser" runat="server"></asp:Label></label>
                <asp:TextBox type="text" class="form-control" ID="tb_AdministradorUsuario" title="Usuario" runat="server" MaxLength="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rv_usuario" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="tb_AdministradorUsuario" ValidationGroup="form_ejm2" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_AdministradorUsuario" runat="server" ControlToValidate="tb_AdministradorUsuario" ValidationExpression="^[a-zA-Z0-9ñÑ]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm2"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group">
                <label for="tb_AdministradorContrasenia" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminEditAdminContra" runat="server"></asp:Label></label>
                <asp:TextBox type="text" class="form-control" ID="tb_AdministradorContrasenia" title="Contraseña" runat="server" MaxLength="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rv_contrasenia" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="tb_AdministradorContrasenia" ValidationGroup="form_ejm2" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_AdministradorContrasenia" runat="server" ControlToValidate="tb_AdministradorContrasenia" ValidationExpression="^[a-zA-Z0-9ñÑ]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm2"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label for="estado" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminEditAdminEstado" runat="server"></asp:Label></label>&nbsp;
                       <asp:DropDownList ID="DDL_Estado" Class="form-control" runat="server">
                       </asp:DropDownList>
            </div>

        </div>

        <br />
        <br />
        <br />
        <br />
        <div class="form-inline container">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="btn_AdministradorAceptar" runat="server" class="btn btn-success btn-lg" Width="141px" BorderColor="#660033" OnClick="btn_AdministradorAceptar_Click" ValidationGroup="form_ejm" />
            <asp:Button ID="btn_AdministradorEditar" runat="server" class="btn btn-primary btn-lg" Width="141px" BorderColor="#660033" OnClick="btn_AdministradorEdditar_Click" Visible="False" ValidationGroup="form_ejm2" />
            <asp:Label ID="L_Error" runat="server" CssClass="label-danger" Font-Bold="True" Font-Size="Large" ForeColor="White"></asp:Label>
            <asp:Button ID="btn_AdministradorNuevo" runat="server" class="btn btn-info btn-lg" Width="141px" BorderColor="#660033" OnClick="btn_AdministradorNuevo_Click" Visible="False" />
        </div>
    </div>
</asp:Content>