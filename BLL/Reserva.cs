using APIHotel.Dato;
using APIHotel.Modelo;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;

namespace APIHotel.BLL
{
    public class Reserva
    {
        public IConfiguration configuration;
        private Conexion conexion;
        public Reserva(IConfiguration configuration)
        {
            this.configuration = configuration;

            conexion = new(this.configuration);
        }

        public object Listar()
        {
            try
            {
                var conn = conexion.GetConnection();
                List<ReservaHabitacionMOD> reservaHabitacion = new();
                conn.Open();


                string cadena = "select * from dbo.ReservaHabitacion ";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {


                    reservaHabitacion.Add(new ReservaHabitacionMOD
                    {
                        ReservaHabitacionID = (long)reader["ReservaHabitacionID"],
                        ClienteID = (long)reader["ClienteID"],
                        HabitacionID = (long)reader["HabitacionID"],
                        EmpleadoID = (long)reader["EmpleadoID"],
                        AgenciaID = (long)reader["AgenciaID"],
                        EstatusReservaID = (long)reader["EstatusReservaID"],
                        Fecha = (reader["Fecha"] != DBNull.Value) ? (DateTime)reader["Fecha"] : (DateTime?)null,
                        FechaEntrada = (reader["FechaEntrada"] != DBNull.Value) ? (DateTime)reader["FechaEntrada"] : (DateTime?)null,
                        FechaSalida = (reader["FechaSalida"] != DBNull.Value) ? (DateTime)reader["FechaSalida"] : (DateTime?)null,

                    });

                }

                return reservaHabitacion;


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public object Buscar(int ReservaHabitacionID)
        {
            try
            {

                var conn = conexion.GetConnection();
                var reservaHabitacion = new ReservaHabitacionMOD();
                conn.Open();


                string cadena = "select * from dbo.ReservaHabitacion where ReservaHabitacionID = @ReservaHabitacionID ";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@ReservaHabitacionID", ReservaHabitacionID);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    reservaHabitacion.ReservaHabitacionID = (long)reader["ReservaHabitacionID"];
                    reservaHabitacion.ClienteID = (long)reader["ClienteID"];
                    reservaHabitacion.HabitacionID = (long)reader["HabitacionID"];
                    reservaHabitacion.EmpleadoID = (long)reader["EmpleadoID"];
                    reservaHabitacion.AgenciaID = (long)reader["AgenciaID"];
                    reservaHabitacion.EstatusReservaID = (long)reader["EstatusReservaID"];
                    reservaHabitacion.Fecha = (reader["Fecha"] != DBNull.Value) ? (DateTime)reader["Fecha"] : (DateTime?)null;
                    reservaHabitacion.FechaEntrada = (reader["FechaEntrada"] != DBNull.Value) ? (DateTime)reader["FechaEntrada"] : (DateTime?)null;
                    reservaHabitacion.FechaSalida = (reader["FechaSalida"] != DBNull.Value) ? (DateTime)reader["FechaSalida"] : (DateTime?)null;

                }

                return reservaHabitacion;


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public object Agregar(JsonElement ReservaHabitacion)
        {
            try
            {
                var reservaHabitacion = ReservaHabitacion.Deserialize<ReservaHabitacionMOD>();
                var conn = conexion.GetConnection();
                conn.Open();

                string fecha = (reservaHabitacion.Fecha != null) ? reservaHabitacion.Fecha.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;
                string fechaEntrada = (reservaHabitacion.FechaEntrada != null) ? reservaHabitacion.FechaEntrada.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;
                string fechaSalida = (reservaHabitacion.FechaSalida != null) ? reservaHabitacion.FechaSalida.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;

               
                string cadena = "insert into dbo.ReservaHabitacion (ClienteID,HabitacionID,EmpleadoID,AgenciaID,EstatusReservaID,Fecha,FechaEntrada,FechaSalida ) values (@ClienteID,@HabitacionID,@EmpleadoID,@AgenciaID,@EstatusReservaID,@Fecha,@FechaEntrada,@FechaSalida )";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@ClienteID", reservaHabitacion.ClienteID);
                command.Parameters.AddWithValue("@HabitacionID", reservaHabitacion.HabitacionID);
                command.Parameters.AddWithValue("@EmpleadoID", reservaHabitacion.EmpleadoID);
                command.Parameters.AddWithValue("@AgenciaID", reservaHabitacion.AgenciaID);
                command.Parameters.AddWithValue("@EstatusReservaID", reservaHabitacion.EstatusReservaID);
                command.Parameters.AddWithValue("@Fecha", fecha);
                command.Parameters.AddWithValue("@FechaEntrada", fechaEntrada);
                command.Parameters.AddWithValue("@FechaSalida", fechaSalida);

                command.ExecuteNonQuery();

                return new { mensaje = "Se ingreso la reserva de la habitacion" };


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }
        public object Modificar(int id, JsonElement ReservaHabitacion)
        {
            try
            {
                var reservaHabitacion = ReservaHabitacion.Deserialize<ReservaHabitacionMOD>();
                var conn = conexion.GetConnection();
                conn.Open();

                string fecha = (reservaHabitacion.Fecha != null) ? reservaHabitacion.Fecha.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;
                string fechaEntrada = (reservaHabitacion.FechaEntrada != null) ? reservaHabitacion.FechaEntrada.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;
                string fechaSalida = (reservaHabitacion.FechaSalida != null) ? reservaHabitacion.FechaSalida.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;


                string cadena = "update dbo.ReservaHabitacion set ClienteID = @ClienteID,HabitacionID = @HabitacionID,EmpleadoID = @EmpleadoID,AgenciaID = @AgenciaID,EstatusReservaID=@EstatusReservaID,Fecha=@Fecha,FechaEntrada=@FechaEntrada,FechaSalida=@FechaSalida where ReservaHabitacionID = @ReservaHabitacionID";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@ClienteID", reservaHabitacion.ClienteID);
                command.Parameters.AddWithValue("@HabitacionID", reservaHabitacion.HabitacionID);
                command.Parameters.AddWithValue("@EmpleadoID", reservaHabitacion.EmpleadoID);
                command.Parameters.AddWithValue("@AgenciaID", reservaHabitacion.AgenciaID);
                command.Parameters.AddWithValue("@EstatusReservaID", reservaHabitacion.EstatusReservaID);
                command.Parameters.AddWithValue("@Fecha", fecha);
                command.Parameters.AddWithValue("@FechaEntrada", fechaEntrada);
                command.Parameters.AddWithValue("@FechaSalida", fechaSalida);
                command.Parameters.AddWithValue("@ReservaHabitacionID", id);


                command.ExecuteNonQuery();

                return new { mensaje = "Se modifico la reservacion" };


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
                List<EstatusReservaMOD> EstatusReserva = new();
                conn.Open();


                string cadena = "select * from dbo.EstatusReserva ";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {


                    EstatusReserva.Add(new EstatusReservaMOD
                    {
                        EstatusReservaID = (long)reader["EstatusReservaID"],
                        Nombre = reader["Nombre"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),



                    });

                }

                return EstatusReserva;


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public object BuscarEstatus(int EstatusReservaID)
        {
            try
            {

                var conn = conexion.GetConnection();
                var EstatusReserva = new EstatusReservaMOD();
                conn.Open();


                string cadena = "select * from dbo.EstatusReserva where EstatusReservaID = @EstatusReservaID ";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@EstatusReservaID", EstatusReservaID);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    EstatusReserva.EstatusReservaID = (long)reader["EstatusReservaID"];
                    EstatusReserva.Nombre = reader["Nombre"].ToString();
                    EstatusReserva.Descripcion = reader["Descripcion"].ToString();



                }

                return EstatusReserva;


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public object AgregarEstatus(JsonElement EstatusReserva)
        {
            try
            {
                var estatusReserva = EstatusReserva.Deserialize<EstatusReservaMOD>();
                var conn = conexion.GetConnection();
                conn.Open();


                string cadena = "insert into dbo.EstatusReserva (Nombre,Descripcion ) values (@Nombre,@Descripcion )";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@Nombre", estatusReserva.Nombre);
                command.Parameters.AddWithValue("@Descripcion", estatusReserva.Descripcion);


                command.ExecuteNonQuery();

                return new { mensaje = "Se ingreso el estatus de reserva" };


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }
        public object ModificarEstatus(int id, JsonElement EstatusReserva)
        {
            try
            {
                var estatusReserva = EstatusReserva.Deserialize<EstatusReservaMOD>();
                var conn = conexion.GetConnection();
                conn.Open();


                string cadena = "update dbo.EstatusReserva set Nombre = @Nombre,Descripcion = @Descripcion where EstatusReservaID = @EstatusReservaID";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@Nombre", estatusReserva.Nombre);
                command.Parameters.AddWithValue("@Descripcion", estatusReserva.Descripcion);
                command.Parameters.AddWithValue("@EstatusReservaID", id);
                command.ExecuteNonQuery();

                return new { mensaje = "Se modifico el estatus de la reserva" };


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }
    }
}
