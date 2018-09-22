<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/SubMasterProfesor.master" AutoEventWireup="true" CodeFile="~/Controller/Admin/AgregarProfesor.aspx.cs" Inherits="View_Admin_AgregarProfesor" %>

<%-- Agregue aquí los controles de contenido --%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="text-center">
            <h3><span class="label label-danger">
                <asp:Label ID="L_AdminAgreProTitulo" runat="server"></asp:Label></span></h3>
            <br />
        </div>
    </div>
    <div class="modal-body" style="margin: 0% 0% 0% 10%">


        <div class="form-inline" role="form">
            <div class="form-group">
                <label for="tb_DocenteId" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminAgreProDocumento" runat="server"></asp:Label></label>
                <asp:TextBox ID="tb_DocenteId" runat="server" class="form-control" title="Numero de Documento" MaxLength="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_id" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="tb_DocenteId" ValidationGroup="form3" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_DocenteId" runat="server" ControlToValidate="tb_DocenteId" ValidationExpression="^[0-9]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form3"></asp:RegularExpressionValidator>
                <asp:RangeValidator ID="RV_id_profesor" runat="server" ControlToValidate="tb_DocenteId" CssClass="label-warning" ErrorMessage="Sobrepasó el limite" Font-Bold="True" ForeColor="White" MaximumValue="999999999" MinimumValue="1" ValidationGroup="form3"></asp:RangeValidator><br />
            </div>

            <div class="form-group">
                <label for="tb_DocenteNombre" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminAgreProNombre" runat="server"></asp:Label></label>
                <asp:TextBox ID="tb_DocenteNombre" runat="server" class="form-control" title="Nombres Administrador" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_nombre" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="tb_DocenteNombre" ValidationGroup="form_ejm" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_DocenteNombre" runat="server" ControlToValidate="tb_DocenteNombre" ValidationExpression="^[a-zA-Z\sñÑáéíóú]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group">
                <label class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminAgreProApellido" runat="server"></asp:Label></label>
                <asp:TextBox ID="tb_DocenteApellido" runat="server" class="form-control" title="Apellidos Docente" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_Apellido" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="tb_DocenteApellido" ValidationGroup="form_ejm" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_DocenteApellido" runat="server" ControlToValidate="tb_DocenteApellido" ValidationExpression="^[a-zA-Z\sñÑáéíóú]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm"></asp:RegularExpressionValidator>
            </div>
        </div>
        <br />
        <br />
        <div class="form-inline" role="form">
            <label for="lugarnac1" class="control-label" style="color: #FFFFFF">
                <asp:Label ID="L_AdminAgreProDep" runat="server"></asp:Label></label>
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
                    <asp:Label ID="L_AdminAgreProFoto" runat="server"></asp:Label></label>
                <asp:FileUpload ID="tb_Foto" runat="server" accept=".jpg,.png" class="form-control" ErrorMessage="Solo Imagenes" ValidationExpression="(.*).(.jpg|.JPG|.gif|.GIF|.jpeg|.JPEG|.bmp|.BMP|.png|.PNG)$" Width="240px" />

                <label for="fechanac" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminAgreProFechanac" runat="server"></asp:Label></label>
                <asp:TextBox ID="fechanac" runat="server" class="form-control" title="Fecha de Nacimiento"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RV_fechaNac" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="fechanac" ValidationGroup="form_ejm" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator>

                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

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
                    <asp:Label ID="L_AdminAgreProCorreo" runat="server"></asp:Label></label>
                <asp:TextBox type="email" runat="server" class="form-control" ID="tb_DocenteCorreo" title="Email" MaxLength="50" Width="400px" TextMode="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_correo" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="tb_DocenteCorreo" ValidationGroup="form_ejm" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_DocenteCorreo" runat="server" ControlToValidate="tb_DocenteCorreo" ValidationExpression="^[a-zA-Z0-9ñÑ_@./]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label for="tb_DocenteDireccion" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_ADminAgreProDir" runat="server"></asp:Label></label>
                <asp:TextBox type="text" runat="server" class="form-control" ID="tb_DocenteDireccion" title="Direccion" MaxLength="50" Width="400px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_direccion" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="tb_DocenteDireccion" ValidationGroup="form_ejm" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_DocenteDireccion" runat="server" ControlToValidate="tb_DocenteDireccion" ValidationExpression="^[a-zA-Z0-9ñÑ#,./\sáéíóú]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm"></asp:RegularExpressionValidator>
            </div>
        </div>
        <br />
        <br />
        <div class="form-inline" role="form">
            <div class="form-group">
                <label for="tb_DocenteTelefono" class="control-label" style="color: #FFFFFF" id="lb_telefono">
                    <asp:Label ID="L_AdminAgreProTel" runat="server"></asp:Label></label>
                <asp:TextBox type="text" class="form-control" MaxLength="15" ID="tb_DocenteTelefono" title="Telefono" runat="server"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RV_telefono" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="tb_DocenteTelefono" ValidationGroup="form_ejm" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_DocenteTelefono" runat="server" ControlToValidate="tb_DocenteTelefono" ValidationExpression="^[a-zA-Z0-9\s#.ñÑ]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label for="tb_DocenteUsuario" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminAgreProUser" runat="server"></asp:Label></label>
                <asp:TextBox type="text" class="form-control" ID="tb_DocenteUsuario" title="Usuario" MaxLength="20" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_usuario" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="tb_DocenteUsuario" ValidationGroup="form3" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_DocenteUsuario" runat="server" ControlToValidate="tb_DocenteUsuario" ValidationExpression="^[a-zA-Z0-9ñÑ]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form3"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label for="tb_DocenteContrasenia" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminAgreProContra" runat="server"></asp:Label></label>
                <asp:TextBox type="text" class="form-control" ID="tb_DocenteContrasenia" title="Contraseña" runat="server" MaxLength="20"></asp:TextBox>
                <asp:TextBox type="text" class="form-control" ID="tb_Vusuario" runat="server" Visible="False"></asp:TextBox>
                <asp:TextBox type="text" class="form-control" ID="tb_Vdocumento" runat="server" Visible="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_contrasenia" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="tb_DocenteContrasenia" ValidationGroup="form_ejm" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_DocenteContrasenia" runat="server" ControlToValidate="tb_DocenteContrasenia" ValidationExpression="^[a-zA-Z0-9ñÑ]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White"></asp:RegularExpressionValidator>

            </div>
            <div class="form-group">
                <asp:Button ID="btn_validar" runat="server" class="btn btn-success btn-lg" Width="159px" BorderColor="#660033" OnClick="btn_validar_Click" ValidationGroup="form3" />
            </div>
        </div>

        <br />
        <br />

        <div class="form-inline" role="form">

            <div class="form-group">
                <asp:Label ID="L_ErrorUsuario" class="control-label" Style="color: #F81809" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="Large"></asp:Label>
                <asp:Label ID="L_OkUsuario" class="control-label" Style="color: #09F831" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="Large"></asp:Label>
            </div>

        </div>
        <br />
        <br />

        <div class="form-inline container">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:Button ID="btn_DocenteAceptar" runat="server" class="btn btn-success btn-lg" Width="141px" BorderColor="#660033" OnClick="btn_AdministradorAceptar_Click2" ValidationGroup="form_ejm" Visible="False" />
            <asp:Button ID="btn_DocenteNuevo" runat="server" class="btn btn-info btn-lg" Width="141px" BorderColor="#660033" OnClick="btn_AdministradorNuevo_Click" Visible="False" />
        </div>
    </div>
</asp:Content>




