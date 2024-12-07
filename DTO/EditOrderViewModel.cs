using PizzaOrdering_Mvc.Models;

namespace PizzaOrdering_Mvc.DTO
{
    public class EditOrderViewModel: PizzaViewModel
    {
        public Guid PizzaId { get; set; }
    }
}
