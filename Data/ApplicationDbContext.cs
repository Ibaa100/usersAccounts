using Microsoft.EntityFrameworkCore;
using usersAccounts.Models;

namespace usersAccounts.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){
            }
      
        public DbSet<User> Users { get; set; }

    }
}
