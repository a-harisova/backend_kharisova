//using System.ComponentModel.DataAnnotations;

namespace back_kharisova.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? Name { get; set; }
        public int? Weight { get; set; }
        public int Calories { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
    }
}
