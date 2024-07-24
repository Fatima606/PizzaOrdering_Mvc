using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PizzaOrdering_Mvc.Models
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }

        [ForeignKey("Pizza")]
        public Guid PizzaId { get; set; }
        public Pizza Pizza { get; set; }
    }
}
