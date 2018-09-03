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

public partial class View_Admin_ReporteAdministradores : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        if (Session["userId"] != null)
        {
            try
            {
                InfReporte reporte = ObtenerInforme();
                CRS_reporteAdmin.ReportDocument.SetDataSource(reporte);
                CRV_reporteAdmin.ReportSource = CRS_reporteAdmin;
            }
            catch (Exception)
            {

                throw;
            }
        }
        else
            Response.Redirect("AccesoDenegado.aspx");


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

//public partial class View_Admin_ReporteAdministradores : System.Web.UI.Page
//{
//    protected void Page_Load(object sender, EventArgs e)
//    {
//        Response.Cache.SetNoStore();
//        if (Session["userId"] != null)
//        {
//            try
//            {
//                InfReporte reporte = ObtenerInforme();
//                CRS_reporteAdmin.ReportDocument.SetDataSource(reporte);
//                CRV_reporteAdmin.ReportSource = CRS_reporteAdmin;
//            }
//            catch (Exception)
//            {

//                throw;
//            }
//        }
//        else
//            Response.Redirect("AccesoDenegado.aspx");


//    }



//    protected InfReporte ObtenerInforme()
//    {


//        DataTable informacion = new DataTable();
//        InfReporte datos = new InfReporte();

//        informacion = datos.Tables["Administrador"]; // nombre de la tabla que cree en crystal en el InfReporte.xsd


//        //DaoUser administrador = new DaoUser();

//        //DataTable Intermedio = administrador.obtenerAdministradores();
//        LUser logica = new LUser();
//        UUser usua = new UUser();

//         logica.reporteDescargarAdmin(informacion);

//        //for (int i = 0; i < Intermedio.Rows.Count; i++)
//        //{

//        //fila = informacion.NewRow();
//        //    ///El primero [""]  es como se llama el campo de la tabla de crystal y el segundo [""] el campo de la tabla en postgres
//        //    fila["Apellido"] = usua.Apellido;
//        //    fila["Nombre"] = usua.Nombre;
//        //    fila["Documento"] = int.Parse(usua.Documento);
//        //    fila["Telefono"] = usua.Telefono;
//        //    fila["Correo"] = usua.Correo;
//        //    fila["Foto"] = streamFile(usua.Foto);

//        //    informacion.Rows.Add(fila);
//        ////}
//        return datos;
//    }


//    private byte[] streamFile(string filename)
//    {
//        FileStream fs;

//        if (!filename.Equals(""))
//        {
//            fs = new FileStream(Server.MapPath(filename), FileMode.Open, FileAccess.Read);
//        }

//        else
//        {
//            fs = new FileStream(Server.MapPath("~/FotosUser/Useruser.png"), FileMode.Open, FileAccess.Read);

//        }


//        // Create a byte array of file stream length
//        byte[] ImageData = new byte[fs.Length];

//        //Read block of bytes from stream into the byte array
//        fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));

//        //Close the File Stream
//        fs.Close();
//        return ImageData; //return the byte data
//    }



//}