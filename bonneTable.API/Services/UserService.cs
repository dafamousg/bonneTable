using bonneTable.Admin;
using bonneTable.Admin.Service;
using bonneTable.API.Entities;
using bonneTable.API.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace bonneTable.API.Services
{
    public class UserService : IUserService
    {
        private readonly AdminDbContext _context;
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, AdminDbContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }


        // Make async
        public User Authenticate(string username, string password)
        {
            var fetchedUser = _context.AdminUsers.Where(x => x.Username == username).FirstOrDefault();

            var hashedIncomingPassword = HashingFunction.HashPassword(password, fetchedUser.Salt);


            if (hashedIncomingPassword != fetchedUser.HashedPassword)
            {
                return null;
            }

            var user = new User
            {
                Username = fetchedUser.Username,
                Id = fetchedUser.Id
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            user.Password = null;

            return user;
        }

    }
}
