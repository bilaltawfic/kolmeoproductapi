using KolmeoProductApi.Models.Contexts;
using Microsoft.EntityFrameworkCore;

namespace KolmeoProductApi.Tests
{
    public class BaseTestClass
    {
        protected DbContextOptions<KolmeoProductDbContext> ContextOptions { get; }

        protected BaseTestClass(DbContextOptions<KolmeoProductDbContext> contextOptions)
        {
            ContextOptions = contextOptions;

            Initialise();
        }

        private void Initialise()
        {
            using (var context = new KolmeoProductDbContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
    }
}
