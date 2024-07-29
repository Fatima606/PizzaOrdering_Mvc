using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaOrdering_Mvc.DTO;
using PizzaOrdering_Mvc.Models;
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

                List<Guid> AllToppings = new List<Guid>();
                var Pizzas = _pizzaAppDbContext.Pizza.ToList();
                var PizzaCount = _pizzaAppDbContext.Pizza.Count();
                foreach(var pizza in Pizzas)
                {
                    var PizzaToppings = _pizzaAppDbContext.PizzaTopping.Where(toppings => toppings.PizzaId == pizza.PizzaId).Select(toppings => toppings.ToppingId).ToList();
                    for (int i=0;i < _pizzaAppDbContext.Order.Where(pizzaCount=>pizzaCount.PizzaId==pizza.PizzaId).Count(); i++)
                    {
                        foreach (var topping in PizzaToppings)
                        {
                            AllToppings.Add(topping);
                        }
                            
                    }
                }

                var ToppingList = new List<ToppingViewModel>();
                var Toppings = _pizzaAppDbContext.Toppings.ToList();
                foreach(var topping in Toppings)
                {
                    var toppingView = new ToppingViewModel
                    {
                        ToppingName = topping.ToppingName,
                        ToppingCount = AllToppings.Where(toppingId => toppingId == topping.ToppingId).Count()
                    };
                    ToppingList.Add(toppingView);
                }
                var maxTopping = ToppingList.OrderByDescending(t => t.ToppingCount).FirstOrDefault();
                ViewBag.maxToppingsName = maxTopping.ToppingName;
                ViewBag.maxToppingPercentage = ((double)maxTopping.ToppingCount / AllToppings.Count()) * 100;

                var minTopping = ToppingList.OrderBy(t => t.ToppingCount).FirstOrDefault();
                ViewBag.minToppingsName = minTopping.ToppingName;
                ViewBag.minToppingPercentage = ((double)minTopping.ToppingCount / AllToppings.Count()) * 100;


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
