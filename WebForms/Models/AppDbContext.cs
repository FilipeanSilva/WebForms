using System.Data.Entity;
using WebForms.Models.Users;

namespace WebForms.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("MyConnectionString")
        {
        }

        public DbSet<User> Users { get; set; }

    }
}