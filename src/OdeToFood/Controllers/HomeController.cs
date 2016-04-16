using System.Linq;
using Microsoft.AspNet.Mvc;
using OdeToFood.Entities;
using OdeToFood.Services;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRestaurantData restaurantData;
        private IGreeter greeter;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            this.restaurantData = restaurantData;
            this.greeter = greeter;
        }

        public IActionResult Index()
        {
            var model = new HomePageViewModel
            {
                Restaurants = restaurantData.GetAll(),
                CurrentGreeting = greeter.GetGreeting()
            };

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var restaurant = restaurantData.Get(id);
            if (restaurant == null)
            {
                //return HttpNotFound();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RestaurantEditViewModel newRestaurant)
        {
            if (ModelState.IsValid)
            {
                var restaurant = new Restaurant
                {
                    Cuisine = newRestaurant.Cuisine,
                    Name = newRestaurant.Name
                };

                restaurantData.Add(restaurant);

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
