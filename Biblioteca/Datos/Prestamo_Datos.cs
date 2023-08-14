using System.Data.SqlClient;
using System.Data;
using Biblioteca.Datos;
using Prestamo.Models;

namespace Presatamo_Datos
{
    public class Prestamo_Datos
    {
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
                    cmd.Parameters.AddWithValue("Fecha de Pedido", model.Fecha_de_pedido);
                    cmd.Parameters.AddWithValue("Fecha de Entrega", model.Fecha_de_entrega);
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

        public bool Presatamo_Actualizar(PrestamoModel model)
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
                    cmd.Parameters.AddWithValue("Fecha de pedido", model.Fecha_de_pedido);
                    cmd.Parameters.AddWithValue("Fecha de entrega", model.Fecha_de_entrega);
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
