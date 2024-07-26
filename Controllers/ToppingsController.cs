using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaOrdering_Mvc.DTO;
using PizzaOrdering_Mvc.PizzaApp_DbContext;

namespace PizzaOrdering_Mvc.Controllers
{
    public class ToppingsController : Controller
    {
        private readonly PizzaAppDbContext _pizzaAppDbContext;
        public ToppingsController(PizzaAppDbContext pizzaAppDbContext)
        {
            _pizzaAppDbContext = pizzaAppDbContext;
        }
        public IActionResult DisplayTopping()
        {
            try
            {
                var Total_orders = _pizzaAppDbContext.Order.Count();
                var toppings = _pizzaAppDbContext.Toppings.ToList();
                var top_list = new List<ToppingViewModel>();
                foreach(var top in toppings)
                {
                    var topping = new ToppingViewModel {
                        ToppingName = top.ToppingName,
                        Topping_percentage = ((double)(_pizzaAppDbContext.PizzaTopping.Where(pt => pt.ToppingId == top.ToppingId).Count())/ Total_orders)*100
                    };
                    top_list = top_list.OrderByDescending(t => t.Topping_percentage).ToList();
                    top_list.Add(topping);
                }
                var maxPercentageTopping = top_list.FirstOrDefault(t => t.Topping_percentage == top_list.Max(t => t.Topping_percentage));
                var minPercentageTopping = top_list.FirstOrDefault(t => t.Topping_percentage == top_list.Min(t => t.Topping_percentage));

                ViewBag.MaxPercentageToppingName = maxPercentageTopping;
                ViewBag.MinPercentageToppingName = minPercentageTopping;
                return View();
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "No Toppings found.";
                return View();
            }

        }
    }

}
