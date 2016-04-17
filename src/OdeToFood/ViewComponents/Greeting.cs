using Microsoft.AspNet.Mvc;
using OdeToFood.Services;

namespace OdeToFood.ViewComponents
{
    public class Greeting : ViewComponent
    {
        private IGreeter greeter;

        public Greeting(IGreeter greeter)
        {
            this.greeter = greeter;
        }

        public IViewComponentResult Invoke()
        {
            var model = greeter.GetGreeting();
            return View("Default", model);
        }
    }
}
