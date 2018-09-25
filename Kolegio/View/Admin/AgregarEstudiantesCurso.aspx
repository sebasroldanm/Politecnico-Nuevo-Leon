<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/SubMasterCurso.master" AutoEventWireup="true" CodeFile="~/Controller/Admin/AgregarEstudiantesCurso.aspx.cs" Inherits="View_Admin_AgregarEstudiantesCurso" %>

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
                <asp:Label ID="L_AdminEstuCursoTitulo" runat="server"></asp:Label></span></h3>
            <br />
        </div>
    </div>
    <div class="modal-body" style="margin: 0% 0% 0% 10%">

        <label for="ddt_anio" class="control-label" style="color: #FFFFFF">
            <asp:Label ID="L_AdminEstuCursoSubAnio" runat="server"></asp:Label></label>
        <br />
        <asp:DropDownList ID="ddt_anio" Class="form-control" runat="server" DataSourceID="ODS_anio" DataTextField="nombre_anio" DataValueField="id_anio" AutoPostBack="True" Width="132px"></asp:DropDownList>

        <asp:ObjectDataSource ID="ODS_anio" runat="server" SelectMethod="obtenerAnio" TypeName="Datos.DUser"></asp:ObjectDataSource>

        <label for="ddt_curso" class="control-label" style="color: #FFFFFF">
            <asp:Label ID="L_AdminEstuCursoSubCurso" runat="server"></asp:Label></label>
        <br />
        <asp:DropDownList ID="ddt_curso" Class="form-control" runat="server" DataSourceID="ODS_Cur" DataTextField="nombre_curso" DataValueField="id_ancu" AutoPostBack="True" Width="130px"></asp:DropDownList>

        <asp:ObjectDataSource ID="ODS_Cur" runat="server" SelectMethod="obtenerCursoanio" TypeName="Datos.DUser">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddt_anio" Name="anio" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>

        <asp:Label ID="L_ErrorUsuario" class="control-label" Style="color: #F81809" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="Large"></asp:Label>
        <asp:Label ID="L_OkUsuario" class="control-label" Style="color: #09F831" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="Large"></asp:Label>

        <asp:GridView ID="GridView1" CssClass="table table-bordered bs-table" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataSourceID="ODS_notcurso" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Documento">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("num_documento") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("num_documento") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="nombre_usua" HeaderText="Nombre" />
                <asp:BoundField DataField="apellido_usua" HeaderText="Apellido" />
                <asp:CommandField HeaderText="Agregar al Curso" ShowSelectButton="True" />
                <asp:TemplateField HeaderText="Agregar Curso">
                    <ItemTemplate>
                        <asp:CheckBox ID="CBest" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>

        <asp:ObjectDataSource ID="ODS_notcurso" runat="server" SelectMethod="listaestsincurso" TypeName="Datos.DUser"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ODS_estudiante" runat="server"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ODS_estsincur" runat="server"></asp:ObjectDataSource>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:Button ID="btn_Aceptar" runat="server" class="btn btn-success btn-lg" Width="203px" BorderColor="#660033" OnClick="btn_Aceptar_Click" />

    </div>

</asp:Content>