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
    public class CD_Boleteria
    {
        public static CD_Boleteria _instancia = null;

        private CD_Boleteria()
        {

        }

        public static CD_Boleteria Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Boleteria();
                }
                return _instancia;
            }
        }

        public List<BOLETERIAS> ObtenerBoleteria()
        {
            List<BOLETERIAS> rptListaUsuario = new List<BOLETERIAS>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerBoleteria", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaUsuario.Add(new BOLETERIAS()
                        {
                            IdBoleteria = Convert.ToInt32(dr["IdBoleteria"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                            NIT = dr["NIT"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Activo = Convert.ToBoolean(dr["Activo"].ToString())

                        });
                    }
                    dr.Close();

                    return rptListaUsuario;

                }
                catch (Exception ex)
                {
                    rptListaUsuario = null;
                    return rptListaUsuario;
                }
            }
        }

        public bool RegistrarBoleteria(BOLETERIAS oBoleteria)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarBoleteria", oConexion);
                    cmd.Parameters.AddWithValue("Nombre", oBoleteria.Nombre);
                    cmd.Parameters.AddWithValue("NIT", oBoleteria.NIT);
                    cmd.Parameters.AddWithValue("Direccion", oBoleteria.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", oBoleteria.Telefono);
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


        public bool ModificarBoleteria(BOLETERIAS oBoleteria)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_ModificarBoleteria", oConexion);
                    cmd.Parameters.AddWithValue("IdTienda", oBoleteria.IdBoleteria);
                    cmd.Parameters.AddWithValue("Nombre", oBoleteria.Nombre);
                    cmd.Parameters.AddWithValue("NIT", oBoleteria.NIT);
                    cmd.Parameters.AddWithValue("Direccion", oBoleteria.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", oBoleteria.Telefono);
                    cmd.Parameters.AddWithValue("Activo", oBoleteria.Activo);
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

        public bool EliminarBoleteria(int IdBoleteria)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarBoleteria", oConexion);
                    cmd.Parameters.AddWithValue("IdBoleteria", IdBoleteria);
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
