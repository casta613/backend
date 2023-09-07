using APIHotel.Dato;
using APIHotel.Modelo;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;

namespace APIHotel.BLL
{
    public class Empleado
    {
        public IConfiguration configuration;
        private Conexion conexion;
        public Empleado(IConfiguration configuration)
        {
            this.configuration = configuration;

            conexion = new(this.configuration);
        }

        public object Listar()
        {
            try
            {
                var conn = conexion.GetConnection();
                List<EmpleadoMOD> empleado = new();
                conn.Open();


                string cadena = "select * from dbo.Empleado ";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {


                    empleado.Add(new EmpleadoMOD
                    {
                        EmpleadoID = (long)reader["EmpleadoID"],
                        Nombre = reader["Nombre"].ToString(),
                        Telefono = reader["Telefono"].ToString(),
                        Horario = reader["Horario"].ToString(),
                        PuestoID = (long)reader["PuestoID"],

                    });

                }

                return empleado;


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public object Buscar(int EmpleadoID)
        {
            try
            {

                var conn = conexion.GetConnection();
                var empleado = new EmpleadoMOD();
                conn.Open();


                string cadena = "select * from dbo.Empleado where EmpleadoID = @EmpleadoID ";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@EmpleadoID", EmpleadoID);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    empleado.EmpleadoID = (long)reader["EmpleadoID"];
                    empleado.Nombre = reader["Nombre"].ToString();
                    empleado.Telefono = reader["Telefono"].ToString();
                    empleado.Horario = reader["Horario"].ToString();
                    empleado.PuestoID = (long)reader["PuestoID"];


                }

                return empleado;


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public object Agregar(JsonElement Empleado)
        {
            try
            {
                var empleado = Empleado.Deserialize<EmpleadoMOD>();
                var conn = conexion.GetConnection();
                conn.Open();


                string cadena = "insert into dbo.Empleado (Nombre,Telefono,Horario,PuestoID ) values (@Nombre,@Telefono,@Horario,@PuestoID )";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                command.Parameters.AddWithValue("@Telefono", empleado.Telefono);
                command.Parameters.AddWithValue("@Horario", empleado.Horario);
                command.Parameters.AddWithValue("@PuestoID", empleado.PuestoID);

                command.ExecuteNonQuery();

                return new { mensaje = "Se ingreso el empleado" };


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }
        public object Modificar(int id, JsonElement Empleado)
        {
            try
            {
                var empleado = Empleado.Deserialize<EmpleadoMOD>();
                var conn = conexion.GetConnection();
                conn.Open();


                string cadena = "update dbo.Empleado set Nombre = @Nombre,Telefono = @Telefono,Horario = @Horario,PuestoID = @PuestoID where EmpleadoID = @EmpleadoID";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                command.Parameters.AddWithValue("@Telefono", empleado.Telefono);
                command.Parameters.AddWithValue("@Horario", empleado.Horario);
                command.Parameters.AddWithValue("@PuestoID", empleado.PuestoID);
                command.Parameters.AddWithValue("@EmpleadoID", id);


                command.ExecuteNonQuery();

                return new { mensaje = "Se modifico el empleado" };


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public object ListarPuesto()
        {
            try
            {
                var conn = conexion.GetConnection();
                List<PuestoMOD> puesto = new();
                conn.Open();


                string cadena = "select * from dbo.Puesto ";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {


                    puesto.Add(new PuestoMOD
                    {
                        PuestoID = (long)reader["PuestoID"],
                        Nombre = reader["Nombre"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        

                    });

                }

                return puesto;


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public object BuscarPuesto(int PuestoID)
        {
            try
            {

                var conn = conexion.GetConnection();
                var puesto = new PuestoMOD();
                conn.Open();


                string cadena = "select * from dbo.Puesto where PuestoID = @PuestoID ";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@PuestoID", PuestoID);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    puesto.PuestoID = (long)reader["PuestoID"];
                    puesto.Nombre = reader["Nombre"].ToString();
                    puesto.Descripcion = reader["Descripcion"].ToString();
                  


                }

                return puesto;


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public object AgregarPuesto(JsonElement Puesto)
        {
            try
            {
                var puesto = Puesto.Deserialize<PuestoMOD>();
                var conn = conexion.GetConnection();
                conn.Open();


                string cadena = "insert into dbo.Puesto (Nombre,Descripcion ) values (@Nombre,@Descripcion )";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@Nombre", puesto.Nombre);
                command.Parameters.AddWithValue("@Descripcion", puesto.Descripcion);
                

                command.ExecuteNonQuery();

                return new { mensaje = "Se ingreso el puesto" };


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }
        public object ModificarPuesto(int id, JsonElement Puesto)
        {
            try
            {
                var puesto = Puesto.Deserialize<PuestoMOD>();
                var conn = conexion.GetConnection();
                conn.Open();


                string cadena = "update dbo.Puesto set Nombre = @Nombre,Descripcion = @Descripcion where PuestoID = @PuestoID";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@Nombre", puesto.Nombre);
                command.Parameters.AddWithValue("@Descripcion", puesto.Descripcion);
                command.Parameters.AddWithValue("@PuestoID", id);


                command.ExecuteNonQuery();

                return new { mensaje = "Se modifico el puesto" };


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }
    }
}
