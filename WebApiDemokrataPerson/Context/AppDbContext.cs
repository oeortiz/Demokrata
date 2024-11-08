using Microsoft.EntityFrameworkCore;
using WebApiDemokrataPerson.Data.Seeds;
using WebApiDemokrataPerson.Models;

namespace WebApiDemokrataPerson.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
                       
        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserSeed());
        }
    }    
}
