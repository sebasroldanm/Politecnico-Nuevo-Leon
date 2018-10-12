<%@ Page Title="" Language="C#" MasterPageFile="~/View/Inicio/MasterInicio.master" AutoEventWireup="true" CodeFile="~/Controller/Inicio/InicioNosotros.aspx.cs" Inherits="View_Inicio_InicioNosotros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style>
* {box-sizing: border-box;}
body {font-family: Verdana, sans-serif;}
.mySlides {display: none;}
img {vertical-align: middle;}

/* Slideshow container */
.slideshow-container {
  max-width: 800px;
  position: relative;
  margin: auto;
}

/* Caption text */
.text {
  color: #f2f2f2;
  font-size: 15px;
  padding: 8px 12px;
  position: absolute;
  bottom: 8px;
  width: 100%;
  text-align: center;
}

/* Number text (1/3 etc) */
.numbertext {
  color: #f2f2f2;
  font-size: 12px;
  padding: 8px 12px;
  position: absolute;
  top: 0;
}

/* The dots/bullets/indicators */
.dot {
  height: 15px;
  width: 15px;
  margin: 0 2px;
  background-color: #bbb;
  border-radius: 50%;
  display: inline-block;
  transition: background-color 0.6s ease;
}

.active {
  background-color: #717171;
}

/* Fading animation */
.fade {
  -webkit-animation-name:fade;
  -webkit-animation-duration:3s;
  animation-name: fade;
  animation-duration: 3s;
}

@-webkit-keyframes fade {
  from {opacity: 0} 
  to {opacity: 1}
}

@keyframes fade {
  from {opacity: .4} 
  to {opacity: 1}
}

/* On smaller screens, decrease text size */
@media only screen and (max-width: 300px) {
  .text {font-size: 11px}
}
       .auto-style1 {
           text-align: center;
       }
       .auto-style3 {
           width: 100%;
       }
       .auto-style4 {
           width: 33%;
       }
       .auto-style5 {
           width: 33%;
       }
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="auto-style2">

                <asp:DropDownList ID="DDL_Idioma" Class="form-control" runat="server" Height="35px" AutoPostBack="True" DataSourceID="ODS_Idioma" DataTextField="nombre" DataValueField="id_idioma" CssClass="auto-style1" Width="118px" OnSelectedIndexChanged="DDL_Idioma_SelectedIndexChanged">
                    <asp:ListItem Value="1"></asp:ListItem>
                </asp:DropDownList>
                
                <asp:ObjectDataSource ID="ODS_Idioma" runat="server" SelectMethod="obtenerSeleccionIdioma" TypeName="Datos.DMIdioma"></asp:ObjectDataSource>
            
            </div>

    <div class="slideshow-container">
        <div class="mySlides fade">
            <div class="numbertext"></div>
            <asp:Image ID="IMG_Slider1" runat="server" />
        </div>

        <div class="mySlides fade">
            <div class="numbertext"></div>
            <asp:Image ID="IMG_Slider2" runat="server" />
        </div>

        <div class="mySlides fade">
            <div class="numbertext"></div>
            <asp:Image ID="IMG_Slider3" runat="server" />
        </div>
    </div>
    <br>

    <div style="text-align: center">
        <span class="dot"></span>
        <span class="dot"></span>
        <span class="dot"></span>
    </div>

    <script>
        var slideIndex = 0;
        showSlides();

        function showSlides() {
            var i;
            var slides = document.getElementsByClassName("mySlides");
            var dots = document.getElementsByClassName("dot");
            for (i = 0; i < slides.length; i++) {
                slides[i].style.display = "none";
            }
            slideIndex++;
            if (slideIndex > slides.length) { slideIndex = 1 }
            for (i = 0; i < dots.length; i++) {
                dots[i].className = dots[i].className.replace(" active", "");
            }
            slides[slideIndex - 1].style.display = "block";
            dots[slideIndex - 1].className += " active";
            setTimeout(showSlides, 2000); // Change image every 2 seconds
        }
    </script>


    <div class="container">
        <div class="jumbotron">
            <h2 class="auto-style1"><asp:Label ID="L_InNosTitulo" runat="server" ></asp:Label></h2>
            <p class="auto-style1">
                <asp:Label ID="L_InNosDescarga" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:HyperLink ID="HL_Drive" runat="server" Text="Drive" NavigateUrl="https://drive.google.com/open?id=1axnOALu2NQmb8VXYpS5_Hl6j_QhgyNn_" Target="_blank"></asp:HyperLink>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:HyperLink ID="HL_Dropbox" runat="server" Text="DropBox" NavigateUrl="https://www.dropbox.com/s/pahhqvsnu1bonc8/MANUAL%20DEL%20USUARIO.pdf?dl=0" Target="_blank"></asp:HyperLink>
            </p>
            <h2><asp:Label ID="L_InNosSubtitulo" runat="server"></asp:Label></h2>
            <p>
                <asp:Label ID="L_Inicio" runat="server" ></asp:Label>
            </p>
        </div>
    </div>
    
    <div class="container">
        <div class="jumbotron" id="jumbo">
            <div class="auto-style1">
                <div class="card-body">
                    <h4 class="auto-style1"><asp:Label ID="L_InNosBievenido" runat="server"></asp:Label></h4>
                    <p class="card-text">
                        <asp:Label ID="L_InNosInstalaciones" runat="server"></asp:Label>
                    </p>
                    <table class="auto-style3">
                        <tr>
                            <td class="auto-style4">
                                <div class="card" style="width: 300px">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/V1.jpg" Width="250px" />
                                </div>
                            </td>
                            <td class="auto-style5">
                                <div class="card" style="width: 300px">
                                    <div class="card" style="width: 300px">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/V2.jpg" Width="260px" />
                                    </div>
                                </div>
                            </td>
                            <td>
                                <div class="card" style="width: 300px">
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/V3.jpg" Width="260px" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>









