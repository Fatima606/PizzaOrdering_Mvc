using Microsoft.AspNetCore.Mvc;
using PizzaOrdering_Mvc.DTO;
using PizzaOrdering_Mvc.Models;
using PizzaOrdering_Mvc.PizzaApp_DbContext;

namespace PizzaOrdering_Mvc.Controllers
{
    public class PizzaController : Controller
    {
        private readonly PizzaAppDbContext _pizzaLoading;
        public PizzaController(PizzaAppDbContext pizzaLoading)
        {
            _pizzaLoading = pizzaLoading;
        }
        [HttpGet]
        public IActionResult CreatePizza()
        {
            try
            {
                ViewBag.bases = _pizzaLoading.Base.ToList();
                ViewBag.toppings = _pizzaLoading.Toppings.ToList();
                ViewBag.sizes = _pizzaLoading.Size.ToList();
                var pizzaDetails = new PizzaViewModel();

                return View(pizzaDetails);
            }
            catch (Exception e)
            {
                return View("Home", "Index");
            }

        }
        [HttpPost]
        public IActionResult CreatePizza(PizzaViewModel model)
        {
            try
            {
                var pizza = new Pizza
                {
                    BaseId = model.BaseId,
                    SizeId = model.SizeId
                };
                _pizzaLoading.Pizza.Add(pizza);
                _pizzaLoading.SaveChanges();
                foreach (var toppingId in model.ToppingIds)
                {
                    var toppingsOrder = new PizzaTopping
                    {
                        PizzaId = pizza.PizzaId,
                        ToppingId = toppingId
                    };
                    _pizzaLoading.PizzaTopping.Add(toppingsOrder);
                    _pizzaLoading.SaveChanges();
                }
                var order = new Order
                {
                    PizzaId = pizza.PizzaId
                };
                _pizzaLoading.Order.Add(order);
                _pizzaLoading.SaveChanges();
                return RedirectToAction("CreatePizza");
            }
            catch (Exception e)
            {
                return View("Home", "Index");
            }

        }
    }
}
