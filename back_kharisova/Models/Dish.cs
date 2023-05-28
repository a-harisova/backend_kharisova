//using System.ComponentModel.DataAnnotations;

namespace back_kharisova.Models
{
    public class Dish
    {
        public enum DishType
        {
            Pizza,
            Sushi,
            Burger,
            Roll,
            Soup,
            Pasta,
            Rice, // рис (разные виды риса)
            Appetizer, // закуска (чесночные палочки, кальмары и т.д.)
            Dessert, // десерт (мороженое/пирожное/что-то сладенькое)
            Beverage // напиток
        }
        public int Id { get; set; }
        public DishType Type { get; set; }
        public string? Name { get; set; }
        public int Weight { get; set; }
        public double Calories { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public double TotalCalories
        {
            get { return Calories * Weight / 100; }
        }
    }
}
