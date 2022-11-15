using Microsoft.EntityFrameworkCore;

namespace SpongeBob.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
            //Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        public DbSet<SpongeBobFriends> Friends { get; set; }
        public DbSet<Home> Homes { get; set; }
    }
}

