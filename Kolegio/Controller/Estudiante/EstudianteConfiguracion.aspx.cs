using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Logica;
using Utilitarios;

public partial class View_Estudiante_EstudianteConfiguracion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Configuración";
        L_EstuTituloConfig.Text = "Configuración";
        L_EstuConfigUsuario.Text = "Usuario :";
        tb_usuario.Attributes.Add("placeholder", "Usuario");
        REV_usuario.ErrorMessage = "No se aceptan caracteres especiales";
        L_EstuConfigContra.Text = "Contraseña :";
        tb_contrasenia.Attributes.Add(" placeholder", "Contraseña");
        REV_contrasenia.ErrorMessage = "No se aceptan caracteres especiales";
        L_EstuConfigCorreo.Text = "Correo :";
        tb_correo.Attributes.Add("placeholder", "Correo");
        REV_correo.ErrorMessage = "No se aceptan caracteres especiales";
        lb_foto.Text = "Foto :";
        btn_Editar.Text = "Editar";
        btn_Aceptar.Text = "Aceptar";
        btn_cancelar.Text = "Cancelar";

        //script_modificado="Datos Modificados con Exito";

        Response.Cache.SetNoStore();
        LLogin logica = new LLogin();
        UUser usua = new UUser();
        try
        {
            usua = logica.logAgregaEstudiante(Session["userId"].ToString());
            
            ImagenEst.ImageUrl = Session["foto"].ToString();
            tb_correo.ReadOnly = usua.BotonTrue;
            tb_contrasenia.ReadOnly = usua.BotonTrue;
            tb_usuario.ReadOnly = usua.BotonTrue;
            tb_Foto.Visible = usua.BotonFalse;
            lb_foto.Visible = usua.BotonFalse;
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
                Response.Redirect("~/View/Estudiante/AccesoDenegado.aspx");
            }
        }
        
    }

    protected void btn_Editar_Click(object sender, EventArgs e)
    {
        tb_usuario.Text = Session["userName"].ToString();
        tb_contrasenia.Text = Session["clave"].ToString();
        tb_correo.Text = Session["correo"].ToString();
        ImagenEst.ImageUrl = Session["foto"].ToString();
        btn_Editar.Visible = false;
        btn_cancelar.Visible = true;
        btn_Aceptar.Visible = true;
        tb_correo.ReadOnly = false;
        tb_contrasenia.ReadOnly = false;
        tb_Foto.Visible = true;
        lb_foto.Visible = true;

    }

    protected void btn_Aceptar_Click(object sender, EventArgs e)
    {
        UUser enc = new UUser();
        LUser logic = new LUser();
        string fo = cargarImagen();
        String foto = System.IO.Path.GetFileName(tb_Foto.PostedFile.FileName);
        enc = logic.ModifConfiguracion(
                           fo,
                           tb_usuario.Text,
                           tb_contrasenia.Text,
                           tb_correo.Text,
                           Session.SessionID,
                           Session["userId"].ToString(),
                           Session["foto"].ToString(),
                           Session["userName"].ToString(),
                           Session["clave"].ToString(),
                           Session["correo"].ToString()
            );


        Session["userName"] = enc.UserName;
        Session["clave"] = enc.Clave;
        Session["correo"] = enc.Correo;
        Session["foto"] = enc.Foto;

        this.Page.Response.Write("<script language='JavaScript'>window.alert('Datos Modificados con Exito');</script>");

        ImagenEst.ImageUrl = Session["foto"].ToString();
        tb_usuario.Text = Session["username"].ToString();
        tb_contrasenia.Text = Session["clave"].ToString();
        tb_correo.Text = Session["correo"].ToString();
        btn_Editar.Visible = true;
        btn_Aceptar.Visible = false;
    }


    protected void btn_cancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/View/Estudiante/EstudianteHorario.aspx");

    }

    protected string cargarImagen()
    {
        LUser logic = new LUser();
        UUser enc = new UUser();
        enc = logic.CargaFotoM(System.IO.Path.GetFileName(tb_Foto.PostedFile.FileName), System.IO.Path.GetExtension(tb_Foto.PostedFile.FileName), tb_Foto.ToString(), Server.MapPath("~/FotosUser"));
        try
        {
            ClientScriptManager cm = this.ClientScript;
            //cm.RegisterClientScriptBlock(this.GetType(), "", enc.Notificacion);

            tb_Foto.PostedFile.SaveAs(enc.SaveLocation);
            return enc.FotoCargada;
        }
        catch
        {
            return null;
        }
    }

}