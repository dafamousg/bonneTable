using bonneTable.API.Entities;
using System.Collections.Generic;

namespace bonneTable.API.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        //IEnumerable<User> GetAll();
    }
}
