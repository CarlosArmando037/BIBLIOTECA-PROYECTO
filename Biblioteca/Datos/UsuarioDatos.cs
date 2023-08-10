using CRUDusuario.Models;
using System.Data.SqlClient;
using System.Data;
using Biblioteca.Datos;

namespace usuarios.Datos
{
    public class UsuarioDatos
    {
        /*
        obtener lista (consultar tabla)
        public List<CRUDusuario> Listar()
        {
            var oLista =new List<CRUDusuario>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("sp_")
            }



        }
        

        /*modificar usuarios*/
        public bool AñadirUsuario(UsuarioModel model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_añadirLector", conexion);
                    cmd.Parameters.AddWithValue("Usuario", model.Nombre);
                    cmd.Parameters.AddWithValue("Nombre", model.Apellido);
                    cmd.Parameters.AddWithValue("Apellido", model.Contraseña);
                    cmd.Parameters.AddWithValue("Direccion", model.Correo);
                   
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

        /*eliminar usuarios*/
        public bool eliminarUsuario(int IdUsuario)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_borrarUsuario", conexion);
                    cmd.Parameters.AddWithValue("IdUsuario", IdUsuario);
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

        /*editar usuario*/
        public bool editarUsuario(UsuarioModel model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_modificarUsuario", conexion);
                    cmd.Parameters.AddWithValue("IdUsuario", model.IdUsuario);
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", model.Contraseña);
                    cmd.Parameters.AddWithValue("Direccion", model.Correo);
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

    }
}
