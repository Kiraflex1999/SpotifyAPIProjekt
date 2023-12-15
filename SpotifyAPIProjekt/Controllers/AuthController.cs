using Microsoft.AspNetCore.Mvc;

namespace SpotifyAPIProjekt.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
