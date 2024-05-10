using System;
using System.Collections.Generic;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Usuarios
    {
        public List<usuarios> Listar()
        {
            List<usuarios> lista = new List<usuarios>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = @"SELECT u.ID_Usuario, u.nombre_usuario, u.apellido_usuario, u.correo_usuario, u.contrasena, 
                                    u.tipo_usuario, u.celular_usuario, u.num_NIT, u.reestablecer 
                                    FROM Usuarios u 
                                    INNER JOIN Tipos_Usuario tu ON u.tipo_usuario = tu.ID_Tipo_Usuario";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new usuarios()
                                {
                                    ID_Usuario = Convert.ToInt32(dr["ID_Usuario"]),
                                    nombre_usuario = dr["nombre_usuario"].ToString(),
                                    apellido_usuario = dr["apellido_usuario"].ToString(),
                                    correo_usuario = dr["correo_usuario"].ToString(),
                                    contrasena = dr["contrasena"].ToString(),
                                    tipo_usuario = Convert.ToInt32(dr["tipo_usuario"]),
                                    celular_usuario = dr["celular_usuario"].ToString(),
                                    num_NIT = dr["num_NIT"].ToString(),
                                    reestablecer = Convert.ToBoolean(dr["reestablecer"]),
                                    otiposUsuario = new tiposUsuario()
                                    {
                                        ID_Tipo_Usuario = Convert.ToInt32(dr["ID_Tipo_Usuario"]),
                                        tipo_usuario = dr["tipo_usuario"].ToString()
                                    }
                                });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                lista = new List<usuarios>();
            }
            return lista;
        }
}
}
