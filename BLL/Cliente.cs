using APIHotel.Dato;
using APIHotel.Modelo;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;

namespace APIHotel.BLL
{
    public class Cliente
    {
        public IConfiguration configuration;
        private Conexion conexion;
        public Cliente(IConfiguration configuration)
        {
            this.configuration = configuration;

            conexion = new(this.configuration);
        }

        public object Listar()
        {
            try
            {
                var conn = conexion.GetConnection();
                List<ClienteMOD> clientes = new();
                conn.Open();


                string cadena = "select * from dbo.Cliente ";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {


                    clientes.Add(new ClienteMOD
                    {
                        ClienteID = (long)reader["ClienteID"],
                        Nombre = reader["Nombre"].ToString(),
                        Celular = reader["Celular"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        Correo = reader["Correo"].ToString(),
                        Documento = reader["Documento"].ToString(),

                    });

                }

                return clientes;


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public object Buscar(int ClienteID)
        {
            try
            {

                var conn = conexion.GetConnection();
                var cliente = new ClienteMOD();
                conn.Open();


                string cadena = "select * from dbo.Cliente where ClienteID = @ClienteID ";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@ClienteID", ClienteID);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {


                    cliente.ClienteID = (long)reader["ClienteID"];
                    cliente.Nombre = reader["Nombre"].ToString();
                    cliente.Apellido = reader["Apellido"].ToString();
                    cliente.Celular = reader["Celular"].ToString();
                    cliente.Documento = reader["Documento"].ToString();
                    cliente.Correo = reader["Correo"].ToString();


                }

                return cliente;


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public object Buscar(string Documento)
        {
            try
            {

                var conn = conexion.GetConnection();
                var cliente = new ClienteMOD();
                conn.Open();


                string cadena = "select * from dbo.Cliente where Documento = @Documento ";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@Documento", Documento);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {


                    cliente.ClienteID = (long)reader["ClienteID"];
                    cliente.Nombre = reader["Nombre"].ToString();
                    cliente.Apellido = reader["Apellido"].ToString();
                    cliente.Celular = reader["Celular"].ToString();
                    cliente.Documento = reader["Documento"].ToString();
                    cliente.Correo = reader["Correo"].ToString();


                }

                return cliente;


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public object Agregar(JsonElement Cliente)
        {
            try
            {
                var cliente = Cliente.Deserialize<ClienteMOD>();
                var conn = conexion.GetConnection();
                conn.Open();


                string cadena = "insert into dbo.Cliente (Nombre,Apellido,Celular,Documento,Correo ) values (@Nombre,@Apellido,@Celular,@Documento,@Correo )";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                command.Parameters.AddWithValue("@Celular", cliente.Celular);
                command.Parameters.AddWithValue("@Documento", cliente.Documento);
                command.Parameters.AddWithValue("@Correo", cliente.Correo);
                command.ExecuteNonQuery();

                return new { mensaje = "Se ingreso el cliente" };


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }
        public object Modificar(int id, JsonElement Cliente)
        {
            try
            {
                var cliente = Cliente.Deserialize<ClienteMOD>();
                var conn = conexion.GetConnection();
                conn.Open();


                string cadena = "update dbo.Cliente set Nombre = @Nombre,Apellido = @Apellido,Celular = @Celular,Documento = @Documento,Correo = @Correo where ClienteID = @ClienteID";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                command.Parameters.AddWithValue("@Celular", cliente.Celular);
                command.Parameters.AddWithValue("@Documento", cliente.Documento);
                command.Parameters.AddWithValue("@Correo", cliente.Correo);
                command.Parameters.AddWithValue("@ClienteID", id);


                command.ExecuteNonQuery();

                return new { mensaje = "Se modifico el cliente" };


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }
    }
}
