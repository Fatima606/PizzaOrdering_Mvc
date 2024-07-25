using PizzaOrdering_Mvc.Models;

namespace PizzaOrdering_Mvc.DTO
{
    public class EditOrderViewModel
    {
        public Guid PizzaId { get; set; }
        public Guid PizzaSize { get; set; }
        public Guid PizzaBase { get; set; }
        public List<Guid> PizzaToppings { get; set; } = new List<Guid>();
    }
}
