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


        public DataTable listarFormulario(UIdioma idioma)
        {
            DataTable Idioma = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_listar_formulario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("formulario", NpgsqlDbType.Integer).Value = idioma.NumFormulario;

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

        public DataTable listarControles(UIdioma idioma)
        {
            DataTable Idioma = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_listar_controles", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_con_formulario_id", NpgsqlDbType.Integer).Value = idioma.IdFormulario;

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
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_listar_controles", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_con_formulario_id", NpgsqlDbType.Integer).Value = idioma.IdFormulario;
                dataAdapter.SelectCommand.Parameters.Add("_control", NpgsqlDbType.Varchar).Value = idioma.Control;

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
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_listar_controles", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_con_formulario_id", NpgsqlDbType.Integer).Value = idioma.IdFormulario;
                dataAdapter.SelectCommand.Parameters.Add("_control", NpgsqlDbType.Varchar).Value = idioma.Control;

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
