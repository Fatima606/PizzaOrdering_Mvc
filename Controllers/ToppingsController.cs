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
                        ToppingId = top.ToppingId,
                        ToppingName = top.ToppingName,
                        Topping_percentage = ((double)(_pizzaAppDbContext.PizzaTopping.Where(pt => pt.ToppingId == top.ToppingId).Count())/ Total_orders)*100
                    };
                    top_list = top_list.OrderByDescending(t => t.Topping_percentage).ToList();
                    top_list.Add(topping);
                }
                return View(top_list);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "No Orders found.";
                return View();
            }

        }
    }

}
