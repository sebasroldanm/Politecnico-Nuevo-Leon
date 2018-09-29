using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Admin_AgregarMateriasCurso : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        GridView1.DataBind();
        horario();
        LLogin logica = new LLogin();
        UUser usua = new UUser();

        try
        {
            usua = logica.logAdminSecillo(Session["userId"].ToString());
            Response.Redirect(usua.Url);
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

        try
        {
            usua.SUserName = Session["empezar"].ToString();
            MPE_Idioma.Show();
        }
        catch
        {

        }


        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        Int32 FORMULARIO = 10;
        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_AdminAgreMateCursoTitulo.Text = encId.CompIdioma["L_AdminAgreMateCursoTitulo"].ToString();
        L_AdminAgreMateCursoSubAgregarMateria.Text = encId.CompIdioma["L_AdminAgreMateCursoSubAgregarMateria"].ToString();
        REV_materia.ErrorMessage = encId.CompIdioma["REV_materia"].ToString();
        tb_materia.Attributes.Add("placeholder", encId.CompIdioma["tb_materia"].ToString());
        btn_agregam.Text = encId.CompIdioma["btn_agregam"].ToString();
        L_Docente.Text = encId.CompIdioma["L_Docente"].ToString();
        L_AdminAgreMateCursoSubAnio.Text = encId.CompIdioma["L_AdminAgreMateCursoSubAnio"].ToString();
        L_AdminAgreMateCursoSubCurso.Text = encId.CompIdioma["L_AdminAgreMateCursoSubCurso"].ToString();
        L_AdminAgreMateCursoSubMateria.Text = encId.CompIdioma["L_AdminAgreMateCursoSubMateria"].ToString();
        L_AdminAgreMateCursoSubDia.Text = encId.CompIdioma["L_AdminAgreMateCursoSubDia"].ToString();
        L_AdminAgreMateCursoSubHora.Text = encId.CompIdioma["L_AdminAgreMateCursoSubHora"].ToString();
        btn_CursoMateriaAceptar.Text = encId.CompIdioma["btn_CursoMateriaAceptar"].ToString();

        //funcion agregaraHorario        
        //L_Error_falta = "Falta seleccionar";
        //L_Error_materia_insertada = "Materia Insertada a Curso con Exito";
        //L_Error_docente_cruce = "El docente presenta un cruce de Horarios";
        //L_Error_curce = "Presenta un cruce de Horarios";

        //funcion agregarMateria
        //L_Error_falta_materia = "Materia Insertada con Exito";
        //L_Error_materia_ya_esta = "La Materia ya se encuentra en nuestra Base de Datos";


        //pasarAñoClick
        //script_pasar_anio = "Se ha migraido de año con Exito";



        //HORARIO
        //ho_lunes = "Lunes";
        //ho_martes = "Martes";
        //ho_miercoles = "Miercoles";
        //ho_jueves = "Jueves";
        //ho_viernes = "Viernes";
        //ho_libre = "Libre";
        if (IsPostBack == false)
        {
            ddt_Dia.Items.Clear();
            ddt_Dia.Items.Add(encId.CompIdioma["ho_lunes"].ToString());
            ddt_Dia.Items.Add(encId.CompIdioma["ho_martes"].ToString());
            ddt_Dia.Items.Add(encId.CompIdioma["ho_miercoles"].ToString());
            ddt_Dia.Items.Add(encId.CompIdioma["ho_jueves"].ToString());
            ddt_Dia.Items.Add(encId.CompIdioma["ho_viernes"].ToString());
        }
    }

    protected void descartar_idioma_Click(object sender, EventArgs e)
    {
        LIdioma logica = new LIdioma();
        UIdioma enc = new UIdioma();

        int idioma = Convert.ToInt32(Session["nombreIdioma"]);

        enc = logica.eliminarIdiomaCompleto(idioma);

        Session["empezar"] = null;

    }

    protected void volver_idioma_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditarPaginaInicio.aspx");
    }

    protected void btn_CursoMateriaAceptar_Click(object sender, EventArgs e)
    {

        UUser enc = new UUser();
        LReg logic = new LReg();

        enc = logic.agregaraHorario(ddt_curso.SelectedValue, ddt_anio.SelectedValue, ddt_Dia.SelectedValue, ddt_Docente.SelectedValue, ddt_Hora.SelectedValue, ddt_Materia.SelectedValue, int.Parse(Session["idioma"].ToString()));
        L_Error.Text = enc.Mensaje;
        horario();
        //this.Page.Response.Write("<script language='JavaScript'>window.alert('Materia Insertada a Curso con Exito');</script>");

    }

    protected void ddt_Hora_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public void horario()
    {
        UUser util = new UUser();
        LReg logic = new LReg();

        int curso = int.Parse(ddt_curso.SelectedValue);

        DataTable registro = logic.horario(curso, 1, int.Parse(Session["idioma"].ToString()));
        GridView1.DataSource = registro;
        GridView1.DataBind();

    }

    protected void btn_agregam_Click(object sender, EventArgs e)
    {
        LReg l_reg = new LReg();
        UUser user = new UUser();
        user = l_reg.agregarMateria(tb_materia.Text, Session.SessionID, int.Parse(Session["idioma"].ToString()));

        L_Error.Text = user.Mensaje;
        GridView1.DataBind();
        ddt_Materia.DataBind();
    }

    protected void btn_pasaranio_Click(object sender, EventArgs e)
    {
        UUser enc = new UUser();
        LReg logic = new LReg();

        enc = logic.pasarAñoClick(int.Parse(Session["idioma"].ToString()));
        this.Page.Response.Write(enc.Notificacion);

    }


}
