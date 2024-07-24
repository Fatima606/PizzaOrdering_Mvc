using System.ComponentModel.DataAnnotations;

namespace PizzaOrdering_Mvc.Models
{
    public class Base
    {
        [Key]
        public Guid baseId { get; set; }
        public string BaseName { get; set; }
    }
}
