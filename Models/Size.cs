using System.ComponentModel.DataAnnotations;

namespace PizzaOrdering_Mvc.Models
{
    public class Size
    {
        [Key]
        public Guid SizeId { get; set; }
        public string PizzaSize { get; set; }
    }
}
