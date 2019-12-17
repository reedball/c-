using Microsoft.EntityFrameworkCore;

namespace CBelt.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users {get;set;}
        public DbSet<Activ> Activs {get;set;}
        public DbSet<Participate> Participates { get;set; }
        public DbSet<Comment> Comments { get;set; }

    }
}
