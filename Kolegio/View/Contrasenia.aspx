﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/Contrasenia.aspx.cs" Inherits="View_Contrasenia" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Nueva Contraeña</title>
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
        }
    </style>
</head>
<body>
    <img id="fondo" src="../../Imagenes/fondoadministrador.jpg" alt="background image" />
    <form id="Login" runat="server">
        <div class="panel-img">
            <img src="../Imagenes/Panel.png" />
        </div>
        <div style="position: absolute; z-index: 1;" id="layer1">
            <div class="modal-body" style="margin: -30px 0px 0px 503px;">
                <div class="row">
                    <div class="auto-style1">
                        <h2><asp:Label ID="L_ContraseniaTitulo" runat="server"></asp:Label></h2>
                        <div class="form-group">
                            <label for="idusuario" class="control-label" id="L_DigiteClave"><asp:Label ID="L_ContraseniaNueva" runat="server"></asp:Label></label>
                            <asp:TextBox ID="TB_NuevaClave" runat="server" CssClass="form-control" TextMode="Password" MaxLength="20" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFV_Clave" runat="server" ControlToValidate="TB_NuevaClave"  CssClass="label-danger" ForeColor="White" Font-Bold="True" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                            <asp:RegularExpressionValidator ID="REV_Clave" runat="server" ControlToValidate="TB_NuevaClave"  ValidationExpression="^[a-zA-z0-9ñÑ]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White"></asp:RegularExpressionValidator>
                            <span class="help-block"></span>
                        </div>
                        <div class="form-group">
                            <label for="idusuario" class="control-label" id="L_DigiteClaveN"><asp:Label ID="L_ContraseniaNuevamente" runat="server"></asp:Label></label>
                            <asp:TextBox ID="TB_NuevamenteClave" runat="server" CssClass="form-control" TextMode="Password" MaxLength="20" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFV_NuevamenteClave" runat="server" ControlToValidate="TB_NuevamenteClave"  CssClass="label-danger" ForeColor="White" Font-Bold="True" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                            <asp:RegularExpressionValidator ID="REV_NuevamenteClave" runat="server" ControlToValidate="TB_NuevamenteClave"  ValidationExpression="^[a-zA-z0-9ñÑ]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White"></asp:RegularExpressionValidator>
                            <span class="help-block"></span>
                        </div>
                        <asp:Button ID="B_Enviar" runat="server"  CssClass="btn btn-success btn-block" OnClick="B_Enviar_Click" />
                        <asp:CompareValidator ID="CV_Contrasenia" runat="server" ControlToCompare="TB_NuevaCLave" ControlToValidate="TB_NuevamenteClave" ErrorMessage="No Coninciden las Contraseñas" CssClass="alert-link" ForeColor="White"></asp:CompareValidator><br />
                        <asp:Label ID="L_Verificar" runat="server" CssClass="alert-link" ForeColor="White"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
