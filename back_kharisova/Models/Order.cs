namespace back_kharisova.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public double? Sum { get; set; }
        public string?  Status { get; set; }
        public List <Dish>? Dishes { get; set; }



    }
}
