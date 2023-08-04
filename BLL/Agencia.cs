using APIHotel.Dato;
using APIHotel.Modelo;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;

namespace APIHotel.BLL
{
    public class Agencia
    {
        public IConfiguration configuration;
        private Conexion conexion;
        public Agencia(IConfiguration configuration)
        {
            this.configuration = configuration;

            conexion = new(this.configuration);
        }

        public object Listar()
        {
            try
            {
                var conn = conexion.GetConnection();
                List<RespAgencia> agencias = new();
                conn.Open();


                string cadena = "select * from dbo.Agencia ";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {


                    agencias.Add(new RespAgencia
                    {
                        AgenciaID = (long)reader["AgenciaID"],
                        Nombre = reader["Nombre"].ToString(),
                        Telefono = reader["Telefono"].ToString(),
                   
                    });

                }

                return agencias;


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public object Buscar(int AgenciaID)
        {
            try
            {
               
                var conn = conexion.GetConnection();
                var agencia = new ReqAgencia();
                conn.Open();


                string cadena = "select * from dbo.Agencia where AgenciaID = @AgenciaID ";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@AgenciaID", AgenciaID);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {


                    agencia.AgenciaID = (long)reader["AgenciaID"];
                    agencia.Nombre = reader["Nombre"].ToString();
                    agencia.Telefono = reader["Telefono"].ToString();
                 

                }

                return agencia;


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public object Agregar(JsonElement Agencia)
        {
            try
            {
                var agencia = Agencia.Deserialize<ReqAgencia>();
                var conn = conexion.GetConnection();
                conn.Open();


                string cadena = "insert into dbo.Agencia (Nombre,Telefono ) values (@Nombre,@Telefono )";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@Nombre", agencia.Nombre);
                command.Parameters.AddWithValue("@Telefono", agencia.Telefono);

                command.ExecuteNonQuery();

                return new { mensaje = "Se ingreso la agencia" };


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }
        public object Modificar(int id, JsonElement Agencia)
        {
            try
            {
                var agencia = Agencia.Deserialize<ReqAgencia>();
                var conn = conexion.GetConnection();
                conn.Open();


                string cadena = "update dbo.Agencia set Nombre = @Nombre,Telefono = @Telefono where AgenciaID = @AgenciaID";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@Nombre", agencia.Nombre);
                command.Parameters.AddWithValue("@Telefono", agencia.Telefono);
                command.Parameters.AddWithValue("@AgenciaID", id);


                command.ExecuteNonQuery();

                return new { mensaje = "Se modifico la agencia" };


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }
    }
}
