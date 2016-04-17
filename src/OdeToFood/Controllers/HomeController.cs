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

        public HomeController(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IActionResult Index()
        {
            var model = new HomePageViewModel
            {
                Restaurants = restaurantData.GetAll()
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, RestaurantEditViewModel input)
        {
            var restaurant = restaurantData.Get(id);
            if (restaurant != null && ModelState.IsValid)
            {
                restaurant.Name = input.Name;
                restaurant.Cuisine = input.Cuisine;
                restaurantData.Commit();

                return RedirectToAction("Details", new {id = restaurant.Id});
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


/*
Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
*/
