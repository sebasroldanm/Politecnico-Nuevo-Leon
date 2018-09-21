<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/MasterAdministrador.master" AutoEventWireup="true" CodeFile="~/Controller/Admin/EditarPaginaInicio.aspx.cs" Inherits="View_Admin_EditarPaginaInicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 50%;
        }
    </style>

    <style type="text/css">
        .modelBackGround {
            background-color:black;
            filter:alpha(opacy=90);
            opacity:0.8;
            z-index:10000;

        }

body

{

     background:#006699;

}

 

.accordionHeader

{

    border: 1px solid #2F4F4F;

    color: white;

    background-color: #2E4d7B;

     font-family: Arial, Sans-Serif;

     font-size: 12px;

     font-weight: bold;

    padding: 5px;

    margin-top: 5px;

    cursor: pointer;

}

 

 .accordionHeader a

{

     color: #FFFFFF;

     background: none;

     text-decoration: none;

}

 

 .accordionHeader a:hover

{

     background: none;

     text-decoration: underline;

}

 

.accordionHeaderSelected

{

    border: 1px solid #2F4F4F;

    color: white;

    background-color: #5078B3;

     font-family: Arial, Sans-Serif;

     font-size: 12px;

     font-weight: bold;

    padding: 5px;

    margin-top: 5px;

    cursor: pointer;

}

 

 .accordionHeaderSelected a

{

     color: #FFFFFF;

     background: none;

     text-decoration: none;

}

 

.accordionHeaderSelected a:hover

{

     background: none;

     text-decoration: underline;

}

 

.accordionContent

