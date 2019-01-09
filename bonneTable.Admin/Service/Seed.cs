using bonneTable.Admin.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace bonneTable.Admin.Service
{
    public class Seed
    {
        private readonly AdminDbContext _context;
        
        public Seed(AdminDbContext context)
        {
            _context = context;
        }
        
        public async Task SeedDb()
        {
            var list = _context.AdminUsers;

            if (!list.Any())
            {
                var admin1 = new AdminUser { Username = "test", Password = "test" };
                //await _context.AdminUsers.AddAsync(admin1);
                await _context.SaveChangesAsync();
            }
        }
    }
}
