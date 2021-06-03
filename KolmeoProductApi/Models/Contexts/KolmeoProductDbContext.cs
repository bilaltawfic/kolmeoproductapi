using Microsoft.EntityFrameworkCore;

namespace KolmeoProductApi.Models.Contexts
{
    public class KolmeoProductDbContext : DbContext
    {
        public KolmeoProductDbContext(DbContextOptions<KolmeoProductDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
