using JwtAuthAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthAPI.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly AppSettings _appSettings;
        private readonly string _connectionString = "Data Source=.;Database=MassBankDB;Trusted_Connection=True;";
        public AuthenticateService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            //_connectionString = configuration.GetConnectionString("defaultConnection");
            //_connectionString = connectionString;
        }
        private List<User> users = new List<User>()
        {
            new User
            {
                UserID= 1,
                FirstName= "mamunur",
                LastName="maheen",
                Email="mamunurmaheen@gmail.com",
                UserName="mamunurmaheen",
                Password="mamunurmaheen"
            }
        };
        public User Authenticate(string username, string password)
        {
            var user = users.SingleOrDefault(x => x.UserName == username && x.Password == password);
            //if User not found
            if (user == null)
            {
                return null;
            }
            //If User is found
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.UserID.ToString()),
                    new Claim(ClaimTypes.Role,"Admin"),
                    new Claim(ClaimTypes.Version,"v3.1")
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            InsertUser(user);
            user.Password = null;
            return user;
        }

        public async Task<string> InsertUser(User user)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SpInsertUser", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@UserName", user.UserName));
                    cmd.Parameters.Add(new SqlParameter("@Password", user.Password));
                    cmd.Parameters.Add(new SqlParameter("@Token", user.Token));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return "Data Save Successfully";
                }
            }
        }
    }
}
