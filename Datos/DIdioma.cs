using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using System.Configuration;
using Utilitarios;

namespace Datos
{
    public class DIdioma
    {
        public DataTable obtenerIdioma(int form, int idioma)
        {
            DataTable Idioma = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_idioma_formulario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_con_formulario_id", NpgsqlDbType.Integer).Value = form;
                dataAdapter.SelectCommand.Parameters.Add("_con_idioma_id", NpgsqlDbType.Integer).Value = idioma;

                conection.Open();
                dataAdapter.Fill(Idioma);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Idioma;
        }


        //////////////////////////////////////////////DDL ROLES

        public DataTable obtenerroles()
        {
            DataTable Rol = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_listar_rol_usuario_ddl", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                conection.Open();
                dataAdapter.Fill(Rol);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Rol;
        }



        ////////////////////////////////// FIN DDL ROLES

        //////////////////////////////////////////////  DDL DE USUARIOS

        public DataTable listarusuariosxrol(int usuario)
        {
            DataTable Usuariorol = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_listar_usuario_ddl", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_rol_id", NpgsqlDbType.Integer).Value = usuario;
              

                conection.Open();
                dataAdapter.Fill(Usuariorol);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Usuariorol;
        }



        //////////////////////////////////////////////// FIN DDL USUARIOS


        ///////////////////////////////////////////////EDITA SESION USUARIO

        public DataTable editarsesionusua(string usuario, string sesion)
        {
            DataTable Sesion = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_editar_sesion", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            

                dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlDbType.Integer).Value = int.Parse(usuario);
                dataAdapter.SelectCommand.Parameters.Add("_sesionusuario", NpgsqlDbType.Integer).Value = int.Parse(sesion);

                ;

