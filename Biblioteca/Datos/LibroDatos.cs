using Libro.Models;
using System.Data.SqlClient;
using System.Data;
using Biblioteca.Datos;

namespace libros.Datos
{
    public class LibroDatos
    {
        /*añadir libro*/
        public bool AñadirLibro(LibroModel model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_añadirLibro", conexion);
                    cmd.Parameters.AddWithValue("Autor", model.Autor);
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("Cantidad", model.Cantidad);
                    cmd.Parameters.AddWithValue("ISBN", model.ISBN);
                    cmd.Parameters.AddWithValue("F_compra", model.F_Compra);
                    cmd.Parameters.AddWithValue("F_adquisicion", model.F_Adquisicion);
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

        /*eliminar libro*/
        public bool eliminarLibro(int IdLibro)
         {
             bool respuesta;
             try
             {
                 var cn = new Conexion();
                 using (var conexion = new SqlConnection(cn.getCadenaSql()))
                 {
                     conexion.Open();
                     SqlCommand cmd = new SqlCommand("sp_eliminarLibro", conexion);
                     cmd.Parameters.AddWithValue("IdLibro", IdLibro);
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

         /*editar libros*/
        public bool editarLibros(LibroModel model)
         {
             bool respuesta;
             try
             {
                 var cn = new Conexion();
                 using (var conexion = new SqlConnection(cn.getCadenaSql()))
                 {
                     conexion.Open();
                     SqlCommand cmd = new SqlCommand("sp_modificarLibros", conexion);
                     cmd.Parameters.AddWithValue("IdUsuario", model.IdLibro);
                     cmd.Parameters.AddWithValue("Autor", model.Autor);
                     cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                     cmd.Parameters.AddWithValue("Cantidad", model.Cantidad);
                     cmd.Parameters.AddWithValue("ISBN", model.ISBN);
                     cmd.Parameters.AddWithValue("F_compra", model.F_Compra);
                     cmd.Parameters.AddWithValue("F_Adquisicion", model.F_Adquisicion);

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

        /*
                     oConsulta.Add(new LibroModel()
                     {
                         IdLibro = Convert.ToInt32(dr["IdLibro"]),
                         Autor = dr["Autor"].ToString(),
                         Nombre = dr["nombre"].ToString(),
                         Cantidad = Convert.ToInt32(dr["Cantidad"]),
                         ISBN = dr["ISBN"].ToString(),
                         F_Compra = (DateTime)dr["F_compra"],
                         F_Adquisicion = (DateTime)dr["F_adquisicion"]

                     });
                    */

        /*Obtener libros especificos*/
        public LibroModel obtenerLi(int IdLibro)
         {
             var oConsulta = new LibroModel();

             var cn = new Conexion();


             using (var conexion = new SqlConnection(cn.getCadenaSql()))
             {
                 conexion.Open();

                 SqlCommand cmd = new SqlCommand("sp_consultaLibro", conexion);

                 cmd.Parameters.AddWithValue("IdLibro", IdLibro);
                 cmd.CommandType = CommandType.StoredProcedure;

                 using (var fc = cmd.ExecuteReader())
                 {
                     while (fc.Read())
                     {
                        oConsulta.IdLibro = Convert.ToInt32(fc["id"]);
                        oConsulta.Nombre = fc["Nombre"].ToString();
                        oConsulta.Autor = fc["Autor"].ToString();
                        oConsulta.Cantidad = Convert.ToInt32(fc["Cantidad"]);
                        oConsulta.ISBN = fc["ISBN"].ToString();
                        oConsulta.F_Compra = (DateTime)fc["F_Compra"];
                        oConsulta.F_Adquisicion = (DateTime)fc["F_Adquisicion"];
                     }
                 }

             }
             return oConsulta;

        }


     
    }
}
