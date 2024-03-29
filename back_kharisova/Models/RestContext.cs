﻿using Microsoft.EntityFrameworkCore;
using back_kharisova.Models;

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
    public DbSet<back_kharisova.Models.User> User { get; set; }     // = default!;
    }
}
