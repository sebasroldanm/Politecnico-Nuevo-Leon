<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/Admin/AccesoDenegado.aspx.cs" Inherits="View_Admin_AccesoRestringido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Refresh" content="6;URL=../Inicio/InicioNosotros.aspx"/> 
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.0.0.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/popper.min.js"></script>
    <link href="../Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Bootstrap/css/Style.css" rel="stylesheet" />
    <link href="../../Bootstrap/Mio/fondoprofesor.css" rel="stylesheet" />
</head>
<body>

    <img id="fondo" src="../../Imagenes/accesodenegado.jpg" alt="background image" />


    <form id="Login" runat="server">

        <div style="position: absolute; z-index: 1;" id="layer1">
            <div class="modal-body" style="margin: -30px 0px 0px 503px;">
                <div class="row">
                    <div class="col-xs-12">

                        <h1><asp:Label ID="L_AdminAccesoTitulo" runat="server"></asp:Label></h1>

                        <div class="form-group">
                            <h2><asp:Label ID="L_AdminAccesoCuerpo" runat="server"></asp:Label>
                            </h2>
                        </div>
                        <div class="form-group">
                            <h3><asp:Label ID="L_AdminAccesoDescrip" runat="server"></asp:Label><br />
                                <br />
                                <asp:Label ID="L_AdminAccesoFirma" runat="server"></asp:Label>
                            </h3>
                        </div>
                    </div>
                </div>
            </div>
        </div>




    </form>
</body>
</html>

