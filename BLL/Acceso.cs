using System.Text;
using System.Text.Json;
using APIHotel.MOD;
using APIHotel.Dato;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Data;
using System.Data.SqlClient;

namespace APIHotel.BLL
{
    public class Acceso
    {
        private readonly IConfiguration configuration;
        private Conexion dataBase;

        public Acceso(IConfiguration configuration)
        {
            this.configuration = configuration;
            dataBase = new(this.configuration);

        }

        public object JsonConvert { get; private set; }

        public (object, int) ValidarAcceso(JsonElement request)
        {
            try
            {
                object response;
                int estatus = 0;
                var reqAccesoMod = request.Deserialize<ReqAccesoMOD>();
                string contrasenia = Buscar(reqAccesoMod.Usuario);
                if (reqAccesoMod.Contrasenia.Equals("5")) {
                    var issuer = configuration.GetSection("Jwt:Issuer").Value;
                    var audience = configuration.GetSection("Jwt:Audience").Value;
                    var key = Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:Key").Value);
                    var tokenDescripcion = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new[]
                        {
                            new Claim("Id", Guid.NewGuid().ToString().ToUpper()),
                            new Claim(JwtRegisteredClaimNames.Sub, reqAccesoMod.Usuario),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString().ToUpper())
                        }),
                        Expires = DateTime.UtcNow.AddMinutes(double.Parse(configuration.GetSection("TokenExpires").Value)),
                        Issuer = issuer,
                        Audience = audience,
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature),

                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescripcion);
                    var jwtToken = tokenHandler.WriteToken(securityToken);
                    RespAccesoMOD respAcceso = new();
                    respAcceso.HoraExpiracion = DateTime.UtcNow.AddMinutes(double.Parse(configuration.GetSection("TokenExpires").Value));
                    respAcceso.Token = jwtToken;
                    estatus = 200;
                    response = respAcceso;
                }
                else
                {
                    response = new {mensage ="El usuario o la contraseña son incorrectos" };
                    estatus = 400;
                }
                return (response, estatus);

            }
            catch (Exception ex)
            {
                return (ex, 500);
            }
        }

        public string Buscar(string Usuario)
        {
            try
            {
                string contrasenia = string.Empty;
                var conn = dataBase.GetConnection();
                conn.Open();


                string cadena = "select * from dbo.Usuario where Usuario = @Usuario ";
                SqlCommand command = new SqlCommand(cadena, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = cadena;
                command.Parameters.AddWithValue("@Usuario", Usuario);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {


                    contrasenia = reader["Contrasenia"].ToString();


                }

                return contrasenia;


            }
            catch (Exception ex)
            {

                throw new Exception("", ex);
            }
        }
    }

    
}
