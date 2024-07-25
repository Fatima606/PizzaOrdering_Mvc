namespace PizzaOrdering_Mvc.DTO
{
    public class ToppingViewModel
    {
        public Guid ToppingId { get; set; } 
        public string ToppingName { get; set; }
        public double Topping_percentage { get; set; }  
    }
}
