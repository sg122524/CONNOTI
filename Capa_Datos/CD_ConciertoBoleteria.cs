using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo;

namespace Capa_Datos
{
    public class CD_ConciertoBoleteria
    {
        public static CD_ConciertoBoleteria _instancia = null;

        private CD_ConciertoBoleteria()
        {

        }

        public static CD_ConciertoBoleteria Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_ConciertoBoleteria();
                }
                return _instancia;
            }
        }

        public List<ConciertoBoleteria> ObtenerConciertoBoleteria()
        {
            List<ConciertoBoleteria> rptListaConciertoBoleteria = new List<ConciertoBoleteria>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerConciertoBoleteria", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaConciertoBoleteria.Add(new ConciertoBoleteria()
                        {
                            IdConciertoBoleteria = Convert.ToInt32(dr["IdConciertoBoleteria"].ToString()),
                            oConcierto = new Concierto()
                            {
                                IdConcierto = Convert.ToInt32(dr["IdConcierto"].ToString()),
                                Codigo = dr["CodigoConcierto"].ToString(),
                                Nombre = dr["NombreConcierto"].ToString(),
                                Descripcion = dr["DescripcionConcierto"].ToString(),
                            },
                            oBoleteria = new BOLETERIAS()
                            {
                                IdBoleteria = Convert.ToInt32(dr["IdBoleteria"].ToString()),
                                NIT = dr["NIT"].ToString(),
                                Nombre = dr["NombreBoleteria"].ToString(),
                                Direccion = dr["DireccionBoleteria"].ToString(),
                            },
                            PrecioComun = Convert.ToDecimal(dr["PrecioComun"].ToString(), new CultureInfo("es-PE")),
                            PrecioVIP = Convert.ToDecimal(dr["PrecioVIP"].ToString(), new CultureInfo("es-PE")),
                            Stock = Convert.ToInt32(dr["Stock"].ToString()),
                            Iniciado = Convert.ToBoolean(dr["Iniciado"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaConciertoBoleteria;

                }
                catch (Exception ex)
                {
                    rptListaConciertoBoleteria = null;
                    return rptListaConciertoBoleteria;
                }
            }
        }

        public bool RegistrarConciertoBoleteria(ConciertoBoleteria oConciertoBoleteria)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarConciertoBoleteria", oConexion);
                    cmd.Parameters.AddWithValue("IdConcierto", oConciertoBoleteria.oConcierto.IdConcierto);
                    cmd.Parameters.AddWithValue("IdBoleteria", oConciertoBoleteria.oBoleteria.IdBoleteria);
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

        public bool ModificarConciertoBoleteria(ConciertoBoleteria oConciertoBoleteria)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_ModificarConciertoBoleteria", oConexion);
                    cmd.Parameters.AddWithValue("IdConciertoBoleteria", oConciertoBoleteria.IdConciertoBoleteria);
                    cmd.Parameters.AddWithValue("IdConcierto", oConciertoBoleteria.oConcierto.IdConcierto);
                    cmd.Parameters.AddWithValue("IdTienda", oConciertoBoleteria.oBoleteria.IdBoleteria);
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

        public bool EliminarConciertoBoleteria(int IdConciertoBoleteria)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarConciertoBoleteria", oConexion);
                    cmd.Parameters.AddWithValue("IdConciertoBoleteria", IdConciertoBoleteria);
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

        public bool ControlarStock(int IdConcierto, int IdBoleteria, int Cantidad, bool Restar)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_ControlarStock", oConexion);
                    cmd.Parameters.AddWithValue("IdConcierto", IdConcierto);
                    cmd.Parameters.AddWithValue("IdBoleteria", IdBoleteria);
                    cmd.Parameters.AddWithValue("Cantidad", Cantidad);
                    cmd.Parameters.AddWithValue("Restar", Restar);
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
