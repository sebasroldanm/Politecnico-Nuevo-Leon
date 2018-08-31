using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Loggin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        Session["userId"] = null;
    }

    protected void BT_Ingresar_Click(object sender, EventArgs e)
    {
        EUser encapsular = new EUser();
        DaoUser datos = new DaoUser();

        encapsular.UserName = TB_UserName.Text.ToString();
        encapsular.Clave = TB_Clave.Text.ToString();
        DataTable resultado = datos.loggin(encapsular);

        if (resultado.Rows.Count > 0)
        {
            Session["userId"] = resultado.Rows[0]["id_usua"].ToString();
            Session["userName"] = resultado.Rows[0]["user_name"].ToString();
            Session["nombre"] = resultado.Rows[0]["nombre_usua"].ToString();
            Session["apellido"] = resultado.Rows[0]["apellido_usua"].ToString();
            Session["clave"] = resultado.Rows[0]["clave"].ToString();
            Session["correo"] = resultado.Rows[0]["correo"].ToString();
            Session["documento"] = resultado.Rows[0]["num_documento"].ToString();
            Session["foto"] = resultado.Rows[0]["foto_usua"].ToString();
            //Response.Redirect("Administrador/AdministradorAdministrador.aspx");

            //EDatos datos2 = new EDatos();
            //DataTable data = new DataTable();
            //data.Columns.Add("nombre");
            //data.Columns.Add("userName");
            if ((resultado.Rows[0]["estado"].ToString()) == "True")
            {
                switch (int.Parse(resultado.Rows[0]["rol_id"].ToString()))
                {
                    case 1:
                        Session["nombre"] = resultado.Rows[0]["nombre_usua"].ToString();
                        Console.WriteLine("Hola");
                        Response.Redirect("Admin/AgregarAdministrador.aspx");
                        //Session["nombre"].ToString();
                        break;

                    case 2:
                        Response.Redirect("Profesor/ProfesorSubirNota.aspx");
                        break;

                    case 3:
                        Response.Redirect("Estudiante/EstudianteHorario.aspx");
                        break;

                    case 4:
                        Response.Redirect("Acudiente/AcudienteBoletin.aspx");
                        break;

                    default:
                        Response.Redirect("Loggin.aspx");
                        break;
                }

            }
            else
            {
                L_Error.Text = "Usuario Se Encuentra Inactivo";
                Session["userId"] = null;
            }
        }
        else
        {
            L_Error.Text = "Usuario Y/o Clave Incorrecto";
            Session["userId"] = null;
        }
    }

    protected void BT_Recuperar_Click(object sender, EventArgs e)
    {
        Session["userId"] = null;
        Response.Redirect("/View/Recuperar.aspx");
        
    }

    protected void BT_Salir_Click(object sender, EventArgs e)
    {
        Response.Redirect("/View/Inicio/InicioNosotros.aspx");

    }
}