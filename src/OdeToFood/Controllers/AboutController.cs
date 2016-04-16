using Microsoft.AspNet.Mvc;

namespace OdeToFood.Controllers
{
    [Route("company/[controller]")]
    public class AboutController
    {
        public string Phone()
        {
            return "+61 401 193 731";
        }

        [Route("[action]")]
        public string Country()
        {
            return "Australia";
        }
    }
}
