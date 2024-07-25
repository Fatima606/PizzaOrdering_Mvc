using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaOrdering_Mvc.DTO;
using PizzaOrdering_Mvc.Models;
using PizzaOrdering_Mvc.PizzaApp_DbContext;

namespace PizzaOrdering_Mvc.Controllers
{
    public class OrderController : Controller
    {
        private readonly PizzaAppDbContext _pizzaAppDbContext;
        public OrderController(PizzaAppDbContext pizzaAppDbContext)
        {
            _pizzaAppDbContext = pizzaAppDbContext;
        }
        public IActionResult DisplayOrders()
        {
            try
            {

                List<OrderViewModel> orders = new List<OrderViewModel>();
                var pizzas = _pizzaAppDbContext.Pizza.Include(p => p.Size).Include(p => p._base).ToList();
                foreach (var p in pizzas)
                {
                    var OrderView = new OrderViewModel
                    {
                        PizzaId = p.PizzaId,
                        PizzaSize = p.Size.PizzaSize,
                        PizzaBase = p._base.BaseName,
                        PizzaToppings = _pizzaAppDbContext.PizzaTopping
                        .Where(to => to.PizzaId == p.PizzaId)
                        .Select(to => to.Topping)
                        .ToList(),
                        no_of_times_ordered = _pizzaAppDbContext.Order.Where(to => to.PizzaId == p.PizzaId).Count()
                    };

                    orders.Add(OrderView);


                }
                return View(orders);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "No Orders found.";
                return View();
            }

        }
        [HttpPost]
        public IActionResult ConfirmOrders(Guid pizzaId)
        {
            try
            {
                var order = new Order
                {
                    PizzaId = pizzaId
                };
                _pizzaAppDbContext.Order.Add(order);
                _pizzaAppDbContext.SaveChanges();
                return RedirectToAction("DisplayOrders");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "No View found.";
                return View();
            }

        }
        [HttpGet]
        public IActionResult EditOrders(Guid pizzaId)
        {
            try
            {
                ViewBag.Bases = _pizzaAppDbContext.Base.ToList();
                ViewBag.Toppings = _pizzaAppDbContext.Toppings.ToList();
                ViewBag.Sizes = _pizzaAppDbContext.Size.ToList();
                var orderView = new EditOrderViewModel
                {
                    PizzaId = pizzaId
                };
                return View(orderView);

            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "No View found.";
                return View();
            }

        }
        [HttpPost]
        public IActionResult EditOrders(EditOrderViewModel editted_order)
        {
            try
            {
                var e_order = _pizzaAppDbContext.Pizza.FirstOrDefault(eo => eo.PizzaId == editted_order.PizzaId);
                if (e_order != null)
                {
                    e_order.SizeId = editted_order.PizzaSize;
                    e_order.BaseId = editted_order.PizzaBase;
                    _pizzaAppDbContext.Pizza.Update(e_order);
                    _pizzaAppDbContext.SaveChanges();
                }
                var existingToppings = _pizzaAppDbContext.PizzaTopping
                             .Where(to => to.PizzaId == editted_order.PizzaId)
                             .ToList();
                _pizzaAppDbContext.PizzaTopping.RemoveRange(existingToppings);
                _pizzaAppDbContext.SaveChanges();

                var NewToppings = new List<PizzaTopping>();
                foreach (var toppingId in editted_order.PizzaToppings)
                {
                    var toppingsOrder = new PizzaTopping
                    {
                        PizzaId = editted_order.PizzaId,
                        ToppingId = toppingId
                    };
                    NewToppings.Add(toppingsOrder);
                }
                _pizzaAppDbContext.PizzaTopping.AddRange(NewToppings);
                _pizzaAppDbContext.SaveChanges();

                return RedirectToAction("DisplayOrders");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "No View found.";
                return View();
            }

        }

    }
}
