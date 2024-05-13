using Capa_Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class CD_Reportes
    {
        public static CD_Reportes _instancia = null;

        private CD_Reportes()
        {

        }

        public static CD_Reportes Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CD_Reportes();
                }
                return _instancia;
            }
        }

        public List<ReporteConcierto> ReporteConciertoBoleteria(int IdBoleteria, string CodigoConcierto)
        {
            List<ReporteConcierto> lista = new List<ReporteConcierto>();

            NumberFormatInfo formato = new CultureInfo("es-PE").NumberFormat;
            formato.CurrencyGroupSeparator = ".";

            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_rptConciertoBoleteria", oConexion);
                cmd.Parameters.AddWithValue("@IdBoleteria", IdBoleteria);
                cmd.Parameters.AddWithValue("@Codigo", CodigoConcierto);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteConcierto()
                            {
                                NITBoleteria = dr["NIT Boleteria"].ToString(),
                                NombreBoleteria = dr["Nombre Boleteria"].ToString(),
                                DireccionBoleteria = dr["Direccion Boleteria"].ToString(),
                                CodigoConcierto = dr["Codigo Concierto"].ToString(),
                                NombreConcierto = dr["Nombre Concierto"].ToString(),
                                DescripcionConcierto = dr["Descripcion Concierto"].ToString(),
                                StockenBoleteria = dr["Stock en boleteria"].ToString(),
                                PrecioCompra = Convert.ToDecimal(dr["Precio Compra"].ToString(), new CultureInfo("es-PE")).ToString("N", formato),
                                PrecioVenta = Convert.ToDecimal(dr["Precio Venta"].ToString(), new CultureInfo("es-PE")).ToString("N", formato)
                            });
                        }

                    }

                }
                catch (Exception ex)
                {
                    lista = new List<ReporteConcierto>();
                }
            }

            return lista;
        }

        public List<ReporteVenta> ReporteVenta(DateTime FechaInicio, DateTime FechaFin, int IdBoleteria)
        {
            List<ReporteVenta> lista = new List<ReporteVenta>();

            NumberFormatInfo formato = new CultureInfo("es-PE").NumberFormat;
            formato.CurrencyGroupSeparator = ".";

            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_rptVenta", oConexion);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", FechaFin);
                cmd.Parameters.AddWithValue("@IdBoleteria", IdBoleteria);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteVenta()
                            {
                                FechaVenta = dr["Fecha Venta"].ToString(),
                                NumeroDocumento = dr["Numero Documento"].ToString(),
                                TipoDocumento = dr["Tipo Documento"].ToString(),
                                NombreBoleteria = dr["Nombre Boleteria"].ToString(),
                                NITBoleteria = dr["Ruc Boleteria"].ToString(),
                                NombreEmpleado = dr["Nombre Empleado"].ToString(),
                                CantidadUnidadesVendidas = dr["Cantidad Unidades Vendidas"].ToString(),
                                CantidadProductos = dr["Cantidad Productos"].ToString(),
                                TotalVenta = Convert.ToDecimal(dr["Total Venta"].ToString(), new CultureInfo("es-PE")).ToString("N", formato)
                            });
                        }

                    }

                }
                catch (Exception ex)
                {
                    lista = new List<ReporteVenta>();
                }
            }

            return lista;

        }
    }
}
