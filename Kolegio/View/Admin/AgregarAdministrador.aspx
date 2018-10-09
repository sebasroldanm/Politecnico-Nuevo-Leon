<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/SubMasterAdministrador.master" AutoEventWireup="true" CodeFile="~/Controller/Admin/AgregarAdministrador.aspx.cs" Inherits="View_Admin_AgregarAdministrador" %>

<%-- Agregue aquí los controles de contenido --%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style type="text/css">
        .modelBackground {
            background-color: black;
            filter: alpha(opacity=90);
            opacity: 0.8;
            z-index: 10000;
        }

        .auto-style6 {
            text-align: center;
        }
    </style>


    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
     <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Button ID="btn_hidden" runat="server" Text="" CssClass="btn btn-link" Enabled="False" />
            <ajaxToolkit:ModalPopupExtender ID="MPE_Idioma" runat="server" BehaviorID="MPE_Idioma" DynamicServicePath="" TargetControlID="btn_hidden" BackgroundCssClass="modelBackground" PopupControlID="P_IdiomaPregunta" OnOkScript="btn_salir" OnCancelScript="btn_volver">
            </ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="P_IdiomaPregunta" runat="server" Style="display: none; background: white; width: 50%; height: auto">

                <div>
                    <div class="modal-header">
                        <label for="username" class="label label-danger">
                            <asp:Label ID="L_LoginUsuario" runat="server" Font-Size="Larger" Text="Aviso"></asp:Label>
                        </label>
                    </div>
                    <div class="modal-body">
                        <div class="container-fluid well">
                            <div class="row-fluid">
                                <div class="span4 ">
                                    <div class="control-group">
                                        <br />
                                        <label class="control-label"><strong>¿Esta seguro que desea salir y descartar todos los cambios generados en la opción de Idioma?</strong></label><br />
                                        <div class="controls">
                                        </div>
                                    </div>
                                    <br />

                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="modal-footer">
                        <asp:Button ID="btn_salir" runat="server" Text="Descartar cambios y salir" CssClass="btn btn-danger btn-blockr" OnClick="descartar_idioma_Click" />
                        <asp:Button ID="btn_volver" runat="server" Text="Vovler a la edición de Idioma" CssClass="btn btn-success btn-blockr" OnClick="volver_idioma_Click" /><br />
                    </div>
                </div>

            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <link href="../../Bootstrap/Mio/calendario.css" rel="stylesheet" />

    <div class="container">
        <div class="text-center">
            <h3><span class="label label-danger">
                <asp:Label ID="L_AdminAgreAdminTitulo" runat="server"></asp:Label></span></h3>
            <asp:Label ID="L_fecha" runat="server" Text="Label" Visible="False"></asp:Label>
            <br />
        </div>
    </div>
    <div class="modal-body" style="margin: 0% 0% 0% 10%">
        <div class="form-inline" role="form">
            <div class="form-group">
                <label for="tb_AministradorAdministradorId" typeof="number" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminAgreAdminDocumento" runat="server"></asp:Label></label>
                <asp:TextBox ID="tb_AministradorAdministradorId" runat="server" class="form-control" MaxLength="9" title="Numero de Documento"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_id" runat="server" ControlToValidate="tb_AministradorAdministradorId" ValidationGroup="form_ejm3" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_AministradorAdministradorId" runat="server" ControlToValidate="tb_AministradorAdministradorId" ValidationExpression="^[0-9]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm3"></asp:RegularExpressionValidator>
                <asp:RangeValidator ID="RV_id_Administrador" runat="server" ControlToValidate="tb_AministradorAdministradorId" CssClass="label-warning" ErrorMessage="Sobrepasó el limite" Font-Bold="True" ForeColor="White" MaximumValue="199999999" MinimumValue="1" ValidationGroup="form_ejm3"></asp:RangeValidator><br />
            </div>
            <div class="form-group">
                <label for="tb_AdministradorAdministradorNombre" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminAgreAdminNombre" runat="server"></asp:Label></label>
                <asp:TextBox ID="tb_AdministradorAdministradorNombre" runat="server" class="form-control" title="Nombres Administrador" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_nombre" runat="server" ControlToValidate="tb_AdministradorAdministradorNombre" ValidationGroup="form_ejm" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_AdministradorAdministradorNombre" runat="server" ControlToValidate="tb_AdministradorAdministradorNombre" ValidationExpression="^[a-zA-Zñ\sÑáéíóú]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm"></asp:RegularExpressionValidator>

            </div>

            <div class="form-group">
                <label class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminAgreAdminApellido" runat="server"></asp:Label></label>
                <asp:TextBox ID="tb_AdministradorAdministradorApellido" MaxLength="30" runat="server" class="form-control" title="Apellidos Administrador"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_Apellido" runat="server" ControlToValidate="tb_AdministradorAdministradorApellido" ValidationGroup="form_ejm" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_AdministradorAdministradorApellido" runat="server" ControlToValidate="tb_AdministradorAdministradorApellido" ValidationExpression="^[a-zA-ZñÑ\sáéíóú]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm"></asp:RegularExpressionValidator>
            </div>
        </div>
        <br />
        <br />
        <div class="form-inline" role="form">

            <label for="lugarnac1" class="control-label" style="color: #FFFFFF">
                <asp:Label ID="L_AdminAgreAdminDep" runat="server"></asp:Label></label>
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
                    <asp:Label ID="L_AdminAgreAdminFoto" runat="server"></asp:Label></label>
                <asp:FileUpload ID="tb_AdministradorFoto" runat="server" class="form-control" Width="240px" />
                <asp:RequiredFieldValidator ID="RV_foto" runat="server" ControlToValidate="tb_AdministradorFoto" ValidationGroup="form_ejm" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator>

                <label for="fechanac" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminAgreAdminFechanac" runat="server"></asp:Label></label>
                <asp:TextBox ID="fechanac" runat="server" class="form-control" title="Fecha de Nacimiento"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_fechaNac" runat="server" ControlToValidate="fechanac" ValidationGroup="form_ejm" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator>

                <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>

                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMMM/yyyy" PopupButtonID="btnigm_calendar" PopupPosition="BottomRight" TargetControlID="fechanac" />

            </div>

            <div class="form-group">

                <asp:ImageButton ID="btnigm_calendar" runat="server" ImageUrl="~/Imagenes/calendario 3030.png" OnClick="btnigm_calendar_Click" />

            </div>
        </div>
        <br />
        <br />
        <div class="form-inline" role="form">
            <div class="form-group">
                <label for="tb_AdministradorAdministradorCorreo" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminAgreAdminCorreo" runat="server"></asp:Label></label>
                <asp:TextBox type="email" MaxLength="50" runat="server" class="form-control" ID="tb_AdministradorAdministradorCorreo" title="Email" Width="400px" TextMode="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_correo" runat="server" ControlToValidate="tb_AdministradorAdministradorCorreo" ValidationGroup="form_ejm" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_AdministradorAdministradorCorreo" runat="server" ControlToValidate="tb_AdministradorAdministradorCorreo" ValidationExpression="^[a-zA-Z0-9ñÑ_./@]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label for="tb_AdministradorAdministradorDireccion" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_ADminAgreAdminDir" runat="server"></asp:Label></label>
                <asp:TextBox type="text" runat="server" class="form-control" ID="tb_AdministradorAdministradorDireccion" MaxLength="50" title="Direccion" Width="400px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_direccion" runat="server" ControlToValidate="tb_AdministradorAdministradorDireccion" ValidationGroup="form_ejm" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_AdministradorAdministradorDireccion" runat="server" ControlToValidate="tb_AdministradorAdministradorDireccion" ValidationExpression="^[a-zA-Z0-9ñÑ#,./\sáéíóú]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm"></asp:RegularExpressionValidator>
            </div>
        </div>
        <br />
        <br />
        <div class="form-inline" role="form">

            <div class="form-group">
                <label for="tb_AdministradorTelefono" class="control-label" style="color: #FFFFFF" id="lb_telefono">
                    <asp:Label ID="L_AdminAgreAdminTel" runat="server"></asp:Label></label>
                <asp:TextBox type="text" class="form-control" ID="tb_AdministradorTelefono" title="Telefono" MaxLength="15" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_telefono" runat="server" ControlToValidate="tb_AdministradorTelefono" ValidationGroup="form_ejm" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_AdministradorTelefono" runat="server" ControlToValidate="tb_AdministradorTelefono" ValidationExpression="^[a-z0-9ñ\s]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label for="tb_AdministradorUsuario" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminAgreAdminUser" runat="server"></asp:Label></label>
                <asp:TextBox type="text" class="form-control" ID="tb_AdministradorUsuario" MaxLength="20" title="Usuario" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_usuario" runat="server" ControlToValidate="tb_AdministradorUsuario" ValidationGroup="form_ejm3" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_AdministradorUsuario" runat="server" ControlToValidate="tb_AdministradorUsuario" ValidationExpression="^[a-zA-Z0-9ñÑ]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm3"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group">
                <label for="tb_AdministradorContrasenia" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminAgreAdminContra" runat="server"></asp:Label></label>
                <asp:TextBox type="text" class="form-control" ID="tb_AdministradorContrasenia" title="Contraseña" runat="server" MaxLength="20"></asp:TextBox>
                <asp:TextBox type="text" class="form-control" ID="tb_Vusuario" runat="server" Visible="False"></asp:TextBox>
                <asp:TextBox type="text" class="form-control" ID="tb_Vdocumento" runat="server" Visible="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_contrasenia" runat="server" ControlToValidate="tb_AdministradorContrasenia" ValidationGroup="form_ejm" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_AdministradorContrasenia" runat="server" ControlToValidate="tb_AdministradorContrasenia" ValidationExpression="^[a-zA-Z0-9ñÑ]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm"></asp:RegularExpressionValidator><br />

            </div>
            <div class="form-group">
                <asp:Button ID="btn_validar" runat="server" class="btn btn-success btn-lg" Width="159px" BorderColor="#660033" OnClick="btn_validar_Click" ValidationGroup="form_ejm3" />
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
      <asp:Button ID="btn_AdministradorAceptar" runat="server" class="btn btn-success btn-lg" Width="141px" BorderColor="#660033" OnClick="btn_AdministradorAceptar_Click2" ValidationGroup="form_ejm" Visible="False" />
            <asp:Button ID="btn_AdministradorNuevo" runat="server" class="btn btn-info btn-lg" Width="141px" BorderColor="#660033" OnClick="btn_AdministradorNuevo_Click" Visible="False" />
            <asp:Button ID="B_InsMap" runat="server" class="btn btn-success btn-lg" ValidationGroup="form_ejm" OnClick="B_InsMap_Click" Text="Insertar" Visible="false"/>
        </div>
    </div>
</asp:Content>



