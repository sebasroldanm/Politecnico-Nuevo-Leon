using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class View_Admin_ConfiguraionAdministrador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        if (Session["userId"] != null)
        {
            ImagenEst.ImageUrl = Session["foto"].ToString();
            tb_correo.ReadOnly = true;
            tb_contrasenia.ReadOnly = true;
            tb_usuario.ReadOnly = true;
            tb_Foto.Visible = false;
            lb_foto.Visible = false;
        }
        else
            Response.Redirect("AccesoDenegado.aspx");
        


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
        EUser enc = new EUser();
        DaoUser datos = new DaoUser();

        String foto = System.IO.Path.GetFileName(tb_Foto.PostedFile.FileName);


        if (tb_Foto.FileName == "")
        {

            enc.Id_estudiante = Session["userId"].ToString();
            enc.UserName = tb_usuario.Text;
            enc.Clave = tb_contrasenia.Text;
            enc.Correo = tb_correo.Text;
            enc.Session = Session.SessionID;
            enc.Foto = Session["foto"].ToString();
            tb_usuario.Text = Session["userName"].ToString();
            tb_contrasenia.Text = Session["clave"].ToString();
            tb_correo.Text = Session["correo"].ToString();
            ImagenEst.ImageUrl = Session["foto"].ToString();
        }
        else
        {      
            foto = "~/FotosUser/" + tb_Foto.FileName;
            enc.Id_estudiante = Session["userId"].ToString();
            enc.UserName = tb_usuario.Text;
            enc.Clave = tb_contrasenia.Text;
            enc.Correo = tb_correo.Text;
            enc.Foto = cargarImagen();
            enc.Session = Session.SessionID;
        }

        DataTable resultado = datos.editarConfig(enc);

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


    protected String cargarImagen()
    {


        string sDia = Convert.ToString(DateTime.Now.Day);
        string sMes = Convert.ToString(DateTime.Now.Month);
        string sAgno = Convert.ToString(DateTime.Now.Year);
        string sHora = Convert.ToString(DateTime.Now.Hour);
        string sMinu = Convert.ToString(DateTime.Now.Minute);
        string sSeco = Convert.ToString(DateTime.Now.Second);
        string sFecha = sDia + sMes + sAgno + sHora + sMinu + sSeco;




        ClientScriptManager cm = this.ClientScript;
        String nombreArchivo = System.IO.Path.GetFileName(tb_Foto.PostedFile.FileName);
        String extension = System.IO.Path.GetExtension(tb_Foto.PostedFile.FileName);
        String saveLocation = "";

        if (!(string.Compare(extension, ".png", true) == 0 || string.Compare(extension, ".jpeg", true) == 0 || string.Compare(extension, ".jpg", true) == 0))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Solo se admiten imagenes en formato Jpeg o Gif');</script>");
          


            return null;
        }

        saveLocation = Server.MapPath("~/FotosUser") + "/" + sFecha + sMinu + nombreArchivo;

        if (System.IO.File.Exists(saveLocation))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Ya existe una imagen en el servidor con ese nombre');</script>");
            return null;
        }

        tb_Foto.PostedFile.SaveAs(saveLocation);
        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('El archivo de imagen ha sido cargado');</script>");

        return "~/FotosUser" + "/" + sFecha + sMinu + nombreArchivo;
    }


    protected void btn_cancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/View/Admin/AgregarAdministrador.aspx");

    }
}