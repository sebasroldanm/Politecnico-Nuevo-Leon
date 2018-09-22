<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/MasterAdministrador.master" AutoEventWireup="true" CodeFile="~/Controller/Admin/EditarPaginaInicio.aspx.cs" Inherits="View_Admin_EditarPaginaInicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 50%;
        }
    </style>

    <style type="text/css">
        .modelBackGround {
            background-color: black;
            filter: alpha(opacy=90);
            opacity: 0.8;
            z-index: 10000;
        }

        body {
            background: #006699;
        }

        .accordionHeader {
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

            .accordionHeader a {
                color: #FFFFFF;
                background: none;
                text-decoration: none;
            }

                .accordionHeader a:hover {
                    background: none;
                    text-decoration: underline;
                }

        .accordionHeaderSelected {
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

            .accordionHeaderSelected a {
                color: #FFFFFF;
                background: none;
                text-decoration: none;
            }

                .accordionHeaderSelected a:hover {
                    background: none;
                    text-decoration: underline;
                }

        .accordionContent {
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
                                    <h4><span class="label label-success"><asp:Label ID="L_AjaxTabSesion" runat="server"></asp:Label></span></h4>
                                </div>

                        </HeaderTemplate>

                        <ContentTemplate>
                                          <br>
                                          </br>
                                          <br>
                                          </br>
                                          <br>
                                          </br>
                                      <div class="container">
                                            <div class="text-center">
                                            <h3><span class="label label-danger"><asp:Label ID="L_AjaxSubSesion" runat="server"></asp:Label></span></h3>
                                           </div>
                                             <label class="control-label" style="color: #FFFFFF"></label>
                                            <br />
                                    </div>

                                          <br>

                                          </br>
                                          <br>
                                          </br>

                            <div class="container" style="margin: 0% 0% 0% 5%" >
                                <div class="form-inline" role="form">
                                    <div class="form-group">
                                        <label for="DDL_rolSession" class="control-label" style="color: #FFFFFF"><asp:Label ID="L_AjaxRol" runat="server"></asp:Label></label>
                                        <asp:DropDownList ID="DDL_rolSession" Class="form-control" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="tb_usuario" class="control-label" style="color: #FFFFFF"><asp:Label ID="L_AjaxUsuario" runat="server"></asp:Label></label>
                                        <asp:TextBox ID="tb_usuario" MaxLength="30" runat="server" class="form-control" title="Usuario" ></asp:TextBox>

                                    </div>
                                  
                                </div>
                                <br>
                    </br>
                                <br>
                    </br>
                                <div class="form-inline" role="form">
                                    <div class="form-group">
                                        <label for="tb_sessiones" class="control-label" style="color: #FFFFFF">
                                            <asp:Label ID="L_AjaxNumSesiones" runat="server"></asp:Label></label>

                                        <asp:TextBox ID="tb_sessiones" runat="server" class="form-control" title="Numero de Sesiones"></asp:TextBox>
                                        <ajaxToolkit:MaskedEditExtender ID="TextBox3_MaskedEditExtender" runat="server" BehaviorID="TextBox3_MaskedEditExtender" Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="9" MaskType="Number" TargetControlID="tb_sessiones" AutoComplete="False" InputDirection="RightToLeft" />

                                    </div>

                                </div>
                                <br>
                    </br>
                                <br>
                    </br>
                                <div class="form-inline container">
                                    <asp:Button ID="btn_editarsesion" runat="server" class="btn btn-info btn-lg" Width="141px" BorderColor="#660033"  />

                                    <asp:Button ID="btn_aceptarsesion" runat="server"  class="btn btn-success btn-lg" Width="141px" BorderColor="#660033" />
                                </div>

                </div>

                        </ContentTemplate>

        </ajaxToolkit:TabPanel>


        <ajaxToolkit:TabPanel ID="TP_idioma" runat="server">
            <HeaderTemplate>

                <div class="text-center">
                    <h4><span class="label label-success"><asp:Label ID="L_AjaxTabIdioma" runat="server"></asp:Label></span></h4>
                </div>
                
            </HeaderTemplate>


            <ContentTemplate>
                <br />
                <br />
                <br />
                
                <div class="container">
                   
                    <div class="text-center">
                        <h3><span class="label label-danger"><asp:Label ID="L_AjaxSubIdioma" runat="server"></asp:Label></span></h3>
                    </div>
           
                    <br />
                    <br />
                     <br>
                     </br>
                    <br>
                    </br>
                </div>

                <ajaxToolkit:Accordion ID="Accordion1" runat="server" ContentCssClass="accordionContent"

     HeaderCssClass="accordionHeader" FadeTransitions="true" TransitionDuration="250"

      FramesPerSecond="40" RequireOpenedPane="false" HeaderSelectedCssClass="accordionHeaderSelected"  AutoSize="None">
                    <Panes>
                        <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
                            <Header>
                                <asp:Label ID="L_AjaxAcorIdioma" runat="server"></asp:Label>
                            </Header>
                            <Content>
                                    <br>
                                    </br>
                   
                                 <div class="container" style="margin: 0% 0% 0% 5%" >
                                <div class="form-inline" role="form">
                                    <div class="form-group">
                                        <label for="DDL_rol" class="control-label" style="color: #333399"><asp:Label ID="L_AjaxAcorDDLRol" runat="server"></asp:Label></label>
                                        <asp:DropDownList ID="DDL_rol" Class="form-control" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="DDL_formulario" class="control-label" style="color: #333399"><asp:Label ID="L_AjaxAcorDDLForm" runat="server"></asp:Label></label>
                                        <asp:DropDownList ID="DDL_formulario" Class="form-control" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="DDL_item" class="control-label" style="color: #333399"><asp:Label ID="L_AjaxAcroDDLItem" runat="server"></asp:Label></label>
                                        <asp:DropDownList ID="DDL_item" Class="form-control" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                     <div class="form-group">
                                        <label for="DDL_idioma" class="control-label" style="color: #333399"><asp:Label ID="Label1" runat="server">Idioma :</asp:Label></label>
                                        <asp:DropDownList ID="DDL_idioma" Class="form-control" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                     <br>
                    </br>
                                     <br>
                    </br>
                                <div class="form-inline" role="form">
                                     <div class="form-group">
                                         <asp:TextBox ID="TB_itemES" MaxLength="30" runat="server" class="form-control" title="Español" ></asp:TextBox>
                                     </div>
                                     <div class="form-group">
                                         <asp:TextBox ID="TB_itemIN" MaxLength="30" runat="server" class="form-control" title="English" Visible="False"></asp:TextBox>
                                     </div>
                                 </div>
                                     <br>
                    </br>
                                     <br>
                    </br>
                                <div class="form-inline container">
                                    <asp:Button ID="btn_editar" runat="server" class="btn btn-info btn-lg" Width="141px" BorderColor="#660033"  />

                                    <asp:Button ID="btn_aceptar" runat="server"  class="btn btn-success btn-lg" Width="141px" BorderColor="#660033" />
                                
                                </div>
                                     <br>
                </br>
                </div>

                            </Content>
                        </ajaxToolkit:AccordionPane>

                        <ajaxToolkit:AccordionPane  ID="AccordionPane2" runat="server">

                            <Header>
                               <asp:Label ID="L_AjaxAcorAgregarIdioma" runat="server"></asp:Label>
                            </Header>
                            <Content>
                                
                                    <br>
                                
                                    </br>
                    
                                <div class="container" style="margin: 0% 0% 0% 5%" >
                                    

                                <div class="form-inline" role="form">
                                    <div class="form-group">
                                         <asp:TextBox ID="TB_terminoidioma" MaxLength="30" runat="server" class="form-control" title="Terminacion en Visual" placeholder="Terminacion en Visual" ></asp:TextBox>
                                     </div>

                                    <div class="form-group">
                                         <asp:TextBox ID="TB_nomidioma" MaxLength="30" runat="server" class="form-control" title="Nombre Idioma" placeholder="Nombre Idioma" ></asp:TextBox>
                                     </div>
                                    <div class="form-group">
                                         <asp:Button ID="btn_comprobaridiom" runat="server" class="btn btn-primary btn-lg" Width="141px" BorderColor="#660033"  />
                                    </div>

                                    <div class="form-group">
                                        <label for="DDL_rolagregar" class="control-label" style="color: #333399"><asp:Label ID="L_AjaxAcorDDLRolAgregar" runat="server"></asp:Label></label>
                                        <asp:DropDownList ID="DDL_rolagregar" Class="form-control" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="DDL_formularioagregar" class="control-label" style="color: #333399"><asp:Label ID="L_AjaxAcorDDLFormAgregar" runat="server"></asp:Label></label>
                                        <asp:DropDownList ID="DDL_formularioagregar" Class="form-control" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="DDL_itemagregar" class="control-label" style="color: #333399"><asp:Label ID="L_AjaxAcorDDLItemAgregar" runat="server"></asp:Label></label>
                                        <asp:DropDownList ID="DDL_itemagregar" Class="form-control" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                    <br>
                                    </br>
                                    <div class="form-inline" role="form">
                                          <asp:TextBox ID="tb_traduccionIN" MaxLength="30" runat="server" class="form-control" title="Traduccion" ></asp:TextBox>

                                           <asp:TextBox ID="tb_traduccionES" MaxLength="30" runat="server" class="form-control" title="Traduccion" ></asp:TextBox>

                                         <asp:TextBox ID="tb_traduccion" MaxLength="30" runat="server" class="form-control" title="Traduccion" ></asp:TextBox>

                                        </div>
                                    <br>
                    </br>
                   
                                <div class="form-inline container">
                                    <asp:Button ID="btn_siguiente" runat="server" class="btn btn-info btn-lg" Width="141px" BorderColor="#660033" OnClick ="btn_siguiente_Click" />

                                </div>
                                    <br>
 </br>
                </div>
                            </Content>
                        </ajaxToolkit:AccordionPane>
                    </Panes>

            </ajaxToolkit:Accordion>

               

            </ContentTemplate>
        </ajaxToolkit:TabPanel>

        
        
        <ajaxToolkit:TabPanel ID="TP_sesiones" runat="server">
             <HeaderTemplate>
                           <div class="text-center">
                            <h4><span class="label label-success"><asp:Label ID="L_AjaxConfingLeon" runat="server"></asp:Label></span></h4>
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
        <img src="../../Imagenes/Panel.png" />                                          HASTA AQUI EL AJAX CON MULTIDIOMA
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

            

      
              




