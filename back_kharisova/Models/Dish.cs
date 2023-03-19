//using System.ComponentModel.DataAnnotations;

namespace back_kharisova.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        //[DataType(DataType.Date)]
        public string? Name { get; set; }
        //[DataType(DataType.Date)]
        public int? Weight { get; set; }
        public int Calories { get; set; }
        public int Amount { get; set; }
        public decimal? Price { get; set; }

    }
}
