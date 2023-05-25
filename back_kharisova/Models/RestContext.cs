using Microsoft.EntityFrameworkCore;

namespace back_kharisova.Models
{
    public class RestContext: DbContext
    {
        public RestContext(DbContextOptions<RestContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<back_kharisova.Models.Dish> Dishes { get; set; }
    public DbSet<back_kharisova.Models.Order> Orders { get; set; }
    }
}
