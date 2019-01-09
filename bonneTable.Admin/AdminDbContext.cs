using bonneTable.Admin.Entities;
using Microsoft.EntityFrameworkCore;


namespace bonneTable.Admin
{
    public class AdminDbContext : DbContext, IAdminDbContext
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options)
            : base(options) { }

        public DbSet<DbAdminUser> AdminUsers { get; set; }
    }
}
