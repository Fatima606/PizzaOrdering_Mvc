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
                var toppings = _pizzaAppDbContext.Toppings.ToList();
                var toppingList = new List<ToppingViewModel>();
                foreach(var topping in toppings)
                {
                    var Pizzatopping = new ToppingViewModel {
                        ToppingName = topping.ToppingName,
                        ToppingCount = _pizzaAppDbContext.PizzaTopping.Where(pizzaToppings => pizzaToppings.ToppingId == topping.ToppingId).Count()
                    };
                    toppingList.Add(Pizzatopping);
                }
                ViewBag.MaxPercentageToppingName = toppingList.FirstOrDefault(topping => topping.ToppingCount == toppingList.Max(topping => topping.ToppingCount)).ToppingName;
                ViewBag.MinPercentageToppingName = toppingList.FirstOrDefault(topping => topping.ToppingCount == toppingList.Min(topping => topping.ToppingCount)).ToppingName;

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
