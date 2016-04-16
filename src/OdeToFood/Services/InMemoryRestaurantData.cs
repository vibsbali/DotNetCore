using System.Collections.Generic;
using System.Linq;
using OdeToFood.Entities;

namespace OdeToFood.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        //created static List so it doesn't get instantiated over and over again
        private static readonly List<Restaurant> Restaurants;

        static InMemoryRestaurantData()
        {
            Restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "Tersiguel's"},
                new Restaurant {Id = 2, Name = "LJ's and the Kat"},
                new Restaurant {Id = 3, Name = "King's Contrivance"}
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return Restaurants;
        }

        public Restaurant Get(int id)
        {
            return Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Restaurant restaurant)
        {
            restaurant.Id = Restaurants.Max(r => r.Id) + 1;
            Restaurants.Add(restaurant);
        }
    }
}