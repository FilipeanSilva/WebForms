using System.Data.Entity;
using WebForms.Data;

namespace WebForms.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("MyConnectionString")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<File> Files { get; set; }
    }
}