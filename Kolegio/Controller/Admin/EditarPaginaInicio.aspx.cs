using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Admin_EditarPaginaInicio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        Int32 FORMULARIO = 19;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_AdminPagInicio.Text = encId.CompIdioma["L_AdminPagInicio"].ToString();
        L_AdminPagInicioNosotros.Text = encId.CompIdioma["L_AdminPagInicioNosotros"].ToString();
        RFV_Nosotros.ErrorMessage = encId.CompIdioma["RFV_Nosotros"].ToString();
        L_AdminpajInicioMision.Text = encId.CompIdioma["L_AdminpajInicioMision"].ToString();
        REV_Mision.ErrorMessage = encId.CompIdioma["REV_Mision"].ToString();
        L_AdminPagInicioVision.Text = encId.CompIdioma["L_AdminPagInicioVision"].ToString();
        REV_Vision.ErrorMessage = encId.CompIdioma["REV_Vision"].ToString();
        B_Modificar.Text = encId.CompIdioma["B_Modificar"].ToString();
        B_Traer.Text = encId.CompIdioma["B_Traer"].ToString();
        L_AdminPagInicioFechaFin.Text = encId.CompIdioma["L_AdminPagInicioFechaFin"].ToString();
        B_Terminaranio.Text = encId.CompIdioma["B_Terminaranio"].ToString();

        tb_traduccionES.ReadOnly = true;
        tb_traduccionIN.ReadOnly = true;
        tb_traduccion.ReadOnly = true;
        btn_siguiente.Visible = false;

        //------------------------------------DDL_Rol (Nuevo Lenguaje)--------------------------------------------//
        if (!IsPostBack)
        {
            //DDL_rolagregar.Items.Clear();
            //DDL_rolagregar.Items.Insert(0, encId.CompIdioma["ddl_Rol_Seleccion"].ToString());
            //DDL_rolagregar.Items.Insert(1, encId.CompIdioma["ddl_Rol_Inicio"].ToString());
            //DDL_rolagregar.Items.Insert(2, encId.CompIdioma["ddl_Rol_Admin"].ToString());
            //DDL_rolagregar.Items.Insert(3, encId.CompIdioma["ddl_Rol_Profesor"].ToString());
            //DDL_rolagregar.Items.Insert(4, encId.CompIdioma["ddl_Rol_Estudiante"].ToString());
            //DDL_rolagregar.Items.Insert(5, encId.CompIdioma["ddl_Rol_Acudiente"].ToString());

            //------------------------------------DDL_Rol (Editar Lenguaje)--------------------------------------------//
            DDL_rol.Items.Clear();
            DDL_rol.Items.Insert(0, encId.CompIdioma["ddl_Rol_Seleccion"].ToString());
            DDL_rol.Items.Insert(1, encId.CompIdioma["ddl_Rol_Inicio"].ToString());
            DDL_rol.Items.Insert(2, encId.CompIdioma["ddl_Rol_Admin"].ToString());
            DDL_rol.Items.Insert(3, encId.CompIdioma["ddl_Rol_Profesor"].ToString());
            DDL_rol.Items.Insert(4, encId.CompIdioma["ddl_Rol_Estudiante"].ToString());
            DDL_rol.Items.Insert(5, encId.CompIdioma["ddl_Rol_Acudiente"].ToString());
        }
        //-------------------------------------------------------------------------------------------------------//


        //---------------Boton Pasar Año, Desabilitado ----------------//
        L_AdminPagInicioFechaFin.Visible = false;
        fechanac.Visible = false;
        B_Terminaranio.Visible = false;
        //-------------------------------------------------------------//

        //ModificarPaginaInicio
        //script_datos_modificados="Datos Modificados";

        //insertarfechafin
        //script_datos_insertado="Insertado con Éxito";


        //--------------Ajax Form - ADD - EDIT - DELETE Language ---------------//

        L_AjaxTabSesion.Text = encId.CompIdioma["L_AjaxTabSesion"].ToString();
        L_AjaxSubSesion.Text = encId.CompIdioma["L_AjaxSubSesion"].ToString();
        L_AjaxRol.Text = encId.CompIdioma["L_AjaxRol"].ToString();
        L_AjaxUsuario.Text = encId.CompIdioma["L_AjaxUsuario"].ToString();
        L_AjaxNumSesiones.Text = encId.CompIdioma["L_AjaxNumSesiones"].ToString();
        tb_sessiones.Attributes.Add("placeholder", encId.CompIdioma["tb_sessiones"].ToString());
        btn_editarsesion.Text = encId.CompIdioma["btn_editarsesion"].ToString();
        btn_aceptarsesion.Text = encId.CompIdioma["btn_aceptarsesion"].ToString();

        L_AjaxTabIdioma.Text = encId.CompIdioma["L_AjaxTabIdioma"].ToString();
        L_AjaxSubIdioma.Text = encId.CompIdioma["L_AjaxSubIdioma"].ToString();

        L_AjaxAcorIdioma.Text = encId.CompIdioma["L_AjaxAcorIdioma"].ToString();
        L_AjaxAcorDDLRol.Text = encId.CompIdioma["L_AjaxAcorDDLRol"].ToString();
        L_AjaxAcorDDLForm.Text = encId.CompIdioma["L_AjaxAcorDDLForm"].ToString();
        L_AjaxAcroDDLItem.Text = encId.CompIdioma["L_AjaxAcroDDLItem"].ToString();

        TB_itemES.Attributes.Add("placeholder", encId.CompIdioma["TB_itemES"].ToString());
        TB_itemIN.Attributes.Add("placeholder", encId.CompIdioma["TB_itemIN"].ToString());

        btn_editar.Text = encId.CompIdioma["btn_editar"].ToString();
        btn_aceptar.Text = encId.CompIdioma["btn_aceptar"].ToString();

        L_AjaxAcorAgregarIdioma.Text = encId.CompIdioma["L_AjaxAcorAgregarIdioma"].ToString();
        TB_terminoidioma.Attributes.Add("placeholder=", encId.CompIdioma["TB_terminoidioma"].ToString());
        btn_comprobaridiom.Text = encId.CompIdioma["btn_comprobaridiom"].ToString();
        L_AjaxAcorDDLRolAgregar.Text = encId.CompIdioma["L_AjaxAcorDDLRolAgregar"].ToString();
        L_AjaxAcorDDLFormAgregar.Text = encId.CompIdioma["L_AjaxAcorDDLFormAgregar"].ToString();
        L_AjaxAcorDDLItemAgregar.Text = encId.CompIdioma["L_AjaxAcorDDLItemAgregar"].ToString();
        tb_traduccionIN.Attributes.Add("placeholder=", encId.CompIdioma["tb_traduccionIN"].ToString());
        tb_traduccionES.Attributes.Add("placeholder", encId.CompIdioma["tb_traduccionES"].ToString());
        tb_traduccion.Attributes.Add("placeholder", encId.CompIdioma["tb_traduccion"].ToString());
        btn_siguiente.Text = encId.CompIdioma["btn_siguiente"].ToString();

        L_AjaxConfingLeon.Text = encId.CompIdioma["L_AjaxConfingLeon"].ToString();

        tb_usuario.Attributes.Add("placeholder", encId.CompIdioma["tb_usuario"].ToString());

        //--------------Ajax Form - ADD - EDIT - DELETE Language ---------------//

        string form = DDL_formularioagregar.SelectedValue;
        string item = DDL_itemagregar.SelectedValue;
        encId = idioma.listarControlIdioma(form, item);
        tb_traduccionES.Text = encId.ControlEsp;
        tb_traduccionIN.Text = encId.ControlIngles;
        
        string fo = DDL_formulario.SelectedValue;
        string it = DDL_item.SelectedValue;
        string idi = DDL_idioma.SelectedValue;
        encId = idioma.listarControlIdiomaEditar(fo, it, idi);
        TB_itemES.Text = encId.ControlEsp;

        Response.Cache.SetNoStore();
        LLogin Logica = new LLogin();
        UUser usua = new UUser();
        try
        {
            usua = Logica.logAgregarAdmin(Session["userId"].ToString());
            Response.Redirect(usua.Url);
            CalendarExtender1.EndDate = Convert.ToDateTime("31/12/" + usua.RolId);
        }
        catch
        {
            try
            {
                usua.Session = Session["userId"].ToString();
            }
            catch
            {
                Response.Redirect("~/View/Admin/AccesoDenegado.aspx");
            }
        }
    }

    protected void B_Modificar_Click(object sender, EventArgs e)
    {


        LUser logica = new LUser();
        UUser usua = new UUser();

        usua = logica.ModificarPaginaInicio(
            TB_Nosotros.Text,
            TB_Mision.Text,
            TB_Vision.Text,
            Session.SessionID,
            int.Parse(Session["idioma"].ToString())
            );

        this.Page.Response.Write(usua.Notificacion);


        //EUser Edusua = new EUser();
        //DaoUser datos = new DaoUser();

        //Edusua.Inicio = TB_Nosotros.Text;
        //Edusua.Mision = TB_Mision.Text;
        //Edusua.Vision = TB_Vision.Text;
        //Edusua.Session = Session.SessionID;

        //DataTable registros = datos.editarInicio(Edusua);
        //this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Datos Modificados.');window.location=\"EditarPaginaInicio.aspx\"</script>");
    }


    protected void B_Traer_Click(object sender, EventArgs e)
    {

        LUser logica = new LUser();
        UUser usua = new UUser();

        usua = logica.TraerDatosPagina();

        TB_Nosotros.Text = usua.Nosotros;
        TB_Vision.Text = usua.Vision;
        TB_Mision.Text = usua.Mision;


        //EUser usua = new EUser();
        //DaoUser dat = new DaoUser();

        //DataTable registros = dat.incio();

        //if (registros.Rows.Count > 0)
        //{
        //    TB_Nosotros.Text = Convert.ToString(registros.Rows[0]["inicio_cont"].ToString());
        //    TB_Mision.Text = Convert.ToString(registros.Rows[0]["mision_inicio"].ToString());
        //    TB_Vision.Text = Convert.ToString(registros.Rows[0]["vision_inicio"].ToString());

        //}
    }

    protected void B_Terminaranio_Click(object sender, EventArgs e)
    {

        LUser logica = new LUser();
        UUser usua = new UUser();

        usua = logica.insertarfechafin(fechanac.Text, int.Parse(Session["idioma"].ToString()));

        this.Page.Response.Write(usua.Notificacion);

        //DaoUser datos = new DaoUser();
        //EUser enc = new EUser();

        //enc.Año = fechanac.Text;
        //datos.editaFinaño(enc);

        //bool ok = true;
        //datos.editaBool(ok);

        //this.Page.Response.Write("<script language='JavaScript'>window.alert('Insertado con Exito');</script>");
    }
    protected void btn_siguiente_Click(object sender, EventArgs e)
    {
        //Insertar Control
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        string id;
        if (tb_traduccion.Text == "")
        {

        }
        else
        {
            encId = idioma.listarIdiomaVarchar(TB_nomidioma.Text);
            id = encId.IdIdioma;
            encId = idioma.insertarControlIdioma(DDL_item.SelectedValue, tb_traduccion.Text, encId.IdIdioma, DDL_formularioagregar.SelectedValue);
        }


    }

    protected void btn_comprobaridiom_Click(object sender, EventArgs e)
    {
        //Insertar Idioma
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        Session["empezar"] = "true";
        encId = idioma.insertarIdioma(TB_nomidioma.Text, TB_terminoidioma.Text);
        tb_traduccion.ReadOnly = false;
        TB_nomidioma.ReadOnly = true;
        TB_terminoidioma.ReadOnly = true;
        btn_siguiente.Visible = true;

    }
    protected void btn_editar_Click(object sender, EventArgs e)
    {
    } 

    }