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
        private readonly static int MaxToppings = 3;
        private readonly static int MinToppings = 0;
        public OrderController(PizzaAppDbContext pizzaAppDbContext)
        {
            _pizzaAppDbContext = pizzaAppDbContext;
        }
        public IActionResult DisplayOrders()
        {
            try
            {

                List<OrderViewModel> orders = new List<OrderViewModel>();
                var pizzas = _pizzaAppDbContext.Pizza.Include(pizza => pizza.Size).Include(pizza => pizza._base).ToList();
                foreach (var pizza in pizzas)
                {
                    var OrderView = new OrderViewModel
                    {
                        PizzaId = pizza.PizzaId,
                        PizzaSize = pizza.Size.PizzaSize,
                        PizzaBase = pizza._base.BaseName,
                        PizzaToppings = _pizzaAppDbContext.PizzaTopping
                        .Where(pizzaTopping => pizzaTopping.PizzaId == pizza.PizzaId)
                        .Select(pizzaTopping => pizzaTopping.Topping)
                        .ToList(),
                        NoTimesOrdered = _pizzaAppDbContext.Order.Where(pizzaTopping => pizzaTopping.PizzaId == pizza.PizzaId).Count()
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
                var pizza = _pizzaAppDbContext.Pizza.FirstOrDefault(pizza => pizza.PizzaId == pizzaId);
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
                var pizza = _pizzaAppDbContext.Pizza.FirstOrDefault(pizza => pizza.PizzaId == pizzaId);
                if (pizza != null)
                {
                    ViewBag.Bases = _pizzaAppDbContext.Base.ToList();
                    ViewBag.Toppings = _pizzaAppDbContext.Toppings.ToList();
                    ViewBag.Sizes = _pizzaAppDbContext.Size.ToList();
                    var orderView = new EditOrderViewModel
                    {
                        PizzaId = pizzaId,
                        BaseId = pizza.BaseId,
                        SizeId = pizza.SizeId,
                        ToppingIds = _pizzaAppDbContext.PizzaTopping.Where(toppings => toppings.PizzaId == pizza.PizzaId).Select(toppingIds => toppingIds.ToppingId).ToList()
                    };
                    return View(orderView);
                }
                else
                {
                    TempData["ErrorMessage"] = "Pizza was not found.";
                    return RedirectToAction("DisplayOrders");
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
                if (edittedOrder.ToppingIds.Count == MinToppings || edittedOrder.ToppingIds.Count > MaxToppings)
                {
                    ViewBag.ErrorMessage = "You can select up to 3 toppings only.";

                    ViewBag.Bases = _pizzaAppDbContext.Base.ToList();
                    ViewBag.Toppings = _pizzaAppDbContext.Toppings.ToList();
                    ViewBag.Sizes = _pizzaAppDbContext.Size.ToList();

                    return View(edittedOrder);
                }
                else
                {
                    var EdittedOrder = _pizzaAppDbContext.Pizza.FirstOrDefault(orderToEdit => orderToEdit.PizzaId == edittedOrder.PizzaId);
                    if (EdittedOrder != null)
                    {
                        EdittedOrder.SizeId = edittedOrder.SizeId;
                        EdittedOrder.BaseId = edittedOrder.BaseId;
                        _pizzaAppDbContext.Pizza.Update(EdittedOrder);
                        _pizzaAppDbContext.SaveChanges();

                        var existingToppings = _pizzaAppDbContext.PizzaTopping
                                 .Where(to => to.PizzaId == edittedOrder.PizzaId).ToList();
                        var sameToppings = existingToppings.Select(toppings=> toppings.ToppingId).Intersect(edittedOrder.ToppingIds).ToList();
                        var ToppingsToRemove = existingToppings.Select(toppings => toppings.ToppingId).Except(sameToppings).ToList();
                        var ToppingsToAdd = edittedOrder.ToppingIds.Except(sameToppings).ToList();


                        var toppingsToRemoveEntities = existingToppings.Where(toppings => ToppingsToRemove.Contains(toppings.ToppingId)).ToList();

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
                        _pizzaAppDbContext.PizzaTopping.RemoveRange(toppingsToRemoveEntities);
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
