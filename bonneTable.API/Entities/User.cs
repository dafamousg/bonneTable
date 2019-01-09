using bonneTable.Admin.Entities;

namespace bonneTable.API.Entities
{
    public class User : AdminUser
    {
        public string Token { get; set; }
    }
}
