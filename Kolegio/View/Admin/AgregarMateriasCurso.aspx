<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/SubMasterCurso.master" AutoEventWireup="true" CodeFile="~/Controller/Admin/AgregarMateriasCurso.aspx.cs" Inherits="View_Admin_AgregarMateriasCurso" %>

<%-- Agregue aquí los controles de contenido --%>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container">
        <div class="text-center">
            <h3><span class="label label-danger">
                <asp:Label ID="L_AdminAgreMateCursoTitulo" runat="server"></asp:Label></span></h3>
            <br />
        </div>
    </div>

    <div class="modal-body" style="margin: 0% 0% 0% 10%">
        <div class="form-inline" role="form">
            <label class="control-label" style="color: #FFFFFF"></label>
            <br />
            <br />
            <div class="form-inline" role="form">

                <div class="form-group">
                    <label for="tb_materia" class="control-label" style="color: #FFFFFF">
                        <asp:Label ID="L_AdminAgreMateCursoSubAgregarMateria" runat="server"></asp:Label></label>
                    <asp:RegularExpressionValidator ID="REV_materia" runat="server" ControlToValidate="tb_materia" ValidationExpression="^[a-zA-ZñÑ\s.,áéíóú]*$" CssClass="label-warning" Font-Bold="True" ForeColor="White" ValidationGroup="form_ejm4"></asp:RegularExpressionValidator><br />
                    <asp:TextBox ID="tb_materia" runat="server" class="form-control" title="Nombre Materia"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RV_id" runat="server" ErrorMessage="Campo Obligatorio" ControlToValidate="tb_materia" ValidationGroup="form_ejm4" ForeColor="Red" Font-Size="X-Large">*</asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp
                            <asp:Button ID="btn_agregam" runat="server" class="btn btn-success btn-lg" Width="194px" BorderColor="#660033" ValidationGroup="form_ejm4" OnClick="btn_agregam_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp

                            

                </div>
            </div>
            <br />
            <br />
            <label for="ddt_anio" class="control-label" style="color: #FFFFFF">
                <asp:Label ID="L_AdminAgreMateCursoSubAnio" runat="server"></asp:Label></label>
            <asp:DropDownList ID="ddt_anio" Class="form-control" runat="server" DataSourceID="ODS_anio" DataTextField="nombre_anio" DataValueField="id_anio" AutoPostBack="True"></asp:DropDownList>

            <asp:ObjectDataSource ID="ODS_anio" runat="server" SelectMethod="obtenerAnio" TypeName="Datos.DUser"></asp:ObjectDataSource>

            <label for="ddt_curso" class="control-label" style="color: #FFFFFF">
                <asp:Label ID="L_AdminAgreMateCursoSubCurso" runat="server"></asp:Label></label>
            <asp:DropDownList ID="ddt_curso" Class="form-control" runat="server" DataSourceID="ODS_Cur" DataTextField="nombre_curso" DataValueField="id_ancu" AutoPostBack="True">
                <asp:ListItem Value="0">seleccione</asp:ListItem>
            </asp:DropDownList>

            <asp:ObjectDataSource ID="ODS_Cur" runat="server" SelectMethod="obtenerCursoanio" TypeName="Datos.DUser">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddt_anio" Name="anio" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>

            <label for="ddt_Materia" class="control-label" style="color: #FFFFFF">
                <asp:Label ID="L_AdminAgreMateCursoSubMateria" runat="server"></asp:Label></label>
            <asp:DropDownList ID="ddt_Materia" Class="form-control" runat="server" DataSourceID="ODSmateria" DataTextField="nombre_materia" DataValueField="id_materia"></asp:DropDownList>

            <asp:ObjectDataSource ID="ODSmateria" runat="server" SelectMethod="obtenerMateria" TypeName="Datos.DUser"></asp:ObjectDataSource>

            <label for="ddt_Docente" class="control-label" style="color: #FFFFFF">
            <asp:Label ID="L_Docente" class="control-label" runat="server"></asp:Label></label>
            <span style="color: #555555; background-color: #FFFFFF"></span>
            <asp:DropDownList ID="ddt_Docente" Class="form-control" runat="server" DataSourceID="ODSdocente" DataTextField="nombre_usua" DataValueField="id_usua"></asp:DropDownList>
            <asp:ObjectDataSource ID="ODSdocente" runat="server" SelectMethod="listardocenteddl" TypeName="Datos.DUser"></asp:ObjectDataSource>

            <label for="ddt_Dia" class="control-label" style="color: #FFFFFF">
                <asp:Label ID="L_AdminAgreMateCursoSubDia" runat="server"></asp:Label></label>
            <asp:DropDownList ID="ddt_Dia" Class="form-control" runat="server">
                <asp:ListItem Value="0">Seleccione</asp:ListItem>
            </asp:DropDownList>

            <label for="ddt_Hora" class="control-label" style="color: #FFFFFF">
                <asp:Label ID="L_AdminAgreMateCursoSubHora" runat="server"></asp:Label></label>
            <asp:DropDownList ID="ddt_Hora" Class="form-control" runat="server" OnSelectedIndexChanged="ddt_Hora_SelectedIndexChanged">
                <asp:ListItem Value="0">Seleccione</asp:ListItem>
                <asp:ListItem Value="8:00:00">8:00:00 - 9:29:00</asp:ListItem>
                <asp:ListItem Value="10:00:00">10:00:00 - 11:59:00</asp:ListItem>
                <asp:ListItem Value="12:00:00">12:00:00 - 02:00:00</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;
        
               <br />
            <br />

            <asp:Button ID="btn_CursoMateriaAceptar" runat="server" class="btn btn-success btn-lg" Width="227px" BorderColor="#660033" OnClick="btn_CursoMateriaAceptar_Click" />
            &nbsp;&nbsp;&nbsp;
               
            <asp:Label ID="L_Error" runat="server" CssClass="label-danger" Font-Bold="True" Font-Size="Large" ForeColor="White"></asp:Label>

        </div>
        <asp:GridView ID="GridView1" CssClass="table table-bordered bs-table" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
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

    </div>

</asp:Content>