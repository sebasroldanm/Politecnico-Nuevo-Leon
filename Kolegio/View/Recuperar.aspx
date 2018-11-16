﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/Recuperar.aspx.cs" Inherits="View_Recuperar" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
       <link href="../Content/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.0.0.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/popper.min.js"></script>
    <link href="../Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Bootstrap/css/Style.css" rel="stylesheet" />
     <link href="../../Bootstrap/Mio/fondoprofesor.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            margin-bottom: 1rem;
        }
        .auto-style2 {
            text-align: center;
        }
    </style>
</head>

<body>
    <img id="fondo" src="../../Imagenes/fondoadministrador.jpg" alt="background image" /><form id="Login" runat="server">
        <div class="panel-img">
            <img src="../Imagenes/Panel.png" />
        </div>
        <div style="position: absolute; z-index: 1;" id="layer1">
            <div class="modal-body" style="margin: -30px 0px 0px 503px;">
                <div class="row">
                    <div class="auto-style2">
                        <h2><asp:Label ID="L_RecuperarTitulo" runat="server"></asp:Label></h2>
                        <div class="auto-style1">
                            <label for="idusuario" class="control-label"><asp:Label ID="L_RecuperarUsuario" runat="server"></asp:Label></label>
                            <asp:TextBox ID="TB_Usuario" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFV_Usuario" runat="server" ControlToValidate="TB_Usuario"  CssClass="label-danger" ForeColor="White" Font-Bold="True" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                            <asp:RegularExpressionValidator ID="REV_Usuario" runat="server" ControlToValidate="TB_Usuario" ValidationExpression="^[a-zA-z0-9ñÑ]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White"></asp:RegularExpressionValidator>
                            <span class="help-block"></span>
                        </div>
                        <asp:Button ID="B_Enviar" runat="server" CssClass="btn btn-success btn-block" OnClick="B_Enviar_Click" />
                        <asp:Button ID="B_Salir" runat="server" CssClass="btn btn-danger btn-block" OnClick="B_Salir_Click" ValidationGroup="Salir" />
                        <asp:Label ID="L_Verificar" runat="server" CssClass="label-danger" Font-Bold="true" ForeColor="White"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
