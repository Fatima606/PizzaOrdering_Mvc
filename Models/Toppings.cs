using System.ComponentModel.DataAnnotations;

namespace PizzaOrdering_Mvc.Models
{
    public class Toppings
    {
        [Key]
        public Guid ToppingId { get; set; }
        public string ToppingName { get; set; }
    }
}
