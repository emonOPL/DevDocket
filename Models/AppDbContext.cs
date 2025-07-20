using DevDocket.Models; // Optional if you're using model classes
using Microsoft.EntityFrameworkCore;

namespace DevDocket.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Task> Tasks { get; set; }  
    }
}
