namespace back_kharisova.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Sum
        {
            get
            {
                if (Dishes != null && Dishes.Count > 0)
                {
                    decimal sum = 0;
                    foreach (var dish in Dishes)
                    {
                        if (dish.Price.HasValue)
                            sum += dish.Price.Value;
                    }
                    return sum;
                }
                return 0;
            }
        }
        public string? Status { get; set; }
        public virtual List<Dish> Dishes { get; set; }


        // Добавляем внешний ключ для связи с пользователем
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
