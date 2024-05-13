using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo;

namespace Capa_Datos
{
    public class CD_Genero
    {
        public static CD_Genero _instancia = null;

        private CD_Genero()
        {

        }

        public static CD_Genero Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Genero();
                }
                return _instancia;
            }
        }

        public List<Genero> ObtenerGenero()
        {
            List<Genero> rptListaGenero = new List<Genero>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerGeneros", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaGenero.Add(new Genero()
                        {
                            IdGenero = Convert.ToInt32(dr["IdGenero"].ToString()),
                            Descripcion = dr["Descripcion"].ToString(),
                            Activo = Convert.ToBoolean(dr["Activo"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaGenero;

                }
                catch (Exception ex)
                {
                    rptListaGenero = null;
                    return rptListaGenero;
                }
            }
        }

        public bool RegistrarGenero(Genero oGenero)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarGenero", oConexion);
                    cmd.Parameters.AddWithValue("Descripcion", oGenero.Descripcion);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public bool ModificarGenero(Genero oGenero)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_ModificarGenero", oConexion);
                    cmd.Parameters.AddWithValue("IdCategoria", oGenero.IdGenero);
                    cmd.Parameters.AddWithValue("Descripcion", oGenero.Descripcion);
                    cmd.Parameters.AddWithValue("Activo", oGenero.Activo);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }

        public bool EliminarGenero(int IdGenero)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarGenero", oConexion);
                    cmd.Parameters.AddWithValue("IdGenero", IdGenero);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }
    }
}
