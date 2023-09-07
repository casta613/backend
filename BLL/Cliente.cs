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
                        Telefono = reader["Telefono"].ToString(),

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
                    cliente.Telefono = reader["Telefono"].ToString();


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


                string cadena = "insert into dbo.Cliente (Nombre,Telefono ) values (@Nombre,@Telefono )";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Telefono", cliente.Telefono);

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


                string cadena = "update dbo.Cliente set Nombre = @Nombre,Telefono = @Telefono where ClienteID = @ClienteID";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Telefono", cliente.Telefono);
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
