using System.ComponentModel.DataAnnotations;
using OdeToFood.Entities;

namespace OdeToFood.ViewModels
{
    public class RestaurantEditViewModel
    {
        [Required, MinLength(10)]
        public string Name { get; set; }
        [Required]
        public CuisineType Cuisine { get; set; }
    }
}
