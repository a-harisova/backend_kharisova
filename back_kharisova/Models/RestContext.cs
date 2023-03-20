using Microsoft.EntityFrameworkCore;

namespace back_kharisova.Models
{
    public class RestContext: DbContext
    {
        public RestContext(DbContextOptions<RestContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<back_kharisova.Models.Dish> Dish { get; set; }
    public DbSet<back_kharisova.Models.Restaurant> Restaurant { get; set; }
    }
}
