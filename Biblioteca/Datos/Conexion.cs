using System.Data.SqlClient;

namespace Biblioteca.Datos
{
    public class Conexion
    {
        private string cadenaSql = string.Empty;

        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(
                Directory.GetCurrentDirectory()).AddJsonFile("appsettinga.json").Build();
            cadenaSql = builder.GetSection("connectionStrings:cadenaSql").Value;

        }

        public string getCadenaSql()
        {
            return cadenaSql;
        }

    }
}
