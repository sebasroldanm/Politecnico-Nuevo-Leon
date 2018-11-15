using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Datos
{
    public class DSql
    {
        private SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString);
        private DataSet ds;

        public DataTable listaacuestu()
        {
            try
            {
                conection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM usuario.listaestuacu()", conection);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);

                ds = new DataSet();
                ad.Fill(ds, "tabla");

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

            return ds.Tables["tabla"];
        }


        public DataTable listaestsincurso()
        {
            try
            {
                conection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM registro.f_estudiantes_sincurso()", conection);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);

                ds = new DataSet();
                ad.Fill(ds, "tabla");

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

            return ds.Tables["tabla"];
        }


        public DataTable listarControlesExcluir(int formular, string idioma)
        {
            try
            {
                conection.Open();
                String query = "Select * FROM idioma.f_listar_controles_excluir(" + formular + ",'" + idioma + "');";
                SqlCommand cmd = new SqlCommand(query, conection);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);

                ds = new DataSet();
                ad.Fill(ds, "tabla");

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

            return ds.Tables["tabla"];
        }


        public DataSet ListaEstAcuServ()
        {
            try
            {
                conection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM usuario.listaestuacu()", conection);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);

                ds = new DataSet();
                ad.Fill(ds);

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

            return ds;
        }

    }
}