                conection.Open();
                dataAdapter.Fill(Sesion);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Sesion;
        }



        ///////////////////////////////////////////// FIN EDITA SESION USUARIO




        public DataTable obtenerSeleccionIdioma()
        {
            DataTable Idioma = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_seleccion_idioma", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                conection.Open();
                dataAdapter.Fill(Idioma);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Idioma;
        }


        public DataTable obtenerTerminacionIdioma(int idioma)
        {
            DataTable Idioma = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_idioma_terminacion", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_idioma", NpgsqlDbType.Integer).Value = idioma;

                conection.Open();
                dataAdapter.Fill(Idioma);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Idioma;
        }

        public DataTable obtenerRolIdioma()
        {
            DataTable Idioma = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_seleccion_rol", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                conection.Open();
                dataAdapter.Fill(Idioma);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Idioma;
        }

        public DataTable listarFormulario(int idioma)
        {
            DataTable Idioma = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_listar_formulario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_rol", NpgsqlDbType.Integer).Value = idioma;

                conection.Open();
                dataAdapter.Fill(Idioma);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Idioma;
        }

        public DataTable listarControles(int idioma)
        {
            DataTable Idioma = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_listar_controles", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_con_formulario_id", NpgsqlDbType.Integer).Value = idioma;

                conection.Open();
                dataAdapter.Fill(Idioma);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Idioma;
        }

        public DataTable listarControlesExcluir(int formular, string idioma)
        {
            DataTable Idioma = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_listar_controles_excluir", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_con_formulario_id", NpgsqlDbType.Integer).Value = formular;
                dataAdapter.SelectCommand.Parameters.Add("_nom_idioma", NpgsqlDbType.Varchar).Value = idioma;

                conection.Open();
                dataAdapter.Fill(Idioma);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Idioma;


        }


        public DataTable verificarIdiomaBD(string termina)
        {
            DataTable Idioma = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_verificar_idioma", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_termino", NpgsqlDbType.Varchar).Value = termina;

                conection.Open();
                dataAdapter.Fill(Idioma);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Idioma;
        }



        public DataTable listarIdiomaControles(UIdioma idioma)
        {
            DataTable Idioma = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_listar_idioma_control", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_con_formulario_id", NpgsqlDbType.Integer).Value = int.Parse(idioma.IdFormulario);
                dataAdapter.SelectCommand.Parameters.Add("_control", NpgsqlDbType.Varchar).Value =idioma.Control;

                conection.Open();
                dataAdapter.Fill(Idioma);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Idioma;
        }

        public DataTable listarIdiomaControlesEditar(UIdioma idioma)
        {
            DataTable Idioma = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_listar_idioma_control_editar", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_con_formulario_id", NpgsqlDbType.Integer).Value = int.Parse(idioma.IdFormulario);
                dataAdapter.SelectCommand.Parameters.Add("_control", NpgsqlDbType.Varchar).Value = idioma.Control;
                dataAdapter.SelectCommand.Parameters.Add("_con_idioma_id", NpgsqlDbType.Integer).Value = int.Parse(idioma.IdIdioma);

                conection.Open();
                dataAdapter.Fill(Idioma);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Idioma;
        }

        public DataTable insertarIdioma(string nombre, string termina)
        {
            DataTable Idioma = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_insertar_idioma", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Text).Value = nombre;
                dataAdapter.SelectCommand.Parameters.Add("_terminacion", NpgsqlDbType.Varchar).Value = termina;

                conection.Open();
                dataAdapter.Fill(Idioma);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Idioma;
        }


        public DataTable insertarIdiomaControles(UIdioma idioma)
        {
            DataTable Idioma = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_insertar_idioma_control", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_control", NpgsqlDbType.Varchar).Value = idioma.Control;
                dataAdapter.SelectCommand.Parameters.Add("_texto", NpgsqlDbType.Text).Value = idioma.Texto;
                dataAdapter.SelectCommand.Parameters.Add("_con_idioma_id", NpgsqlDbType.Integer).Value = int.Parse(idioma.IdIdioma);
                dataAdapter.SelectCommand.Parameters.Add("_con_formulario_id", NpgsqlDbType.Integer).Value = int.Parse(idioma.IdFormulario);

                conection.Open();
                dataAdapter.Fill(Idioma);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Idioma;
        }


        public DataTable listarIdiomaVarchar(string nombre)
        {
            DataTable Idioma = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_listar_idioma_varchar", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Text).Value = nombre;
                ;

                conection.Open();
                dataAdapter.Fill(Idioma);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Idioma;
        }






        public DataTable editarIdiomaControl(string control, string formul, string idioma, string texto)
        {
            DataTable Idioma = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_editar_idioma_control", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_control", NpgsqlDbType.Varchar).Value = control;
                dataAdapter.SelectCommand.Parameters.Add("_con_formulario_id", NpgsqlDbType.Integer).Value = int.Parse(formul);
                dataAdapter.SelectCommand.Parameters.Add("_con_idioma_id", NpgsqlDbType.Integer).Value = int.Parse(idioma);
                dataAdapter.SelectCommand.Parameters.Add("_texto", NpgsqlDbType.Text).Value = texto;
                ;

                conection.Open();
                dataAdapter.Fill(Idioma);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Idioma;
        }


        public DataTable contadorControl(string idioma)
        {
            DataTable Idioma = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_contador_controles", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_nom_idioma", NpgsqlDbType.Varchar).Value = idioma;

                conection.Open();
                dataAdapter.Fill(Idioma);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Idioma;
        }

        public DataTable obtenerTraerIdioma(string idioma)
        {
            DataTable Idioma = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_obtener_traer_idioma", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Varchar).Value = idioma;
                conection.Open();
                dataAdapter.Fill(Idioma);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Idioma;
        }

        public DataTable eliminarControles(int idioma)
        {
            DataTable Idioma = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_eliminar_idioma_control", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_con_idioma_id", NpgsqlDbType.Integer).Value = idioma;

                conection.Open();
                dataAdapter.Fill(Idioma);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Idioma;
        }

        public DataTable eliminarIdioma(int idioma)
        {
            DataTable Idioma = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_eliminar_idioma", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_idioma", NpgsqlDbType.Integer).Value = idioma;

                conection.Open();
                dataAdapter.Fill(Idioma);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Idioma;
        }

        public DataTable listarSesion(string usuario)
        {
            DataTable Idioma = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.f_listar_sesion", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlDbType.Integer).Value = int.Parse(usuario);
                ;

                conection.Open();
                dataAdapter.Fill(Idioma);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Idioma;
        }

    }
}
