using Microsoft.EntityFrameworkCore;

namespace back_kharisova.Models
{
    public class RestContext: DbContext
    {
        public RestContext(DbContextOptions<RestContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<back_kharisova.Models.Dish> Author { get; set; }
    public DbSet<back_kharisova.Models.Restaurant> Book { get; set; }
    }
}
