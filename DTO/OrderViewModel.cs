using PizzaOrdering_Mvc.Models;

namespace PizzaOrdering_Mvc.DTO
{
    public class OrderViewModel
    {
        public Guid PizzaId { get; set; }
        public string PizzaSize { get; set; }
        public string PizzaBase { get; set; }
        public List<Toppings> PizzaToppings { get; set; }
        public int no_of_times_ordered { get; set; }
    }
}
