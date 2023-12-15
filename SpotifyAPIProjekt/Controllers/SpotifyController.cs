using Microsoft.AspNetCore.Mvc;

namespace SpotifyAPIProjekt.Controllers
{
    public class SpotifyController : Controller
    {
        [HttpPost]
        public IActionResult Index()
        {
            return View("Auth");
        }
    }
}
