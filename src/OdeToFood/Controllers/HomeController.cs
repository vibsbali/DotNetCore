using Microsoft.AspNet.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRestaurantData restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IActionResult Index()
        {
            var model = restaurantData.GetAll();
            return View(model);
        }
    }
}
