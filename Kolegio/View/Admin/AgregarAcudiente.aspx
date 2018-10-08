<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/SubMasterAcudiente.master" AutoEventWireup="true" CodeFile="~/Controller/Admin/AgregarAcudiente.aspx.cs" Inherits="View_Admin_AgregarAcudiente" %>

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

    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
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

    <div class="container">
        <div class="text-center">
            <h3><span class="label label-danger">
                <asp:Label ID="L_AdminAgreAcuTitulo" runat="server"></asp:Label></span></h3>
            <br />
        </div>
    </div>
    <div class="modal-body" style="margin: 0% 0% 0% 10%">
        <div class="form-inline" role="form">
            <div class="form-group">
                <label for="tb_AcudienteId" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminAgreAcuDocumento" runat="server"></asp:Label></label>
                <asp:TextBox ID="tb_AcudienteId" runat="server" class="form-control" MaxLength="9" title="Numero de Documento"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_id" runat="server" ControlToValidate="tb_AcudienteId" ValidationGroup="form_ejm3" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_AcudienteId" runat="server" ControlToValidate="tb_AcudienteId" ValidationExpression="^[0-9]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm3"></asp:RegularExpressionValidator>
                <asp:RangeValidator ID="RV_id_Acudiente" runat="server" ControlToValidate="tb_AcudienteId" CssClass="label-warning" ErrorMessage="Sobrepasó el limite" Font-Bold="True" ForeColor="White" MaximumValue="199999999" MinimumValue="1" ValidationGroup="form_ejm3"></asp:RangeValidator><br />
            </div>

            <div class="form-group">
                <label for="tb_AcudienteNombre" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminAgreAcuNombre" runat="server"></asp:Label></label>
                <asp:TextBox ID="tb_AcudienteNombre" runat="server" class="form-control" title="Nombres Acudiente" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_nombre" runat="server" ControlToValidate="tb_AcudienteNombre" ValidationGroup="form_ejm" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_AcudienteNombre" runat="server" ControlToValidate="tb_AcudienteNombre" ValidationExpression="^[a-zA-Z\sñÑáéíóú]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm"></asp:RegularExpressionValidator>

            </div>

            <div class="form-group">
                <label class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminAgreAcuApellido" runat="server"></asp:Label></label>
                <asp:TextBox ID="tb_AcudienteApellido" runat="server" MaxLength="30" class="form-control" title="Apellidos Acudiente"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_Apellido" runat="server" ControlToValidate="tb_AcudienteApellido" ValidationGroup="form_ejm" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_AcudienteApellido" runat="server" ControlToValidate="tb_AcudienteApellido" ValidationExpression="^[a-zA-ZñÑ\sáéíóú]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm"></asp:RegularExpressionValidator>
            </div>
        </div>
        <br />
        <div class="form-inline" role="form">

            <label for="lugarnac1" class="control-label" style="color: #FFFFFF">
                <asp:Label ID="L_AdminAgreAcuDep" runat="server"></asp:Label></label>
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
                <label for="tb_Foto" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminAgreAcuFoto" runat="server"></asp:Label></label>
                <asp:FileUpload ID="tb_Foto" runat="server" accept=".jpg,.png" class="form-control" ErrorMessage="Solo Imagenes" ValidationExpression="(.*).(.jpg|.JPG|.gif|.GIF|.jpeg|.JPEG|.bmp|.BMP|.png|.PNG)$" Width="240px" />
                <asp:RequiredFieldValidator ID="RV_foto" runat="server" ControlToValidate="tb_Foto" ValidationGroup="form_ejm" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator>

                <label for="fechanac" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminAgreAcuFechanac" runat="server"></asp:Label></label>
                <asp:TextBox ID="fechanac" runat="server" class="form-control" title="Fecha de Nacimiento"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_fechaNac" runat="server" ControlToValidate="fechanac" ValidationGroup="form_ejm" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator>

                <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>

                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMMM/yyyy" PopupButtonID="btnigm_calendar" PopupPosition="BottomRight" TargetControlID="fechanac" />

            </div>

            <div class="form-group">
                <asp:ImageButton ID="btnigm_calendar" runat="server" ImageUrl="~/Imagenes/calendario 3030.png" />
            </div>
        </div>
        <br />
        <div class="form-inline" role="form">
            <div class="form-group">
                <label for="tb_AcudienteCorreo" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminAgreAcuCorreo" runat="server"></asp:Label></label>
                <asp:TextBox type="email" MaxLength="50" runat="server" class="form-control" ID="tb_AcudienteCorreo" title="Email" Width="400px" TextMode="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_correo" runat="server" ControlToValidate="tb_AcudienteCorreo" ValidationGroup="form_ejm" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_AcudienteCorreo" runat="server" ControlToValidate="tb_AcudienteCorreo" ValidationExpression="^[a-zA-Z0-9ñÑ_@./]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label for="tb_AcudienteDireccion" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_ADminAgreAcuDir" runat="server"></asp:Label></label>
                <asp:TextBox type="text" runat="server" MaxLength="50" class="form-control" ID="tb_AcudienteDireccion" title="Direccion" Width="400px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_direccion" runat="server" ControlToValidate="tb_AcudienteDireccion" ValidationGroup="form_ejm" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_AcudienteDireccion" runat="server" ControlToValidate="tb_AcudienteDireccion" ValidationExpression="^[a-zA-Z0-9ñÑ#,./\sáéíóú]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm"></asp:RegularExpressionValidator>
            </div>
        </div>
        <br />
        <div class="form-inline" role="form">
            <div class="form-group">
                <label for="tb_AcudienteTelefono" class="control-label" style="color: #FFFFFF" id="lb_telefono">
                    <asp:Label ID="L_AdminAgreAcuTel" runat="server"></asp:Label></label>
                <asp:TextBox type="text" class="form-control" ID="tb_AcudienteTelefono" title="Telefono" runat="server" TextMode="Phone"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_telefono" runat="server" ControlToValidate="tb_AcudienteTelefono" ValidationGroup="form_ejm" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_AcudienteTelefono" runat="server" ControlToValidate="tb_AcudienteTelefono" ValidationExpression="^[a-z0-9()-+\s]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label for="tb_AcudienteUsuario" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminAgreAcuUser" runat="server"></asp:Label></label>
                <asp:TextBox type="text" class="form-control" MaxLength="20" ID="tb_AcudienteUsuario" title="Usuario" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_usuario" runat="server" ControlToValidate="tb_AcudienteUsuario" ValidationGroup="form_ejm3" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_AcudienteUsuario" runat="server" ControlToValidate="tb_AcudienteUsuario" ValidationExpression="^[a-zA-Z0-9ñÑ]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm3"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group">
                <label for="tb_AcudienteContrasenia" class="control-label" style="color: #FFFFFF">
                    <asp:Label ID="L_AdminAgreAcuContra" runat="server"></asp:Label></label>
                <asp:TextBox type="text" class="form-control" MaxLength="20" ID="tb_AcudienteContrasenia" title="Contraseña" runat="server"></asp:TextBox>
                <asp:TextBox type="text" class="form-control" ID="tb_Vusuario" runat="server" Visible="False"></asp:TextBox>
                <asp:TextBox type="text" class="form-control" ID="tb_Vdocumento" MaxLength="20" runat="server" Visible="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_contrasenia" runat="server" ControlToValidate="tb_AcudienteContrasenia" ValidationGroup="form_ejm" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator><br />
                <asp:RegularExpressionValidator ID="REV_AcudienteContrasenia" runat="server" ControlToValidate="tb_AcudienteContrasenia" ValidationExpression="^[a-zA-Z0-9ñÑ]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <asp:Button ID="btn_validar" runat="server" class="btn btn-success btn-lg" Width="159px" BorderColor="#660033" OnClick="btn_validar_Click" ValidationGroup="form_ejm3" />
            </div>
            <div class="form-inline" role="form">
                <div class="form-group">
                    <asp:Label ID="L_ErrorUsuario" class="control-label" Style="color: #F81809" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="Large"></asp:Label>
                    <asp:Label ID="L_OkUsuario" class="control-label" Style="color: #09F831" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="Large"></asp:Label>
                </div>
            </div>
        </div>
        <br />
        <div class="form-inline container">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:Button ID="btn_AcudienteAceptar" runat="server" class="btn btn-success btn-lg" Width="141px" BorderColor="#660033" ValidationGroup="form_ejm" OnClick="btn_AcudienteAceptar_Click" Visible="False" />
            <asp:Button ID="btn_AcudienteNuevo" runat="server" class="btn btn-info btn-lg" Width="141px" BorderColor="#660033" OnClick="btn_AcudienteNuevo_Click" Visible="False" />
        </div>
    </div>
</asp:Content>



