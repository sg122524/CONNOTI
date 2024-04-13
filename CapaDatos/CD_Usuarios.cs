using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Usuarios
    {

        

        public List<Usuarios> Listar()
        {
            List<Usuarios> lista = new List<Usuarios>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn) )
                {
                    string query = "select Id_User, name_user, Last_nameUser, email_user, username, passw, TipoU from Usuarios";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Usuarios()
                                {
                                    Id_User = Convert.ToInt32(dr["Id_User"]),
                                    name_user = dr["name_user"].ToString(),
                                    Last_nameUser = dr["Last_nameUser"].ToString(),
                                    email_user = dr["email_user"].ToString(),
                                    username = dr["username"].ToString(),
                                    passw = dr["passw"].ToString()
                                }
                                ) ;
                        }

                    }
                }
            }
            catch
            {
                lista = new List<Usuarios>();
            }








            return lista;



        }

        
    }
}
