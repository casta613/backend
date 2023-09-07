using APIHotel.Dato;
using APIHotel.Modelo;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;

namespace APIHotel.BLL
{
    public class Usuario
    {
        public IConfiguration configuration;
        private Conexion conexion;
        public Usuario(IConfiguration configuration)
        {
            this.configuration = configuration;

            conexion = new(this.configuration);
        }

        public object Listar()
        {
            try
            {
                var conn = conexion.GetConnection();
                List<UsuarioMOD> usuario = new();
                conn.Open();


                string cadena = "select * from dbo.Usuario ";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {


                    usuario.Add(new UsuarioMOD
                    {
                        UsuarioID = (long)reader["UsuarioID"],
                        Usuario = reader["Usuario"].ToString(),
                        Contrasenia = reader["Contrasenia"].ToString(),
                        RolID = (long)reader["RolID"],
                        AgenciaID = (long)reader["AgenciaID"],
                        EmpleadoID = (long)reader["EmpleadoID"],


                    });

                }

                return usuario;


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public object Buscar(int UsuarioID)
        {
            try
            {

                var conn = conexion.GetConnection();
                var usuario = new UsuarioMOD();
                conn.Open();


                string cadena = "select * from dbo.Usuario where UsuarioID = @UsuarioID ";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@UsuarioID", UsuarioID);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    usuario.UsuarioID = (long)reader["EmpleadoID"];
                    usuario.Usuario = reader["Usuario"].ToString();
                    usuario.Contrasenia = reader["Contrasenia"].ToString();
                    usuario.RolID = (long)reader["RolID"];
                    usuario.EmpleadoID = (long)reader["EmpleadoID"];
                    usuario.AgenciaID = (long)reader["AgenciaID"];

                }

                return usuario;


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public object Agregar(JsonElement Usuario)
        {
            try
            {
                var usuario = Usuario.Deserialize<UsuarioMOD>();
                var conn = conexion.GetConnection();
                conn.Open();


                string cadena = "insert into dbo.Usuario (Usuario,Contrasenia,RolID,EmpleadoID,AgenciaID ) values (@Usuario,@Contrasenia,@RolID,@EmpleadoID,@AgenciaID )";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@Usuario", usuario.Usuario);
                command.Parameters.AddWithValue("@Contrasenia", usuario.Contrasenia);
                command.Parameters.AddWithValue("@RolID", usuario.RolID);
                command.Parameters.AddWithValue("@EmpleadoID", usuario.EmpleadoID);
                command.Parameters.AddWithValue("@AgenciaID", usuario.AgenciaID);



                command.ExecuteNonQuery();

                return new { mensaje = "Se ingreso el usuario" };


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }
        public object Modificar(int id, JsonElement Usuario)
        {
            try
            {
                var usuario = Usuario.Deserialize<UsuarioMOD>();
                var conn = conexion.GetConnection();
                conn.Open();


                string cadena = "update dbo.Usuario set Usuario = @Usuario,Contrasenia = @Contrasenia,RolID = @RolID,EmpleadoID = @EmpleadoID, AgenciaID = @AgenciaID where UsuarioID = @UsuarioID";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@Usuario", usuario.Usuario);
                command.Parameters.AddWithValue("@Contrasenia", usuario.Contrasenia);
                command.Parameters.AddWithValue("@RolID", usuario.RolID);
                command.Parameters.AddWithValue("@EmpleadoID", usuario.EmpleadoID);
                command.Parameters.AddWithValue("@AgenciaID", usuario.AgenciaID);
                command.Parameters.AddWithValue("@UsuarioID", id);


                command.ExecuteNonQuery();

                return new { mensaje = "Se modifico el usuario" };


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public object ListarRol()
        {
            try
            {
                var conn = conexion.GetConnection();
                List<RolMOD> rol = new();
                conn.Open();


                string cadena = "select * from dbo.Rol ";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {


                    rol.Add(new RolMOD
                    {
                        RolID = (long)reader["RolID"],
                        Nombre = reader["Nombre"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),


                    });

                }

                return rol;


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public object BuscarRol(int RolID)
        {
            try
            {

                var conn = conexion.GetConnection();
                var rol = new RolMOD();
                conn.Open();


                string cadena = "select * from dbo.Rol where RolID = @RolID ";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@RolID", RolID);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    rol.RolID = (long)reader["RolID"];
                    rol.Nombre = reader["Nombre"].ToString();
                    rol.Descripcion = reader["Descripcion"].ToString();



                }

                return rol;


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }

        public object AgregarRol(JsonElement Rol)
        {
            try
            {
                var rol = Rol.Deserialize<RolMOD>();
                var conn = conexion.GetConnection();
                conn.Open();


                string cadena = "insert into dbo.Rol (Nombre,Descripcion ) values (@Nombre,@Descripcion )";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@Nombre", rol.Nombre);
                command.Parameters.AddWithValue("@Descripcion", rol.Descripcion);


                command.ExecuteNonQuery();

                return new { mensaje = "Se ingreso el rol" };


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }
        public object ModificarRol(int id, JsonElement Rol)
        {
            try
            {
                var rol = Rol.Deserialize<RolMOD>();
                var conn = conexion.GetConnection();
                conn.Open();


                string cadena = "update dbo.Rol set Nombre = @Nombre,Descripcion = @Descripcion where RolID = @RolID";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@Nombre", rol.Nombre);
                command.Parameters.AddWithValue("@Descripcion", rol.Descripcion);
                command.Parameters.AddWithValue("@RolID", id);


                command.ExecuteNonQuery();

                return new { mensaje = "Se modifico el rol" };


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }
    }
}
