using System;

namespace bonneTable.Admin.Entities
{
    public class AdminUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string HashedPassword { get; set; }
    }
}
