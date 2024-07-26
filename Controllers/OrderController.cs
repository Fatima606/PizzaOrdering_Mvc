using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaOrdering_Mvc.DTO;
using PizzaOrdering_Mvc.Models;
using PizzaOrdering_Mvc.PizzaApp_DbContext;
using System.Linq;

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
                        NoTimesOrdered = _pizzaAppDbContext.Order.Where(to => to.PizzaId == p.PizzaId).Count()
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
                var pizza = _pizzaAppDbContext.Pizza.FirstOrDefault(p => p.PizzaId == pizzaId);
                if (pizza != null)
                {
                    var order = new Order
                    {
                        PizzaId = pizzaId
                    };
                    _pizzaAppDbContext.Order.Add(order);
                    _pizzaAppDbContext.SaveChanges();
                    return RedirectToAction("DisplayOrders");
                }
                else
                {
                    TempData["ErrorMessage"]= "This Pizza does not exist.";
                    return RedirectToAction("DisplayOrders");
                }
                
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "Order was not confirmed.";
                return View();
            }

        }
        [HttpGet]
        public IActionResult EditOrders(Guid pizzaId)
        {
            try
            {
                var pizza = _pizzaAppDbContext.Pizza.FirstOrDefault(p => p.PizzaId == pizzaId);
                if (pizza != null)
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
                else
                {
                    ViewBag.ErrorMessage = "Pizza was not found.";
                    ViewBag.Bases = _pizzaAppDbContext.Base.ToList();
                    ViewBag.Toppings = _pizzaAppDbContext.Toppings.ToList();
                    ViewBag.Sizes = _pizzaAppDbContext.Size.ToList();
                    var orderView = new EditOrderViewModel
                    {
                        PizzaId = pizzaId
                    };
                    return View(orderView);
                }
               

            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = "Pizza can not be editted due to some error.";
                return RedirectToAction("DisplayOrders");
            }

        }
        [HttpPost]
        public IActionResult EditOrders(EditOrderViewModel edittedOrder)
        {
            try
            {
                if (edittedOrder.ToppingIds.Count == 0 || edittedOrder.ToppingIds.Count > 3)
                {
                    ViewBag.ErrorMessage = "You can select up to 3 toppings only.";

                    ViewBag.Bases = _pizzaAppDbContext.Base.ToList();
                    ViewBag.Toppings = _pizzaAppDbContext.Toppings.ToList();
                    ViewBag.Sizes = _pizzaAppDbContext.Size.ToList();

                    return View(edittedOrder);
                }
                else
                {
                    var EdittedOrder = _pizzaAppDbContext.Pizza.FirstOrDefault(eo => eo.PizzaId == edittedOrder.PizzaId);
                    if (EdittedOrder != null)
                    {
                        EdittedOrder.SizeId = edittedOrder.SizeId;
                        EdittedOrder.BaseId = edittedOrder.BaseId;
                        _pizzaAppDbContext.Pizza.Update(EdittedOrder);
                        _pizzaAppDbContext.SaveChanges();

                        var existingToppings = _pizzaAppDbContext.PizzaTopping
                                 .Where(to => to.PizzaId == edittedOrder.PizzaId).ToList();
                        var sameToppings = existingToppings.Select(to=>to.ToppingId).Intersect(edittedOrder.ToppingIds).ToList();
                        var ToppingsToRemove = existingToppings.Select(to => to.ToppingId).Except(sameToppings).ToList();
                        var ToppingsToAdd = edittedOrder.ToppingIds.Except(sameToppings).ToList();


                        var toppingsToRemoveEntities = existingToppings.Where(to => ToppingsToRemove.Contains(to.ToppingId)).ToList();
                        _pizzaAppDbContext.PizzaTopping.RemoveRange(toppingsToRemoveEntities);
                        _pizzaAppDbContext.SaveChanges();

                        var NewToppings = new List<PizzaTopping>();
                        foreach (var toppingId in ToppingsToAdd)
                        {
                            var toppingsOrder = new PizzaTopping
                            {
                                PizzaId = edittedOrder.PizzaId,
                                ToppingId = toppingId
                            };
                            NewToppings.Add(toppingsOrder);
                        }
                        _pizzaAppDbContext.PizzaTopping.AddRange(NewToppings);
                        _pizzaAppDbContext.SaveChanges();
                        return RedirectToAction("DisplayOrders");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Pizza was not found.";
                        return RedirectToAction("DisplayOrders");
                    }
                }
                
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"]= "Pizza was not editted due to some errors.";
                return RedirectToAction("DisplayOrders");
            }

        }

    }
}
