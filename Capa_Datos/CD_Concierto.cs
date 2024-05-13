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
    public class CD_Concierto
    {
        public static CD_Concierto _instancia = null;

        private CD_Concierto()
        {

        }

        public static CD_Concierto Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Concierto();
                }
                return _instancia;
            }
        }

        public List<Concierto> ObtenerConcierto()
        {
            List<Concierto> rptListaConcierto = new List<Concierto>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerConciertos", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaConcierto.Add(new Concierto()
                        {
                            IdConcierto = Convert.ToInt32(dr["IdConcierto"].ToString()),
                            Codigo = dr["Codigo"].ToString(),
                            ValorCodigo = Convert.ToInt32(dr["ValorCodigo"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                            Descripcion = dr["DescripcionProducto"].ToString(),
                            IdGenero = Convert.ToInt32(dr["IdGenero"].ToString()),
                            oGenero = new Genero() { Descripcion = dr["DescripcionGenero"].ToString() },
                            Activo = Convert.ToBoolean(dr["Activo"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaConcierto;

                }
                catch (Exception ex)
                {
                    rptListaConcierto = null;
                    return rptListaConcierto;
                }
            }
        }

        public bool RegistrarConcierto(Concierto oConcierto)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarConcierto", oConexion);
                    cmd.Parameters.AddWithValue("Nombre", oConcierto.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", oConcierto.Descripcion);
                    cmd.Parameters.AddWithValue("IdGenero", oConcierto.IdGenero);
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

        public bool ModificarConcierto(Concierto oConcierto)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_ModificarConcierto", oConexion);
                    cmd.Parameters.AddWithValue("IdConcierto", oConcierto.IdConcierto);
                    cmd.Parameters.AddWithValue("Nombre", oConcierto.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", oConcierto.Descripcion);
                    cmd.Parameters.AddWithValue("IdGenero", oConcierto.IdGenero);
                    cmd.Parameters.AddWithValue("Activo", oConcierto.Activo);
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

        public bool EliminarConcierto(int IdConcierto)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarConcierto", oConexion);
                    cmd.Parameters.AddWithValue("IdConcierto", IdConcierto);
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
