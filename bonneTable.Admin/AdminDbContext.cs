using bonneTable.Admin.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace bonneTable.Admin
{
    public class AdminDbContext : DbContext, IAdminDbContext
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options)
            : base(options) { }

        public DbSet<DbAdminUser> AdminUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbAdminUser>(entity =>
            {
                entity.Property(e => e.Id).IsRequired();
            });

            modelBuilder.Entity<DbAdminUser>().HasData(new DbAdminUser
            {
                Id = new Guid("F06899EA-EAE4-45FE-8930-6A0CB983673F"),
                Username = "test",
                Salt = "eKM5gUWEhws0jPdCxdjrJw==",
                HashedPassword = "O8OAc+g+w7l/V0aNCdEnYx+3zE3AXqcJMTCB0ylLhhY="
            });
        }
    }

}
