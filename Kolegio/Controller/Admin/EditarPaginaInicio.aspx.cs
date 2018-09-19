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


        //ModificarPaginaInicio
        //script_datos_modificados="Datos Modificados";

        //insertarfechafin
        //script_datos_insertado="Insertado con Éxito";

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
            Session.SessionID
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

        usua = logica.insertarfechafin(fechanac.Text);

        this.Page.Response.Write(usua.Notificacion);

        //DaoUser datos = new DaoUser();
        //EUser enc = new EUser();

        //enc.Año = fechanac.Text;
        //datos.editaFinaño(enc);

        //bool ok = true;
        //datos.editaBool(ok);

        //this.Page.Response.Write("<script language='JavaScript'>window.alert('Insertado con Exito');</script>");
    }
}