{

    background-color: #D3DEEF;

    border: 1px dashed #2F4F4F;

    border-top: none;

    padding: 5px;

    padding-top: 10px;

}

       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

 
    <ajaxToolkit:TabContainer ID="TC_Configuracion" runat="server" CssTheme="Plain" TabStripPlacement="TopRight" ActiveTabIndex="3">
        
        
        <ajaxToolkit:TabPanel ID="TP_configuracion" runat="server" BorderStyle="NotSet" EnableViewState="True">
                      
                        <HeaderTemplate>
              
                                <div class="text-center">
                                    <h4><span class="label label-success">Administrar Sesiones</span></h4>
                                </div>

                        </HeaderTemplate>


                        <ContentTemplate>
                                          </br>
                                          </br>
                                          </br>
                                      <div class="container">
                                            <div class="text-center">
                                            <h3><span class="label label-danger">Administrar Sesiones</span></h3>
                                           </div>
                                             <label class="control-label" style="color: #FFFFFF"></label>
                                            <br />
                                    </div>

                                          </br>
                                          </br>

                            <div class="container" style="margin: 0% 0% 0% 5%" >
                                <div class="form-inline" role="form">
                                    <div class="form-group">
                                        <label for="DDL_rolSession" class="control-label" style="color: #FFFFFF">Rol :</label>
                                        <asp:DropDownList ID="DDL_rolSession" Class="form-control" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="tb_usuario" class="control-label" style="color: #FFFFFF">Usuario :</label>
                                        <asp:TextBox ID="tb_usuario" MaxLength="30" runat="server" class="form-control" title="Usuario" placeholder="Usuario"></asp:TextBox>



                                    </div>
                                  
                                </div>
                    </br>
                    </br>
                                <div class="form-inline" role="form">
                                     <div class="form-group">
                                         <label for="tb_sessiones" class="control-label" style="color: #FFFFFF">Numero de Sessiones :</label>
                                        <asp:TextBox ID="tb_sessiones" MaxLength="40" runat="server" class="form-control" title="Numero de Sesiones" placeholder="Numero de Sesiones"></asp:TextBox>
                                     </div>
                                   
                                 </div>
                    </br>
                    </br>
                                <div class="form-inline container">
                                    <asp:Button ID="btn_editarsesion" runat="server" class="btn btn-info btn-lg" Width="141px" BorderColor="#660033" Text="Cambiar" />

                                    <asp:Button ID="btn_aceptarsesion" runat="server" Text="Aceptar" class="btn btn-success btn-lg" Width="141px" BorderColor="#660033" />
                                </div>

                </div>






                        </ContentTemplate>

        </ajaxToolkit:TabPanel>

        
        
        
        <ajaxToolkit:TabPanel ID="TP_idioma" runat="server">
            <HeaderTemplate>

                <div class="text-center">
                    <h4><span class="label label-success">Idioma</span></h4>
                </div>
                
            </HeaderTemplate>


            <ContentTemplate>
                <br />
                <br />
                <br />
                
                <div class="container">
                   
                    <div class="text-center">
                        <h3><span class="label label-danger">Idioma</span></h3>
                    </div>
           
                    <br />
                    <br />
                     </br>
                    </br>
                </div>






                

               

            </ContentTemplate>
        </ajaxToolkit:TabPanel>

        
       

        
        <ajaxToolkit:TabPanel ID="TP_sesiones" runat="server">
             <HeaderTemplate>
                           <div class="text-center">
                            <h4><span class="label label-success">Configuracion Leon</span></h4>
                        </div>
               
            </HeaderTemplate>
            <ContentTemplate>

                <br>
                </br>
                <br>
             

                  <div class="container">

        <div class="text-center">
            <h3><span class="label label-danger">
                <asp:Label ID="L_AdminPagInicio" runat="server"></asp:Label></span></h3>
        </div>
        <label class="control-label" style="color: #FFFFFF"></label>
        <br />
    </div>

    <%--<div class="panel-img" style="margin: -100px 0px 0px 330px;">
        <img src="../../Imagenes/Panel.png" />
    </div>--%>
    <div class="container">

        <table class="nav-justified">
            <tr>
                <td class="auto-style2">
                    <label for="TB_Asuto" class="control-label" style="color: #FFFFFF">
                        <asp:Label ID="L_AdminPagInicioNosotros" runat="server"></asp:Label></label>
                    <asp:TextBox ID="TB_Nosotros" runat="server" class="form-control" Width="370px" TextMode="MultiLine" Height="100px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFV_Nosotros" runat="server" ControlToValidate="TB_Nosotros" ErrorMessage="Campo Vacio" CssClass="label-danger" ForeColor="White" Font-Bold="True" SetFocusOnError="True" ValidationGroup="mod">*</asp:RequiredFieldValidator><br />
                    <br />
                    <asp:RegularExpressionValidator ID="REV_Nosotros" runat="server" ControlToValidate="TB_Nosotros" ValidationExpression="^[a-zA-z0-9ñÑ,.\s\n()áéíóú]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="mod"></asp:RegularExpressionValidator>
                </td>
                <td>
                    <label for="TB_Mision" class="control-label" style="color: #FFFFFF">
                        <asp:Label ID="L_AdminpajInicioMision" runat="server"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp; </label>
                    &nbsp;<asp:TextBox ID="TB_Mision" class="form-control" runat="server" Width="370px" TextMode="MultiLine" Height="100px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFV_Mision" runat="server" ControlToValidate="TB_Mision" ErrorMessage="Campo Vacio" CssClass="label-danger" ForeColor="White" Font-Bold="True" SetFocusOnError="True" ValidationGroup="mod">*</asp:RequiredFieldValidator><br />
                    <br />
                    <asp:RegularExpressionValidator ID="REV_Mision" runat="server" ControlToValidate="TB_Mision" ValidationExpression="^[a-zA-z0-9ñ,.\s\nÑ()áéíóú]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="mod"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <label for="TB_Vision" class="control-label" style="color: #FFFFFF">
                        <asp:Label ID="L_AdminPagInicioVision" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp; </label>
                    &nbsp;<asp:TextBox ID="TB_Vision" class="form-control" runat="server" Width="370px" TextMode="MultiLine" Height="100px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFV_Vision" runat="server" ControlToValidate="TB_Vision" ErrorMessage="Campo Vacio" CssClass="label-danger" ForeColor="White" Font-Bold="True" SetFocusOnError="True" ValidationGroup="mod">*</asp:RequiredFieldValidator><br />
                    <br />
                    <asp:RegularExpressionValidator ID="REV_Vision" runat="server" ControlToValidate="TB_Vision" ValidationExpression="^[a-zA-z0-9ñÑ,.\s\n()áéíóú]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="modificar"></asp:RegularExpressionValidator></td>
                <td>
                    <asp:Button ID="B_Modificar" runat="server" class="btn btn-success btn-lg" Width="141px" BorderColor="#660033" OnClick="B_Modificar_Click" ValidationGroup="mod" />
                    <asp:Button ID="B_Traer" runat="server" BorderColor="#660033" OnClick="B_Traer_Click" class="btn btn-info btn-lg" CausesValidation="False" />
                    <asp:Label ID="L_Verificar" runat="server" ForeColor="White" CssClass="label-danger" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <label for="fechanac" class="control-label" style="color: #FFFFFF">
                        <asp:Label ID="L_AdminPagInicioFechaFin" runat="server" Visible="False"></asp:Label></label>
                    <asp:TextBox ID="fechanac" runat="server" class="form-control" title="Fecha de Año" placeholder="Dijite Fecha de Fin Año" Visible="False"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFV_FechaFin" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="fechanac" ValidationGroup="form_ejm" ForeColor="White" Font-Size="X-Large" CssClass="label-danger" Font-Bold="True">*</asp:RequiredFieldValidator>

                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMMM/yyyy" PopupButtonID="btnigm_calendar" PopupPosition="BottomRight" TargetControlID="fechanac" />
                </td>
                <td>
                    <asp:Button ID="B_Terminaranio" runat="server" class="btn btn-success btn-lg" Width="141px" BorderColor="#660033" OnClick="B_Terminaranio_Click" ValidationGroup="form_ejm" Visible="False" />
                </td>
            </tr>
        </table>

    </div>
              

            </ContentTemplate>


 </ajaxToolkit:TabPanel>

      

    </ajaxToolkit:TabContainer>


    
</asp:Content>

            

      
              




