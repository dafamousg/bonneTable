using bonneTable.Admin.Entities;
using Microsoft.EntityFrameworkCore;


namespace bonneTable.Admin
{
    public class AdminDbContext : DbContext, IAdminDbContext
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options)
            : base(options) { }

        public DbSet<AdminUser> AdminUsers { get; set; }
    }
}
