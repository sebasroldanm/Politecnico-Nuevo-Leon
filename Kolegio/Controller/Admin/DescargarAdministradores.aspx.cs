using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Admin_DescargarAdministradores : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        Int32 FORMULARIO = 14;
        Page.Title = "Descargar Administradores";

        Response.Cache.SetNoStore();
        LLogin logica = new LLogin();
        UUser usua = new UUser();
        try
        {
            usua = logica.logAdminSecillo(Session["userId"].ToString());
            try
            {
                InfReporte reporte = ObtenerInforme(); 
                CRS_admin.ReportDocument.SetDataSource(reporte);
                CRV_administradores.ReportSource = CRS_admin;
            }
            catch (Exception)
            {

                throw;
            }
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
        

    }



    protected InfReporte ObtenerInforme()
    {

        DataTable informacion = new DataTable();
        InfReporte datos = new InfReporte();

        informacion = datos.Tables["Administrador"]; // nombre de la tabla que cree en crystal en el InfReporte.xsd


        LUser administrador = new LUser();

        administrador.reporteAdmin(informacion);
        
        return datos;
    }



    protected void CRV_administradores_Init(object sender, EventArgs e)
    {

    }


    private byte[] streamFile(string filename)
    {
        FileStream fs;

        if (!filename.Equals(""))
        {
            fs = new FileStream(Server.MapPath(filename), FileMode.Open, FileAccess.Read);
        }

        else
        {
             fs = new FileStream(Server.MapPath("~/FotosUser/Useruser.png"), FileMode.Open, FileAccess.Read);

        }


        // Create a byte array of file stream length
        byte[] ImageData = new byte[fs.Length];

        //Read block of bytes from stream into the byte array
        fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));

        //Close the File Stream
        fs.Close();
        return ImageData; //return the byte data
    }


}