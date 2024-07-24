using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace PizzaOrdering_Mvc.Models
{
    public class Pizza
    {
        [Key]
        public Guid PizzaId { get; set; }

        [ForeignKey("Size")]
        public Guid SizeId { get; set; }
        public Size Size { get; set; }

        [ForeignKey("Base")]
        public Guid BaseId { get; set; }
        public Base _base { get; set; }
    }
}
