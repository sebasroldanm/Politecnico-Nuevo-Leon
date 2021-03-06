﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;
using Utilitarios.MEncSeguridad;

public partial class View_Admin_EditarPaginaInicio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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

        TB_Nosotros.ReadOnly = true;
        TB_Vision.ReadOnly = true;
        TB_Mision.ReadOnly = true;
        UIdioma encId = new UIdioma();
        LMIdioma idioma = new LMIdioma();
        Int32 FORMULARIO = 19;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));
        

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_AdminPagInicio.Text = encId.CompIdioma["L_AdminPagInicio"].ToString();
        L_AdminPagInicioNosotros.Text = encId.CompIdioma["L_AdminPagInicioNosotros"].ToString();
        REV_Nosotros.ErrorMessage = encId.CompIdioma["RFV_Nosotros"].ToString();
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
        btn_editar.Visible = false;
        //------------------------------------DDL_Rol (Nuevo Lenguaje)--------------------------------------------//


        //if (!IsPostBack)
        //{
            //DDL_rolagregar.Items.Clear();
            //DDL_rolagregar.Items.Insert(0, encId.CompIdioma["ddl_Rol_Seleccion"].ToString());
            //DDL_rolagregar.Items.Insert(1, encId.CompIdioma["ddl_Rol_Inicio"].ToString());
            //DDL_rolagregar.Items.Insert(2, encId.CompIdioma["ddl_Rol_Admin"].ToString());
            //DDL_rolagregar.Items.Insert(3, encId.CompIdioma["ddl_Rol_Profesor"].ToString());
            //DDL_rolagregar.Items.Insert(4, encId.CompIdioma["ddl_Rol_Estudiante"].ToString());
            //DDL_rolagregar.Items.Insert(5, encId.CompIdioma["ddl_Rol_Acudiente"].ToString());

            //------------------------------------DDL_Rol (Editar Lenguaje)--------------------------------------------//
            //DDL_rol.Items.Clear();
            //DDL_rol.Items.Insert(0, encId.CompIdioma["ddl_Rol_Seleccion"].ToString());
            //DDL_rol.Items.Insert(1, encId.CompIdioma["ddl_Rol_Inicio"].ToString());
            //DDL_rol.Items.Insert(2, encId.CompIdioma["ddl_Rol_Admin"].ToString());
            //DDL_rol.Items.Insert(3, encId.CompIdioma["ddl_Rol_Profesor"].ToString());
            //DDL_rol.Items.Insert(4, encId.CompIdioma["ddl_Rol_Estudiante"].ToString());
            //DDL_rol.Items.Insert(5, encId.CompIdioma["ddl_Rol_Acudiente"].ToString());
        //}
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
        TB_terminoidioma.Attributes.Add("placeholder", encId.CompIdioma["TB_terminoidioma"].ToString());
        btn_comprobaridiom.Text = encId.CompIdioma["btn_comprobaridiom"].ToString();
        L_AjaxAcorDDLRolAgregar.Text = encId.CompIdioma["L_AjaxAcorDDLRolAgregar"].ToString();
        L_AjaxAcorDDLFormAgregar.Text = encId.CompIdioma["L_AjaxAcorDDLFormAgregar"].ToString();
        L_AjaxAcorDDLItemAgregar.Text = encId.CompIdioma["L_AjaxAcorDDLItemAgregar"].ToString();

        tb_traduccionIN.Attributes.Add("placeholder", encId.CompIdioma["tb_traduccionIN"].ToString());
        string p = encId.CompIdioma["tb_traduccionIN"].ToString();

        tb_traduccionES.Attributes.Add("placeholder", encId.CompIdioma["tb_traduccionES"].ToString());
        string a = encId.CompIdioma["tb_traduccionES"].ToString();


        tb_traduccion.Attributes.Add("placeholder", encId.CompIdioma["tb_traduccion"].ToString());
        btn_siguiente.Text = encId.CompIdioma["btn_siguiente"].ToString();

        L_AjaxConfingLeon.Text = encId.CompIdioma["L_AjaxConfingLeon"].ToString();

        tb_usuario.Attributes.Add("placeholder", encId.CompIdioma["tb_usuario"].ToString());

        //--------------Ajax Form - ADD - EDIT - DELETE Language ---------------//

        //////
        ///
        try
        {
            encId.NombreIdioma = Session["idiomaInsert"].ToString();
            TB_pruebaCristhian.Text = Session["idiomaInsert"].ToString();
        }
        catch
        {

        }
        //////


        string form = DDL_formularioagregar.SelectedValue;
        string item = DDL_itemagregar.SelectedValue;
        encId = idioma.listarControlIdioma(form, item);
        tb_traduccionES.Text = encId.ControlEsp;
        tb_traduccionIN.Text = encId.ControlIngles;

            //string fo = DDL_formulario.SelectedValue;
            //string it = DDL_item.SelectedValue;
            //string idi = DDL_idioma.SelectedValue;
            //encId = idioma.listarControlIdiomaEditar(fo, it, idi);
            //TB_itemES.Text = encId.ControlEsp;
        
        
    }

    protected void B_Modificar_Click(object sender, EventArgs e)
    {


        LMUser logica = new LMUser();
        UUser usua = new UUser();
        MEncInicio enc = new MEncInicio();

        enc.inicio_cont_nuevo = TB_Nosotros.Text;
        enc.inicio_cont_old = Session["inicio_old"].ToString();
        enc.mision_inicio_nuevo = TB_Mision.Text;
        enc.mision_inicio_old = Session["mision_old"].ToString();
        enc.vision_inicio_nuevo = TB_Vision.Text;
        enc.vision_inicio_old = Session["vision_old"].ToString();
        
        
        

        usua = logica.ModificarPaginaInicio(
            TB_Nosotros.Text,
            TB_Mision.Text,
            TB_Vision.Text,
            Session.SessionID,
            int.Parse(Session["idioma"].ToString()),
            enc
            );

        this.Page.Response.Write(usua.Notificacion);
        B_Modificar.Visible = false;

        //EUser Edusua = new EUser();
        //DaoUser datos = new DaoUser();

        //Edusua.Inicio = TB_Nosotros.Text;
        //Edusua.Mision = TB_Mision.Text;
        //Edusua.Vision = TB_Vision.Text;
        //Edusua.Session = Session.SessionID;

        //DataTable registros = datos.editarInicio(Edusua);
        //this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Datos Modificados.');window.location=\"EditarPaginaInicio.aspx\"</script>");
    }



    protected void descartar_idioma_Click(object sender, EventArgs e)
    {
        LMIdioma logica = new LMIdioma();
        UIdioma enc = new UIdioma();

        int idioma = Convert.ToInt32(Session["nombreIdioma"]);

        enc = logica.eliminarIdiomaCompleto(idioma);

        Session["empezar"] = null;

    }


    protected void B_Traer_Click(object sender, EventArgs e)
    {

        LMUser logica = new LMUser();
        UUser usua = new UUser();

        usua = logica.TraerDatosPagina();

        Session["inicio_old"] = usua.Inicio;
        Session["mision_old"] = usua.Mision;
        Session["vision_old"] = usua.Vision;
        
        TB_Nosotros.Text = usua.Inicio;
        TB_Vision.Text = usua.Vision;
        TB_Mision.Text = usua.Mision;
        TB_Nosotros.ReadOnly = false;
        TB_Vision.ReadOnly = false;
        TB_Mision.ReadOnly = false;

        B_Modificar.Visible = true;
        B_Traer.Visible = false;
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

        //////LUser logica = new LUser();
        //////UUser usua = new UUser();

        //////usua = logica.insertarfechafin(fechanac.Text, int.Parse(Session["idioma"].ToString()));

        //////this.Page.Response.Write(usua.Notificacion);

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
        LMIdioma idioma = new LMIdioma();
        string id;
        
        encId = idioma.listarIdiomaVarchar(TB_nomidioma.Text);        

        idioma.insertarControlIdioma(
            DDL_itemagregar.SelectedValue, 
            tb_traduccion.Text, 
            int.Parse(encId.IdIdioma), 
            int.Parse(DDL_formularioagregar.SelectedValue), 
            TB_nomidioma.Text);

        DDL_rolagregar.DataBind();
        DDL_formularioagregar.DataBind();
        DDL_rolagregar.DataBind();
        tb_traduccion.Text = "";

        try
        {
            encId = idioma.terminarIdioma(1, int.Parse(encId.IdIdioma));
            Session["empezar"] = encId.Empezar;
            string cerrar = Session["empezar"].ToString();
        }
        catch
        {
            this.Page.Response.Write(encId.Notificacion);
        }
    }

    protected void btn_comprobaridiom_Click(object sender, EventArgs e)
    {
        //Insertar Idioma
        UIdioma encId = new UIdioma();
        LMIdioma mIdioma = new LMIdioma();
        LMIdioma idioma = new LMIdioma();
        UUser usua = new UUser();

        try
        {
            encId = mIdioma.insertarIdioma(TB_nomidioma.Text, TB_terminoidioma.Text);
            this.Page.Response.Write(usua.Notificacion);
            Session["empezar"] = encId.IdiomaTermina;
            string prueba = Session["empezar"].ToString();
            this.Page.Response.Write(encId.Notificacion);
            tb_traduccion.ReadOnly = false;
            TB_terminoidioma.ReadOnly = true;
            TB_nomidioma.ReadOnly = true;
            btn_siguiente.Visible = true;
            btn_comprobaridiom.Visible = false;
            Session["idiomaInsert"] = TB_nomidioma.Text;
            TB_pruebaCristhian.Text = Session["idiomaInsert"].ToString();
            encId = idioma.traerIdioma(TB_pruebaCristhian.Text);
            Session["nombreIdioma"] = encId.NombreIdioma;
        }
        catch
        {
            TB_nomidioma.Text = "";
            TB_terminoidioma.Text = "";
            try
            {
                string notificacion = encId.Notificacion;
                this.Page.Response.Write(notificacion);
            }
            catch
            {
                this.Page.Response.Write("<script language='JavaScript'>window.alert('Idioma Completado Con Éxito');</script>");
            }
        }

    }

    protected void btn_editar_Click(object sender, EventArgs e)
    {
        //UIdioma encId = new UIdioma();
        LMIdioma idioma = new LMIdioma();

        idioma.editarIdiomaControl(int.Parse(Session["idIdiomaEditar"].ToString()), TB_itemES.Text);
        btn_aceptar.Visible = true;
        TB_itemES.ReadOnly = true;
    }


    protected void btn_aceptar_Click(object sender, EventArgs e)
    {
        UIdioma encId = new UIdioma();
        LMIdioma idioma = new LMIdioma();

        btn_editar.Visible = true;
        btn_aceptar.Visible = false;

        string fo = DDL_formulario.SelectedValue;
        string it = DDL_item.SelectedValue;
        string idi = DDL_idioma.SelectedValue;
        encId = idioma.listarControlIdiomaEditar(fo, it, idi);
        Session["idIdiomaEditar"] = encId.IdIdioma;
        TB_itemES.Text = encId.ControlEsp;
        TB_itemES.ReadOnly = false;

    }


    protected void btn_aceptarsesion_Click(object sender, EventArgs e)
    {
        UIdioma usesion = new UIdioma();
        LMIdioma sesion = new LMIdioma();
        UUser user = new UUser();
        user = sesion.listarSesion(int.Parse(ddl_usuarioxrol.SelectedValue));
        tb_sessiones.Text = user.Session;
        btn_editarsesion.Visible = true;
        btn_aceptarsesion.Visible = false;
        tb_sessiones.ReadOnly = false;
    }

    protected void btn_editarsesion_Click(object sender, EventArgs e)
    {
        LMIdioma sesion = new LMIdioma();
        sesion.editasesion(int.Parse(ddl_usuarioxrol.SelectedValue), tb_sessiones.Text);
        btn_editarsesion.Visible = false;
        btn_aceptarsesion.Visible = true;
        tb_sessiones.ReadOnly = true;
    }



}