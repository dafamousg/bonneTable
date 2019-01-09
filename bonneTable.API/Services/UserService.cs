using bonneTable.Admin;
using bonneTable.Admin.Entities;
using bonneTable.API.Entities;
using bonneTable.API.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
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

        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        //private List<User> _users = new List<User>
        //{
        //    new User { Id = new Guid("9CB37437-0FAD-4AB4-A9BF-F2CD328C1382"), Username = "test", HashedPassword = "test" },
        //    new User { Id = new Guid("85792967-F3B9-4831-AECA-122A1DFC4F3A"), Username = "otto", HashedPassword = "otto" }
        //};

        public User Authenticate(string username, string password)
        {
            List<User> _users = new List<User>();

            List<AdminUser> _users2 = _context.AdminUsers.ToList();
            foreach (var userAdmin in _users2)
            {
                _users.Add(new User
                {
                    Id = userAdmin.Id,
                    Username = userAdmin.Username,
                    Password = userAdmin.Password
                });
            }

            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            if (user == null)
                return null;

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

        public IEnumerable<User> GetAll()
        {
            List<User> _users = new List<User>();

            List<AdminUser> _users2 = _context.AdminUsers.ToList();
            foreach (var userAdmin in _users2)
            {
                _users.Add(new User
                {
                    Id = userAdmin.Id,
                    Username = userAdmin.Username,
                    Password = userAdmin.Password
                });
            }
            // return users without passwords
            return _users.Select(x =>
            {
                x.Password = null;
                return x;
            });
        }
    }
}
