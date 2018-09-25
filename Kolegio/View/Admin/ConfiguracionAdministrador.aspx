<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/MasterAdministrador.master" AutoEventWireup="true" CodeFile="~/Controller/Admin/ConfiguracionAdministrador.aspx.cs" Inherits="View_Admin_ConfiguraionAdministrador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            position: relative;
            padding: 15px;
            left: 0px;
            top: 0px;
            width: 527px;
        }
    </style>
</asp:Content>
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


    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                <asp:Label ID="L_AdminConfigTitulo" runat="server"></asp:Label></span></h3>
        </div>
    </div>
    <div class="panel-img" style="margin: -100px 0px 0px 330px;">
        <img src="../../Imagenes/Panel.png" />
    </div>
    <div style="position: absolute; z-index: 1">
        <div class="auto-style1" style="margin: -535px 0px 0px 365px;">
            <div class="form-group">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                              <asp:Image ID="ImagenEst" runat="server" Height="150px" Width="130px" for="TB_Usuaro" />
                <br />
                <br />
                <div class="form-inline" role="form">
                    <label for="tb_usuario" typeof="text" class="control-label" style="color: #FFFFFF">
                        <asp:Label ID="L_AdminConfigUsuario" runat="server"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;</label>
                    &nbsp;<asp:TextBox ID="tb_usuario" runat="server" class="form-control" title="Usuario" Width="126px" MaxLength="20"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RV_user" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="tb_usuario" ValidationGroup="form_ejm" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="REV_usuario" runat="server" ControlToValidate="tb_usuario" ValidationExpression="^[a-zA-Z0-9ñÑ]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm"></asp:RegularExpressionValidator>
                    <label for="tb_contrasenia" typeof="text" class="control-label" style="color: #FFFFFF">
                        <asp:Label ID="L_AdminConfigContra" runat="server"></asp:Label></label>
                    <asp:TextBox ID="tb_contrasenia" Type="text" runat="server" class="form-control" title="Contraseña" Width="180px" MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RV_contrasenia" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="tb_contrasenia" ValidationGroup="form_ejm" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="REV_contrasenia" runat="server" ControlToValidate="tb_contrasenia" ValidationExpression="^[a-zA-Z0-9ñÑ]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm"></asp:RegularExpressionValidator>
                </div>
                <div class="form-inline" role="form">
                    <label for="tb_correo" typeof="text" class="control-label" style="color: #FFFFFF">
                        <asp:Label ID="L_AdminConfigCorreo" runat="server"></asp:Label></label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="tb_correo" Type="email" runat="server" class="form-control" title="Correo" Width="209px" TextMode="Email" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="tb_correo" ValidationGroup="form_ejm" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="REV_correo" runat="server" ControlToValidate="tb_correo" ValidationExpression="^[a-zA-Z0-9ñÑ_@./]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm"></asp:RegularExpressionValidator>
                    <asp:Label ID="lb_foto" for="tb_Foto" class="control-label" runat="server" Text="Foto :" Style="color: #FFFFFF" Font-Bold="True"></asp:Label>
                    <asp:FileUpload ID="tb_Foto" runat="server" accept=".jpg,.png" class="form-control" ErrorMessage="Solo Imagenes" ValidationExpression="(.*).(.jpg|.JPG|.gif|.GIF|.jpeg|.JPEG|.bmp|.BMP|.png|.PNG)$" Width="156px" />
                </div>
                <div class="form-inline" role="form">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btn_Editar" runat="server" class="btn btn-info btn-lg" Width="107px" BorderColor="#660033" OnClick="btn_Editar_Click" />
                </div>
                <br />
                <div class="form-inline">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                          
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <asp:Button ID="btn_Aceptar" runat="server" class="btn btn-success btn-lg" Width="107px" BorderColor="#660033" ValidationGroup="form_ejm" OnClick="btn_Aceptar_Click" Visible="False" />
                    &nbsp;&nbsp;
               <asp:Button ID="btn_cancelar" runat="server" class="btn btn-danger btn-lg" Width="107px" BorderColor="#660033" Visible="False" OnClick="btn_cancelar_Click" />
                    &nbsp;&nbsp;
                </div>
            </div>
        </div>
    </div>

</asp:Content>

