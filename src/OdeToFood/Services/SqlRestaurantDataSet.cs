using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Entities;

namespace OdeToFood.Services
{
    public class SqlRestaurantDataSet : IRestaurantData
    {
        private readonly OdeToFoodDbContext odeToFoodDbContext;

        public SqlRestaurantDataSet(OdeToFoodDbContext dbContext)
        {
            odeToFoodDbContext = dbContext;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return odeToFoodDbContext.Restaurants;
        }

        public Restaurant Get(int id)
        {
            return odeToFoodDbContext.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Restaurant restaurant)
        {
            odeToFoodDbContext.Add(restaurant);
            odeToFoodDbContext.SaveChanges();
        }

        public int Commit()
        {
            return odeToFoodDbContext.SaveChanges();
        }
    }
}

