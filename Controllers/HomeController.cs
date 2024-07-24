using Microsoft.AspNetCore.Mvc;

namespace PizzaOrdering_Mvc.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}