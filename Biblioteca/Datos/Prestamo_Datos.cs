using System.Data.SqlClient;
using System.Data;
using Biblioteca.Datos;
using Prestamo.Models;

namespace Presatamo_Datos
{
    public class Prestamo_Datos
    {

        /*prestamo listar*/
        public List<PrestamoModel> ListaPrestamo()
        {
            var oLista = new List<PrestamoModel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listarprestamo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new PrestamoModel()
                        {
                             idPrestamo= Convert.ToInt32(dr["IdPrestamo"]),
                            Titulo = dr["Titulo"].ToString(),
                            IdUsuario = Convert.ToInt32(dr["IdPrestamo"]),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            Fecha_de_Prestamo = (DateTime)dr["Fecha_de_Prestamo"],
                            Fecha_de_Entrega = (DateTime)dr["Fecha_de_Adquisicion"],
                            Estatus = Convert.ToChar(dr["Estatus"])

                        });
                    }
                }
            }
            return oLista;
        }

        /*GUARDAR LIBRO*/
        public bool Prestamo_Guardar(PrestamoModel model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Fecha de Pedido", model.idPrestamo);
                    cmd.Parameters.AddWithValue("Fecha de Pedido", model.Titulo);
                    cmd.Parameters.AddWithValue("Fecha de Pedido", model.IdUsuario);
                    cmd.Parameters.AddWithValue("Fecha de Pedido", model.Cantidad);
                    cmd.Parameters.AddWithValue("Fecha de Pedido", model.Fecha_de_Prestamo);
                    cmd.Parameters.AddWithValue("Fecha de Entrega", model.Fecha_de_Entrega);
                    cmd.Parameters.AddWithValue("Estatus", model.Estatus);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                respuesta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }

        /*ACTUALIZAR LIBRO*/

        public bool ModificarPresatamo(PrestamoModel model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Actualizar", conexion);
                    cmd.Parameters.AddWithValue("ID Prestamo", model.idPrestamo);
                    cmd.Parameters.AddWithValue("Fecha de pedido", model.Fecha_de_Prestamo);
                    cmd.Parameters.AddWithValue("Fecha de entrega", model.Fecha_de_Entrega);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        public bool Prestamo_Eliminar(PrestamoModel model) 
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("ID Prestamo", model.idPrestamo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                respuesta = true;
            }

            catch (Exception es) 
            {
                string error = es.Message;
                respuesta = false;
            }
            return respuesta;
        }
    }
}
