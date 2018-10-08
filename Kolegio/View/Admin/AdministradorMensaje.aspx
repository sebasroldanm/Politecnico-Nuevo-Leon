<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/MasterAdministrador.master" AutoEventWireup="true" CodeFile="~/Controller/Admin/AdministradorMensaje.aspx.cs" Inherits="View_Administrador_AdministradorMensaje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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


    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
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
                <asp:Label ID="L_AdminMensaTitulo" runat="server"></asp:Label></span></h3>
        </div>
        <label class="control-label" style="color: #FFFFFF"></label>
        <br />
    </div>

    <div class="panel-img" style="margin: -100px 0px 0px 330px;">
        <img src="../../Imagenes/Panel.png" />
    </div>
    <div style="position: absolute; z-index: 1">
        <div class="modal-body" style="margin: -570px 0px 0px 380px;">

            <div class="form-group">

                <div class="form-inline" role="form">
                    <div class="form-group">

                        <label class="control-label" style="color: #FFFFFF"></label>
                    </div>
                    <br />
                    <br />
                </div>
                <div class="form-inline" role="form">
                    <div class="form-group">

                        <label for="TB_Asuto" class="control-label" style="color: #FFFFFF">
                            <asp:Label ID="L_AdminMensAsunto" runat="server"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </label>
                        &nbsp;<asp:TextBox ID="TB_Asuto" runat="server" class="form-control" Width="359px" MaxLength="30" ValidationGroup="mensaje"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RV_Asunto" runat="server" ErrorMessage="" ControlToValidate="TB_Asuto" ForeColor="Red" Font-Size="X-Large" ValidationGroup="mensaje">*</asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="REV_Asuto" runat="server" ControlToValidate="TB_Asuto" ValidationExpression="^[a-zA-Z0-9ñÑ\s,.áéíóú]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="mensaje"></asp:RegularExpressionValidator>
                    </div>
                    <br />
                    <br />
                </div>


                <div class="form-inline" role="form">
                    <div class="form-group">
                        <label for="TB_Destinatario" class="control-label" style="color: #FFFFFF">
                            <asp:Label ID="L_AdminMensDestinatario" runat="server"></asp:Label></label>
                        <asp:TextBox ID="TB_Destinatario" class="form-control" runat="server" Width="359px" MaxLength="50" ValidationGroup="mensaje"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RV_Destinatario" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="TB_Destinatario" ForeColor="Red" Font-Size="X-Large" ValidationGroup="mensaje">*</asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="REV_Destinatario" runat="server" ControlToValidate="TB_Destinatario" ValidationExpression="^[a-zA-Z0-9ñÑ_@.]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="mensaje"></asp:RegularExpressionValidator>
                    </div>
                    <br />
                    <br />
                </div>


                <div class="form-inline" role="form">
                    <div class="form-group">
                        <label for="TB_Mensaje" class="control-label" style="color: #FFFFFF">
                            <asp:Label ID="L_AdminMensMensaje" runat="server"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </label>
                        &nbsp;<asp:TextBox ID="TB_Mensaje" class="form-control" runat="server" Height="100px" Width="378px" TextMode="MultiLine" ValidationGroup="mensaje"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RV_Mensaje" runat="server" ControlToValidate="TB_Mensaje" ForeColor="Red" Font-Size="X-Large" ValidationGroup="mensaje">*</asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="REV_Mensaje" runat="server" ControlToValidate="TB_Mensaje" ValidationExpression="^[a-zA-Z0-9ñÑ\s,.áéíóú]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="mensaje"></asp:RegularExpressionValidator>
                    </div>
                    <br />
                    <br />
                </div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="B_Enviar" runat="server" OnClick="B_Enviar_Click" class="btn btn-success btn-lg" Width="141px" BorderColor="#660033" ValidationGroup="mensaje" />
                <asp:Label ID="L_Verificar" runat="server" ForeColor="White" CssClass="label-danger" Font-Bold="True"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

