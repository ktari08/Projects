using Microsoft.EntityFrameworkCore;

namespace redtag90.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users {get;set;}
        public DbSet<Product> Products {get;set;}
    }
}