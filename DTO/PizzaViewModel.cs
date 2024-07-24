namespace PizzaOrdering_Mvc.DTO
{
    public class PizzaViewModel
    {
        public Guid BaseId { get; set; }
        public List<Guid> ToppingIds { get; set; } = new List<Guid>();
        public Guid SizeId { get; set; }
    }
}
