using Microsoft.AspNetCore.Mvc;
using PizzaOrdering_Mvc.DTO;
using PizzaOrdering_Mvc.Models;
using PizzaOrdering_Mvc.PizzaApp_DbContext;

namespace PizzaOrdering_Mvc.Controllers
{
    public class PizzaController : Controller
    {
        private readonly PizzaAppDbContext _pizzaAppDbContext;
        public PizzaController(PizzaAppDbContext pizzaAppDbContext)
        {
            _pizzaAppDbContext = pizzaAppDbContext;
        }
        [HttpGet]
        public IActionResult CreatePizza()
        {
            try
            {
                ViewBag.Bases = _pizzaAppDbContext.Base.ToList();
                ViewBag.Toppings = _pizzaAppDbContext.Toppings.ToList();
                ViewBag.Sizes = _pizzaAppDbContext.Size.ToList();

                return View(new PizzaViewModel());
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "No functionality to create Pizza was found.";
                return View();
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
                _pizzaAppDbContext.Pizza.Add(pizza);
                _pizzaAppDbContext.SaveChanges();
                var toppingsOrders = new List<PizzaTopping>();
                foreach (var toppingId in model.ToppingIds)
                {
                    var toppingsOrder = new PizzaTopping
                    {
                        PizzaId = pizza.PizzaId,
                        ToppingId = toppingId
                    };
                    toppingsOrders.Add(toppingsOrder);
                }
                _pizzaAppDbContext.PizzaTopping.AddRange(toppingsOrders);
                _pizzaAppDbContext.SaveChanges();
                var order = new Order
                {
                    PizzaId = pizza.PizzaId
                };
                _pizzaAppDbContext.Order.Add(order);
                _pizzaAppDbContext.SaveChanges();
                return RedirectToAction("CreatePizza");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "Pizza not created.";
                return View();
            }

        }
    }
}
