using System;

namespace bonneTable.Admin.Entities
{
    public class DbAdminUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Salt { get; set; }
        public string HashedPassword { get; set; }
    }
}
