<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/SubMasterProfesor.master" AutoEventWireup="true" CodeFile="~/Controller/Admin/EditarEliminarProfesor.aspx.cs" Inherits="View_Admin_EditarEliminarProfesor" %>

<%-- Agregue aquí los controles de contenido --%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


    <div class="container">
        <div class="text-center">
            <h3><span class="label label-danger">
                <asp:Label ID="L_AdminEditProTitulo" runat="server"></asp:Label></span></h3>
            <br />
        </div>
    </div>
    <div class="modal-body" style="margin: 0% 0% 0% 10%">

        <div class="form-inline" role="form">
            <div class="form-group">
                <label for="tb_DocenteId" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminEditProDocumento" runat="server"></asp:Label></label>
                <asp:TextBox ID="tb_DocenteId" runat="server" class="form-control" title="Numero de Documento" MaxLength="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_id" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="tb_DocenteId" ValidationGroup="form_ejm" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_DocenteId" runat="server" ControlToValidate="tb_DocenteId" ValidationExpression="^[0-9]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm"></asp:RegularExpressionValidator>
                <asp:Label ID="L_ErrorAdmin" class="control-label" Style="color: crimson" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>

            </div>

            <div class="form-group">
                <label for="tb_DocenteNombre" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminEditProNombre" runat="server"></asp:Label></label>
                <asp:TextBox ID="tb_DocenteNombre" runat="server" class="form-control" title="Nombres Docente" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_nombre" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="tb_DocenteNombre" ValidationGroup="form_ejm2" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_DocenteNombre" runat="server" ControlToValidate="tb_DocenteNombre" ValidationExpression="^[a-zA-z\sñÑ]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm2"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group">
                <label class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminEditProApellido" runat="server"></asp:Label></label>
                <asp:TextBox ID="tb_DocenteApellido" runat="server" class="form-control" title="Apellidos Docente" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rv_apellido" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="tb_DocenteApellido" ValidationGroup="form_ejm2" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_DocenteApellido" runat="server" ControlToValidate="tb_DocenteApellido" ValidationExpression="^[a-zA-zñÑ\s]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm2"></asp:RegularExpressionValidator>
            </div>
            <asp:Image ID="ImagenEst" runat="server" Height="80px" Width="60px" for="TB_Usuaro" />

        </div>
        <br />
        <br />



        <div class="form-inline" role="form">

            <label for="lugarnac1" class="control-label" style="color: #FFFFFF">
                <asp:Label ID="L_AdminEditProDep" runat="server"></asp:Label></label>
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
                    <asp:Label ID="L_AdminEditProFoto" runat="server"></asp:Label></label>
                <asp:FileUpload ID="FileUpload1" runat="server" accept=".jpg,.png" class="form-control" ErrorMessage="Solo Imagenes" ValidationExpression="(.*).(.jpg|.JPG|.gif|.GIF|.jpeg|.JPEG|.bmp|.BMP|.png|.PNG)$" Width="240px" />
                <label for="fechanac" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminEditProFechanac" runat="server"></asp:Label></label>
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
                <label for="tb_DocenteCorreo" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminEditProCorreo" runat="server"></asp:Label></label>
                <asp:TextBox type="email" runat="server" class="form-control" ID="tb_DocenteCorreo" title="Email" Width="400px" TextMode="Email" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rv_correo" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="tb_DocenteCorreo" ValidationGroup="form_ejm2" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_DocenteCorreo" runat="server" ControlToValidate="tb_DocenteCorreo" ValidationExpression="^[a-zA-z0-9ñÑ_@./]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm2"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label for="tb_DocenteDireccion" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_ADminEditProDir" runat="server"></asp:Label></label>
                <asp:TextBox type="text" runat="server" class="form-control" ID="tb_DocenteDireccion" title="Direccion" Width="400px" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rv_direccion" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="tb_DocenteDireccion" ValidationGroup="form_ejm2" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_DocenteDireccion" runat="server" ControlToValidate="tb_DocenteDireccion" ValidationExpression="^[a-zA-z0-9ñÑ#,./\s]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm2"></asp:RegularExpressionValidator>
            </div>
        </div>
        <br />
        <br />
        <div class="form-inline" role="form">

            <div class="form-group">
                <label for="tb_DocenteTelefono" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminEditProTel" runat="server"></asp:Label></label>
                <asp:TextBox type="text" class="form-control" ID="tb_DocenteTelefono" title="Telefono" runat="server" MaxLength="15"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rv_telefono" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="tb_DocenteTelefono" ValidationGroup="form_ejm2" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_DocenteTelefono" runat="server" ControlToValidate="tb_DocenteTelefono" ValidationExpression="^[a-z0-9()-+\s]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm2"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label for="tb_DocenteUsuario" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminEditProUser" runat="server"></asp:Label></label>
                <asp:TextBox type="text" class="form-control" ID="tb_DocenteUsuario" title="Usuario" runat="server" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rv_usuario" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="tb_DocenteUsuario" ValidationGroup="form_ejm2" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_DocenteUsuario" runat="server" ControlToValidate="tb_DocenteUsuario" ValidationExpression="^[a-zA-Z0-9ñÑ]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group">
                <label for="tb_DocenteContrasenia" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminEditProContra" runat="server"></asp:Label></label>
                <asp:TextBox type="text" class="form-control" ID="tb_DocenteContrasenia" title="Contraseña" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rv_contrasenia" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="tb_DocenteContrasenia" ValidationGroup="form_ejm2" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_DocenteContrasenia" runat="server" ControlToValidate="tb_DocenteContrasenia" ValidationExpression="^[a-zA-z0-9ñÑ]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm2"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label for="estado" class="control-label" style="color: #FFFFFF">Estado :</label>
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
             <asp:Button ID="btn_DocenteAceptar" runat="server" class="btn btn-success btn-lg" Width="141px" BorderColor="#660033" ValidationGroup="form_ejm" OnClick="btn_DocenteAceptar_Click" />
            <asp:Button ID="btn_DocenteEditar" runat="server" class="btn btn-primary btn-lg" Width="141px" BorderColor="#660033" Visible="False" ValidationGroup="form_ejm2" OnClick="btn_DocenteEditar_Click" />
            <asp:Label ID="L_Error" runat="server" CssClass="label-danger" Font-Bold="True" Font-Size="Large" ForeColor="White"></asp:Label>
            <asp:Button ID="btn_DocenteNuevo" runat="server" class="btn btn-info btn-lg" Width="141px" BorderColor="#660033" Text="Nuevo" Visible="False" OnClick="btn_DocenteNuevo_Click" />
        </div>
    </div>
</asp:Content>
