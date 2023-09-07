using APIHotel.Dato;
using APIHotel.Modelo;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;

namespace APIHotel.BLL
{
    public class Habitacion
    {
        public IConfiguration configuration;
        private Conexion conexion;
        public Habitacion(IConfiguration configuration)
        {
            this.configuration = configuration;

            conexion = new(this.configuration);
        }

        public object Listar()
        {
            try
            {
                var conn = conexion.GetConnection();
                List<HabitacionMOD> habitacion = new();
                conn.Open();


                string cadena = "select * from dbo.Habitacion ";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {


                    habitacion.Add(new HabitacionMOD
                    {
                        HabitacionID = (long)reader["HabitacionID"],
                        Ubicacion = reader["Ubicacion"].ToString(),
                        Precio = (decimal)reader["Precio"],
                        Descripcion = reader["Descripcion"].ToString(),
                        TipoHabitacionID = (long)reader["TipoHabitacionID"],
                        EstatusHabitacionID = (long)reader["EstatusHabitacionID"],


                    });

                }

                return habitacion;


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public object Buscar(int HabitacionID)
        {
            try
            {

                var conn = conexion.GetConnection();
                var habitacion = new HabitacionMOD();
                conn.Open();


                string cadena = "select * from dbo.Habitacion where HabitacionID = @HabitacionID ";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@HabitacionID", HabitacionID);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    habitacion.HabitacionID = (long)reader["HabitacionID"];
                    habitacion.Ubicacion = reader["Ubicacion"].ToString();
                    habitacion.Precio = (decimal)reader["Precio"];
                    habitacion.Descripcion = reader["Descripcion"].ToString();
                    habitacion.TipoHabitacionID = (long)reader["TipoHabitacionID"];
                    habitacion.EstatusHabitacionID = (long)reader["EstatusHabitacionID"];


                }

                return habitacion;


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public object Agregar(JsonElement Habitacion)
        {
            try
            {
                var habitacion = Habitacion.Deserialize<HabitacionMOD>();
                var conn = conexion.GetConnection();
                conn.Open();


                string cadena = "insert into dbo.Habitacion (Ubicacion,Precio,Descripcion,TipoHabitacionID,EstatusHabitacionID ) values (@Ubicacion,@Precio,@Descripcion,@TipoHabitacionID,@EstatusHabitacionID )";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@Ubicacion", habitacion.Ubicacion);
                command.Parameters.AddWithValue("@Precio", habitacion.Precio);
                command.Parameters.AddWithValue("@Descripcion", habitacion.Descripcion);
                command.Parameters.AddWithValue("@TipoHabitacionID", habitacion.TipoHabitacionID);
                command.Parameters.AddWithValue("@EstatusHabitacionID", habitacion.EstatusHabitacionID);


                command.ExecuteNonQuery();

                return new { mensaje = "Se ingreso el habitacion" };


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }
        public object Modificar(int id, JsonElement Habitacion)
        {
            try
            {
                var habitacion = Habitacion.Deserialize<HabitacionMOD>();
                var conn = conexion.GetConnection();
                conn.Open();


                string cadena = "update dbo.Habitacion set Ubicacion = @Ubicacion,Precio = @Precio,Descripcion = @Descripcion,TipoHabitacionID = @TipoHabitacionID,EstatusHabitacionID=@EstatusHabitacionID where HabitacionID = @HabitacionID";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@Ubicacion", habitacion.Ubicacion);
                command.Parameters.AddWithValue("@Precio", habitacion.Precio);
                command.Parameters.AddWithValue("@Descripcion", habitacion.Descripcion);
                command.Parameters.AddWithValue("@TipoHabitacionID", habitacion.TipoHabitacionID);
                command.Parameters.AddWithValue("@EstatusHabitacionID", habitacion.EstatusHabitacionID);
                command.Parameters.AddWithValue("@HabitacionID", id);


                command.ExecuteNonQuery();

                return new { mensaje = "Se modifico el habitacion" };


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public object ListarEstatus()
        {
            try
            {
                var conn = conexion.GetConnection();
                List<EstatusHabitacionMOD> EstatusHabitacion = new();
                conn.Open();


                string cadena = "select * from dbo.EstatusHabitacion ";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {


                    EstatusHabitacion.Add(new EstatusHabitacionMOD
                    {
                        EstatusHabitacionID = (long)reader["EstatusHabitacionID"],
                        Nombre = reader["Nombre"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        


                    });

                }

                return EstatusHabitacion;


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public object BuscarEstatus(int EstatusHabitacionID)
        {
            try
            {

                var conn = conexion.GetConnection();
                var EstatusHabitacion = new EstatusHabitacionMOD();
                conn.Open();


                string cadena = "select * from dbo.EstatusHabitacion where EstatusHabitacionID = @EstatusHabitacionID ";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@EstatusHabitacionID", EstatusHabitacionID);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    EstatusHabitacion.EstatusHabitacionID = (long)reader["EstatusHabitacionID"];
                    EstatusHabitacion.Nombre = reader["Nombre"].ToString();
                    EstatusHabitacion.Descripcion = reader["Descripcion"].ToString();



                }

                return EstatusHabitacion;


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public object AgregarEstatus(JsonElement EstatusHabitacion)
        {
            try
            {
                var estatusHabitacion = EstatusHabitacion.Deserialize<EstatusHabitacionMOD>();
                var conn = conexion.GetConnection();
                conn.Open();


                string cadena = "insert into dbo.EstatusHabitacion (Nombre,Descripcion ) values (@Nombre,@Descripcion )";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@Nombre", estatusHabitacion.Nombre);
                command.Parameters.AddWithValue("@Descripcion", estatusHabitacion.Descripcion);


                command.ExecuteNonQuery();

                return new { mensaje = "Se ingreso el estatus de habitacion" };


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }
        public object ModificarEstatus(int id, JsonElement EstatusHabitacion)
        {
            try
            {
                var estatusHabitacion = EstatusHabitacion.Deserialize<EstatusHabitacionMOD>();
                var conn = conexion.GetConnection();
                conn.Open();


                string cadena = "update dbo.EstatusHabitacion set Nombre = @Nombre,Descripcion = @Descripcion where EstatusHabitacionID = @EstatusHabitacionID";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@Nombre", estatusHabitacion.Nombre);
                command.Parameters.AddWithValue("@Descripcion", estatusHabitacion.Descripcion);
                command.Parameters.AddWithValue("@EstatusHabitacionID", id);


                command.ExecuteNonQuery();

                return new { mensaje = "Se modifico el estatus de la habitacion" };


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public object ListarTipo()
        {
            try
            {
                var conn = conexion.GetConnection();
                List<TipoHabitacionMOD> TipoHabitacion = new();
                conn.Open();


                string cadena = "select * from dbo.TipoHabitacion ";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {


                    TipoHabitacion.Add(new TipoHabitacionMOD
                    {
                        TipoHabitacionID = (long)reader["TipoHabitacionID"],
                        Nombre = reader["Nombre"].ToString(),



                    });

                }

                return TipoHabitacion;


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public object BuscarTipo(int TipoHabitacionID)
        {
            try
            {

                var conn = conexion.GetConnection();
                var TipoHabitacion = new TipoHabitacionMOD();
                conn.Open();


                string cadena = "select * from dbo.TipoHabitacion where TipoHabitacionID = @TipoHabitacionID ";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@TipoHabitacionID", TipoHabitacionID);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    TipoHabitacion.TipoHabitacionID = (long)reader["TipoHabitacionID"];
                    TipoHabitacion.Nombre = reader["Nombre"].ToString();



                }

                return TipoHabitacion;


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public object AgregarTipo(JsonElement TipoHabitacion)
        {
            try
            {
                var tipoHabitacion = TipoHabitacion.Deserialize<TipoHabitacionMOD>();
                var conn = conexion.GetConnection();
                conn.Open();


                string cadena = "insert into dbo.TipoHabitacion (Nombre ) values (@Nombre )";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@Nombre", tipoHabitacion.Nombre);


                command.ExecuteNonQuery();

                return new { mensaje = "Se ingreso el tipo de habitacion" };


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }
        public object ModificarTipo(int id, JsonElement TipoHabitacion)
        {
            try
            {
                var tipoHabitacion = TipoHabitacion.Deserialize<TipoHabitacionMOD>();
                var conn = conexion.GetConnection();
                conn.Open();


                string cadena = "update dbo.TipoHabitacion set Nombre = @Nombre where TipoHabitacionID = @TipoHabitacionID";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@Nombre", tipoHabitacion.Nombre);
                command.Parameters.AddWithValue("@TipoHabitacionID", id);


                command.ExecuteNonQuery();

                return new { mensaje = "Se modifico el tipo de habitacion" };


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }
    }
}
