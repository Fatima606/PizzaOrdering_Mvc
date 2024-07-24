using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaOrdering_Mvc.PizzaApp_DbContext;

namespace PizzaOrdering_Mvc.Controllers
{
    public class FamousToppingsController : Controller
    {
        private readonly PizzaAppDbContext _pizzaLoading;
        public FamousToppingsController(PizzaAppDbContext pizzaLoading)
        {
            _pizzaLoading = pizzaLoading;
        }
        public IActionResult FamousToppings()
        {
            try
            {
                var ConfirmedOrders = _pizzaLoading.Pizza.Include(co => co.Size).Include(co => co._base).ToList();
                var pizzaToppings = new Dictionary<Guid, List<string>>();
                foreach (var order in ConfirmedOrders)
                {
                    var toppings = _pizzaLoading.PizzaTopping
                        .Where(to => to.PizzaId == order.PizzaId)
                        .Select(to => to.Topping.ToppingName)
                        .ToList();

                    pizzaToppings[order.PizzaId] = toppings;

                }

                TempData["PizzaToppings"] = pizzaToppings;

                return View(ConfirmedOrders);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
