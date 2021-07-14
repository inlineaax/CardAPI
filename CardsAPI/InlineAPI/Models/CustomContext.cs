using Microsoft.EntityFrameworkCore;

namespace InlineAPI.Models
{
    public class CustomContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<User> Users { get; set; }

        public CustomContext(DbContextOptions<CustomContext> options) : base(options)
        {

        }
    }
}
